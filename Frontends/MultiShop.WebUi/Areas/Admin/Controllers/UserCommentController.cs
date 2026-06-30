using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.UserCommentDtos;
using MultiShop.WebUi.Services.CatalogServices.UserCommentServices;

namespace MultiShop.WebUi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserCommentController : Controller
    {
        private readonly IUserCommentService _userCommentService;

        public UserCommentController(IUserCommentService userCommentService)
        {
            _userCommentService = userCommentService;
        }

        private async Task getRoutingsAsync()
        {
            HttpContext.Items["v0"] = "Özel Teklif İşlemleri";
            HttpContext.Items["v0"] = "Özel Teklif Listesi";
            HttpContext.Items["v2"] = "/Admin/UserComment/Index";
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            await getRoutingsAsync();
            var values = await _userCommentService.GetAllUserCommentAsync();

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateUserComment()
        {
            try
            {
                await getRoutingsAsync();

                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserComment([FromForm] CreateUserCommentDto createUserCommentDto)
        {
            try
            {
                if (createUserCommentDto == null)
                    return View("Error");

                await _userCommentService.CreateUserCommentAsync(createUserCommentDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> DeleteUserComment(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await _userCommentService.DeleteUserCommentAsync(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUserComment(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                    return View("Error");

                await getRoutingsAsync();

                var value = await _userCommentService.GetUserCommentByIdAsync(id);
                if (value == null)
                    return View("Error");

                return View(value);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserComment(UpdateUserCommentDto updateUserCommentDto)
        {
            try
            {
                if (updateUserCommentDto == null)
                    return View("Error");

                await _userCommentService.UpdateUserCommentAsync(updateUserCommentDto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
    }
}
