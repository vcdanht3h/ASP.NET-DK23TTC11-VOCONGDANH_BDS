using DoAnBds.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoAnBds.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private BatDongSanService batDongSanService;
        private DanhMucBatDongSanService danhMucbatDongSanService;
        private NhanVienService nhanVienService;
        private AccountService accountService;
        public AccountController(BatDongSanService _batDongSanService, DanhMucBatDongSanService _danhMucBatDongSanSerive, NhanVienService _nhanVienService, AccountService _accountService)
        {
            this.batDongSanService = _batDongSanService;
            this.danhMucbatDongSanService = _danhMucBatDongSanSerive;
            this.nhanVienService = _nhanVienService;
            this.accountService = _accountService;
        }
      /*  [Route("login")]
        public IActionResult Login()
        {
            string mabp = "BPKD";
            ViewBag.nhanviens = nhanVienService.find(mabp);
            return View("admin/dashboard/index");
        }*/
        [HttpGet]
        [Route("login")]
        [Route("")]
        //     [Route("~/")]
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [Route("login")]
        //     [Route("~/")]
        public IActionResult Login(string username, string password)
        {
            if (accountService.Login(username, password))
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("Dashboard/Index");
            }
            else
            {
                TempData["msg"] = "Failed";
                return RedirectToAction("login");
            }
        }
    }
}
