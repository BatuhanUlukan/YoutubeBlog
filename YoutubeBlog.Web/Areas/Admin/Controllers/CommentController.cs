using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using YoutubeBlog.Entity.DTOs.Comments;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.Consts;
using YoutubeBlog.Web.ResultMessages;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;
        private readonly IValidator<Comment> validator;

        public CommentController(ICommentService commentService, ICategoryService categoryService, IMapper mapper, IToastNotification toast, IValidator<Comment> validator)
        {
            this.commentService = commentService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.toast = toast;
            this.validator = validator;
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        [Route("comments")]
        public async Task<IActionResult> Comments()
        {
            var comments = await commentService.GetAllComments();
            return View(comments);
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        [Route("approve-comment/{secName}")]
        public async Task<IActionResult> Approve(string secName)
        {
            var title = await commentService.ApproveComment(secName);
            toast.AddSuccessToastMessage(Messages.Comment.Approve(title), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction(nameof(Comments));
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        [Route("reject-comment/{secName}")]
        public async Task<IActionResult> Reject(string secName)
        {
            var title = await commentService.RejectComment(secName);
            toast.AddSuccessToastMessage(Messages.Comment.Reject(title), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction(nameof(Comments));
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        [Route("comment-update/{secName}")]
        [HttpGet]
        public async Task<IActionResult> Update(string secName)
        {
            var comment = await commentService.GetCommentByGuid(secName);
            var map = mapper.Map<CommentUpdateDto>(comment);

            return View(map);
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        [Route("comment-update/{secName}")]
        [HttpPost]
        public async Task<IActionResult> Update(CommentUpdateDto commentUpdateDto)
        {
            var map = mapper.Map<Comment>(commentUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await commentService.UpdateCommentAsync(commentUpdateDto);
                toast.AddSuccessToastMessage(Messages.Comment.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Comments", "Comment");
            }

            result.AddToModelState(this.ModelState);
            return View();
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        [Route("comment-delete/{secName}")]
        public async Task<IActionResult> Delete(string secName)
        {
            await commentService.DeleteCommentAsync(secName);
            toast.AddSuccessToastMessage("Comment successfully deleted.", new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction(nameof(Comments));
        }


    }
}
