using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Facts;
using YoutubeBlog.Entity.DTOs.SmtpSettings;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Abstractions;

namespace YoutubeBlog.Service.Services.Concrete
{
    public class SmtpService : ISmtpService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public SmtpService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<SmtpSettingsDto>> GetAllSmtpSettings()
        {
            var smtpsetting = await unitOfWork.GetRepository<SmtpSetting>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<SmtpSettingsDto>>(smtpsetting);

            return map;

        }

        public async Task<SmtpSetting> GetSmtpSetting(string smtpName)
        {
            var smtpsetting = await unitOfWork.GetRepository<SmtpSetting>().GetAsync(x => x.SmtpName == smtpName);
            return smtpsetting;
        }

        public async Task<string> UpdateSmtpSetting(SmtpSettingsUpdateDto smtpSettingsUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var smtpsetting = await unitOfWork.GetRepository<SmtpSetting>().GetAsync(x => !x.IsDeleted && x.SmtpName == smtpSettingsUpdateDto.SmtpName);

            smtpsetting.ServerIP = smtpSettingsUpdateDto.ServerIP;
            smtpsetting.IncomingServer = smtpSettingsUpdateDto.IncomingServer;
            smtpsetting.OutgoingServer = smtpSettingsUpdateDto.OutgoingServer;
            smtpsetting.SMTPPort = smtpSettingsUpdateDto.SMTPPort;
            smtpsetting.IMAPPort = smtpSettingsUpdateDto.IMAPPort;
            smtpsetting.Username = smtpSettingsUpdateDto.Username;
            smtpsetting.Password = smtpSettingsUpdateDto.Password;

            await unitOfWork.GetRepository<SmtpSetting>().UpdateAsync(smtpsetting);
            await unitOfWork.SaveAsync();


            return smtpsetting.Username;
        }


    }
}
