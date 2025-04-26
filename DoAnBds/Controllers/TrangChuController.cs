using DoAnBds.Models;
using DoAnBds.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DoAnBds.Controllers
{
    [Route("trangchu")]
    public class TrangChuController : Controller
    {
        private BatDongSanService batDongSanService;
        private DanhMucBatDongSanService danhMucbatDongSanService;
        private NhanVienService nhanVienService;
        private BaiVietService baiVietService;
        private FormService formService;
        public TrangChuController(BatDongSanService _batDongSanService, DanhMucBatDongSanService _danhMucBatDongSanSerive, NhanVienService _nhanVienService, BaiVietService _baiVietService, FormService _formService)
        {
            this.batDongSanService = _batDongSanService;
            this.danhMucbatDongSanService = _danhMucBatDongSanSerive;
            this.nhanVienService = _nhanVienService;
            this.baiVietService = _baiVietService;
            this.formService = _formService; 
        }
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            // ViewBag.batdongsans=batDongSanService.findAll();
            string mabp = "BPKD";
            ViewBag.nhanviens = nhanVienService.find(mabp);
            ViewBag.batdongsans = batDongSanService.find4Top();
            ViewBag.batdongsan1s = batDongSanService.find3Top();
            ViewBag.danhmucbatsongsans = danhMucbatDongSanService.findAll();
            return View();
        }
        [Route("nhadatban")]
        public IActionResult NhaDatBan() {
            string mabp = "BPKD";
            ViewBag.nhanviens = nhanVienService.find(mabp);
            ViewBag.batdongsans = batDongSanService.findAll();
            return View();
        }
        [Route("duan")]
        public IActionResult DuAn()
        {
            string mabp = "BPKD";
            ViewBag.nhanviens = nhanVienService.find(mabp);
            ViewBag.danhmucbatdongsans = danhMucbatDongSanService.findAll();
            ViewBag.batdongsans = batDongSanService.findAll();
            ViewBag.batdongsan1s = batDongSanService.find4Top();
            ViewBag.batdongsan2s = batDongSanService.find3Top();
            ViewBag.batdongsan3s = batDongSanService.find2Top();
            ViewBag.batdongsan4s = batDongSanService.find5Top();
            return View("DuAn");
        }
		[Route("tintuc")]
		public IActionResult TinTuc()
		{
            string mabp = "BPKD";
            ViewBag.baiviet1s = baiVietService.find3Top();
            ViewBag.baiviet2s = baiVietService.find31Top();
            ViewBag.baiviets = baiVietService.findall();
            ViewBag.nhanviens = nhanVienService.find(mabp);
            return View();
		}
        [Route("chitietdanhmuc/{id}")]
        public IActionResult ChiTietDanhMuc(string id)
        {
            ViewBag.chitietdanhmucs = danhMucbatDongSanService.find(id);
            ViewBag.batdongsans=batDongSanService.find(id);
            string mabp = "BPKD";
            ViewBag.nhanviens = nhanVienService.find(mabp);
            return View("ChiTietDanhMuc");
        }
        [Route("chitietbatdongsan/{id}")]
        public IActionResult ChiTietBatDongSan(string id)
        {
           
            ViewBag.batdongsans = batDongSanService.find1(id);
            string mabp = "BPKD";
            ViewBag.nhanviens = nhanVienService.find(mabp);
            return View("ChiTietBatDongSan");
        }
        [Route("chitietnhanvien/{id}")]
        public IActionResult ChiTietNhanVien(string id)
        {
            string mabp = "BPKD";
            ViewBag.nhanviens = nhanVienService.find(mabp);
            ViewBag.nhanvien1s = nhanVienService.find1(id);
            return View("ChiTietNhanVien");
        }
        [Route("lienhe")]
        public IActionResult LienHe()
        {
      
            return View("LienHe");
        }
        [Route("chitietbaiviet/{id}")]
        public IActionResult ChiTietBaiViet(string id)
        {
            ViewBag.baiviet1s = baiVietService.find1(id);
            return View("ChiTietBaiViet");
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add(Form form)
        {
            if (formService.Create(form))
            {
                //Session chỉ xái 1 lần xong tự hủy
                //Session Flash
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("Index");
        }
        [Route("searchByKeyword")]
        public IActionResult searchByKeyword(string keyword,string categoryId,string price)
        {
            ViewBag.batdongsans = batDongSanService.search(keyword);
                //ViewBag.batdongsans = batDongSanService.findAll();
            ViewBag.batdongsan1s = batDongSanService.find4Top();
            ViewBag.batdongsan2s = batDongSanService.find3Top();
            ViewBag.batdongsan3s = batDongSanService.find2Top();
            ViewBag.batdongsan4s = batDongSanService.find5Top();
            ViewBag.danhmucbatdongsans = danhMucbatDongSanService.findAll();
            //Giu74 lại cái keyword
            ViewBag.keyword = keyword;
            if(ViewBag.keyword==null)
            {
                ViewBag.batdongsans = batDongSanService.search1(categoryId);
                ViewBag.danhmucbatdongsans = danhMucbatDongSanService.findAll();
            }
            if(ViewBag.keyword==null)
            {
                if(price=="500-2")
                {
                    ViewBag.batdongsans = batDongSanService.search2(1);
                }
                if(price=="2-4")
                {
                    ViewBag.batdongsans = batDongSanService.search2(3);
                }
            }
            return View("DuAn");
        }
        [Route("searchByCategory")]
        public IActionResult searchByCategory(string categoryId)
        {
            ViewBag.batdongsans = batDongSanService.search1(categoryId);
            ViewBag.danhmucbatdongsans= danhMucbatDongSanService.findAll();
            return View("DuAn");
        }
    }
}
