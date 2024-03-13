using YoutubeBlog.Entity.DTOs.SmtpSettings;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstractions
{
    public interface ISmtpService
    {
        Task<List<SmtpSettingsDto>> GetAllSmtpSettings();
        Task<SmtpSetting> GetSmtpSetting(string smtpName);
        Task<string> UpdateSmtpSetting(SmtpSettingsUpdateDto smtpSettingsUpdateDto);

    }
}
