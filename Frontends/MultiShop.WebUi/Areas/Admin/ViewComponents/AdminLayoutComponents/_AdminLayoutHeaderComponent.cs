using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.Interfaces;
using MultiShop.WebUi.Services.MessageServices;
using MultiShop.WebUi.Services.UserCommentServices;

namespace MultiShop.WebUi.Areas.Admin.ViewComponents.AdminLayoutComponents
{
    public class _AdminLayoutHeaderComponent : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        private readonly IUserCommentService _userCommentService;

        public _AdminLayoutHeaderComponent(IMessageService messageService, IUserService userService, IUserCommentService userCommentService)
        {
            _messageService = messageService;
            _userService = userService;
            _userCommentService = userCommentService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfoAsync();
            int messageCountByReceiver = await _messageService.GetTotalMessageCountByReceiverIdAsync(user.Id);
            ViewBag.messageCountByReceiver = messageCountByReceiver;

            int totalCommentCount = await _userCommentService.GetTotalCommentCount();
            ViewBag.totalCommentCount = totalCommentCount;
            return View();
        }
    }
}
