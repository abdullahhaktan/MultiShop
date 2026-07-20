using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUi.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUi.Services.StatisticServices.CommentService;
using MultiShop.WebUi.Services.StatisticServices.DiscontStatisticService;
using MultiShop.WebUi.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUi.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly IUserCommentStatisticService _userCommentStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;
        private readonly IDiscountStatisticService _discountStasticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, IUserCommentStatisticService userCommentStatisticService, IMessageStatisticService messageStatisticService, IDiscountStatisticService discountStatisticServie)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _userCommentStatisticService = userCommentStatisticService;
            _messageStatisticService = messageStatisticService;
            _discountStasticService = discountStatisticServie;
        }

        public async Task<IActionResult> Index()
        {
            var brandCount = await _catalogStatisticService.GetBrandCountAsync();
            var productCount = await _catalogStatisticService.GetProductCountAsync();
            var categoryCount = await _catalogStatisticService.GetCategoryCountAsync();
            var maxPriceProductName = await _catalogStatisticService.GetMaxPriceProductNameAsync();
            var minPriceProductName = await _catalogStatisticService.GetMinPriceProductNameAsync();

            ViewBag.brandCount = brandCount;
            ViewBag.productCount = productCount;
            ViewBag.categoryCount = categoryCount;
            ViewBag.maxPriceProductName = maxPriceProductName;
            ViewBag.minPriceProductName = minPriceProductName;

            var userCount = await _userStatisticService.GetUserCountAsync();

            ViewBag.userCount = userCount;

            var totalCommentCount = await _userCommentStatisticService.GetTotalCommentCountAsync();
            var activeCommentCount = await _userCommentStatisticService.GetActiveCommentCountASync();
            var passiveCommentCount = await _userCommentStatisticService.GetPassiveCommentCountAsync();

            ViewBag.totalCommentCount = totalCommentCount;
            ViewBag.activeCommentCount = activeCommentCount;
            ViewBag.passiveCommentCount = passiveCommentCount;

            var discountCouponCount = await _discountStasticService.GetDiscountCouponCountAsync();

            ViewBag.discountCouponCount = discountCouponCount;

            var totalMessageCount = await _messageStatisticService.GetTotalMessageCount();

            ViewBag.totalMessageCount = totalMessageCount;

            return View();
        }
    }
}
