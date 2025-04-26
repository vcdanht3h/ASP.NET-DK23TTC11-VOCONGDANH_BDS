using DoAnBds.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoAnBds.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/login")]
    public class LoginController : Controller
    {
        private BatDongSanService batDongSanService;
        private DanhMucBatDongSanService danhMucbatDongSanService;
        private NhanVienService nhanVienService;
        private AccountService accountService;
        public LoginController(BatDongSanService _batDongSanService, DanhMucBatDongSanService _danhMucBatDongSanSerive, NhanVienService _nhanVienService, AccountService _accountService)
        {
            this.batDongSanService = _batDongSanService;
            this.danhMucbatDongSanService = _danhMucBatDongSanSerive;
            this.nhanVienService = _nhanVienService;
            this.accountService = _accountService;
        }
        [HttpGet]
        [Route("index")]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        [Route("index")]
        
        public IActionResult Index(string username, string password)
        {
            if (accountService.Login(username, password))
            {
                HttpContext.Session.SetString("username",username);
                TempData["name"]=username;
                ViewBag.names = username;
                return RedirectToAction("index","Dashboard", @TempData["name"]);
            }
            else
            {
                TempData["msg"] = "Failed";
                return RedirectToAction("login", "account");
            }
        }
    }
}
