
using DoAnBds.Helpers;
using DoAnBds.Models;
using DoAnBds.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DoAnBds.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/dashboard")]
    public class DashBoardController : Controller
    {
        private NhanVienService nhanVienService;
        private BatDongSanService batDongSanService;
        private KhachHangService khachHangService;
        private NhaThauService nhaThauService;
        private PhanQuyenService phanQuyenService;
        private BoPhanService boPhanService;
        private FormService formService;
        private IWebHostEnvironment webHostEnvironment;
        private IConfiguration _configuration;
        public string name;
        public DashBoardController(NhanVienService _nhanvienService, BatDongSanService _batdongsanService, KhachHangService _khachhangService, NhaThauService _nhaThauService, PhanQuyenService _phanQuyenService, BoPhanService _boPhanService, FormService _formService, IWebHostEnvironment _webHostEnvironment, IConfiguration configuration)
        {
            this.nhanVienService = _nhanvienService;
            this.batDongSanService = _batdongsanService;
            this.khachHangService = _khachhangService;
            this.nhaThauService = _nhaThauService;
            this.phanQuyenService = _phanQuyenService;
            this.boPhanService = _boPhanService;
            this.formService = _formService;
            this.webHostEnvironment = _webHostEnvironment;
            _configuration = configuration; 

        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.forms = formService.findAll();
            ViewBag.khachhangs = khachHangService.findAll();
            ViewBag.nhathaus = nhaThauService.findAll();
            ViewBag.batdongsans = batDongSanService.findAll();
    
            return View();
        }
        [Route("")]
        [Route("batdongsan")]
        public IActionResult BatDongSan()
        {
            ViewBag.batdongsans = batDongSanService.findAll();
            return View();
        }
        [Route("khachhang")]
        public IActionResult KhachHang()
        {
            ViewBag.khachhangs = khachHangService.findAll();
            return View();
        }
        [Route("nhathau")]
        public IActionResult NhaThau()
        {
            ViewBag.nhathaus = nhaThauService.findAll();
            return View();
        }
        [Route("nhanvien")]
        public IActionResult NhanVien()
        {
            ViewBag.nhanviens = nhanVienService.findAll();
            return View();
        }
        [Route("phanquyen")]
        public IActionResult PhanQuyen()
        {
            ViewBag.phanquyens = phanQuyenService.findAll();
            return View();
        }
        [Route("bophan")]
        public IActionResult BoPhan()
        {
            ViewBag.bophans = boPhanService.findAll();
            return View();
        }
        
        [HttpGet]
        [Route("addbatdongsan")]
        public IActionResult AddBatDongSan()
        {
            var batdongsan = new BatDongSan();
            /* {
                // Created = DateTime.Now
             };*/
            //Lấy ds danh mục ra
            // ViewBag.Categories = categoryService.findAll();
            return View("AddBatDongSan", batdongsan);
        }
        [HttpPost]
        [Route("addbatdongsan")]
        public IActionResult AddBatDongSan(BatDongSan product, IFormFile file, IFormFile file1, IFormFile file2, IFormFile file3)
        {
            if (file != null)
            {
                //Lấy tên file ng ta uplaod lên
                var fileName = FileHelper.generateFileName(file.FileName);
                //Lấy tên file ng ta uplaod lên
                var fileName1 = FileHelper.generateFileName(file1.FileName);
                var fileName2 = FileHelper.generateFileName(file2.FileName);
                var fileName3 = FileHelper.generateFileName(file3.FileName);
                //Khai báo đường dẫn, lấy đường dẫn
                var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
                var path1 = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName1);
                var path2 = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName2);
                var path3 = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName3);
                //Lấy dường dẫn về wwroot
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                using (var fileStream1 = new FileStream(path1, FileMode.Create))
                {
                    file.CopyTo(fileStream1);
                }
                using (var fileStream2 = new FileStream(path2, FileMode.Create))
                {
                    file.CopyTo(fileStream2);
                }
                using (var fileStream3 = new FileStream(path3, FileMode.Create))
                {
                    file.CopyTo(fileStream3);
                }
                product.HinhAnh = fileName;
                product.HinhAnh1 = fileName;
                product.HinhAnh2 = fileName;
                product.HinhAnh3 = fileName;
            }
            else
            {
                product.HinhAnh = "noimage.png";
                product.HinhAnh1 = "noimage.png";
                product.HinhAnh2 = "noimage.png";
                product.HinhAnh3 = "noimage.png";
            }
            if (batDongSanService.Create(product))
            {
                //Session chỉ xái 1 lần xong tự hủy
                //Session Flash
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("BatDongSan");
        }
        [Route("removebatdongsan/{id}")]
        public IActionResult RemoveBatDongSan(string id)
        {
            if (batDongSanService.Delete(id))
            {
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("BatDongSan");
        }
        [HttpGet]
        [Route("editbatdongsan/{id}")]
        public IActionResult EditBatDongSan(string id)
        {
            var product = batDongSanService.find2(id);
            //Lấy ds danh mục ra
            return View("EditBatDongSan", product);
        }
        [HttpPost]
        [Route("editbatdongsan/{id}")]
        public IActionResult EditBatDongSan(string id, BatDongSan product, IFormFile file, IFormFile file1, IFormFile file2, IFormFile file3)
        {
            //Kiểm tra người ta có chọn hình ko
            if (file != null)
            {
                //Có chọn
                var fileName = FileHelper.generateFileName(file.FileName);
                //Lấy tên file ng ta uplaod lên
                var fileName1 = FileHelper.generateFileName(file1.FileName);
                var fileName2 = FileHelper.generateFileName(file2.FileName);
                var fileName3 = FileHelper.generateFileName(file3.FileName);
                //Khai báo đường dẫn, lấy đường dẫn
                var path = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName);
                var path1 = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName1);
                var path2 = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName2);
                var path3 = Path.Combine(webHostEnvironment.WebRootPath, "images", fileName3);
                //Lấy dường dẫn về wwroot
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                using (var fileStream1 = new FileStream(path1, FileMode.Create))
                {
                    file.CopyTo(fileStream1);
                }
                using (var fileStream2 = new FileStream(path2, FileMode.Create))
                {
                    file.CopyTo(fileStream2);
                }
                using (var fileStream3 = new FileStream(path3, FileMode.Create))
                {
                    file.CopyTo(fileStream3);
                }
                product.HinhAnh = fileName;
                product.HinhAnh1 = fileName;
                product.HinhAnh2 = fileName;
                product.HinhAnh3 = fileName;
            }
            
            if (batDongSanService.Update(product))
            {
                //Session chỉ xái 1 lần xong tự hủy
                //Session Flash
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("BatDongSan");
        }
        [HttpGet]
        [Route("addkhachhang")]
        public IActionResult AddKhachHang()
        {
            var khachhang = new KhachHang();
            /* {
                // Created = DateTime.Now
             };*/
            //Lấy ds danh mục ra
            // ViewBag.Categories = categoryService.findAll();
            return View("AddKhachHang", khachhang);
        }
        [HttpPost]
        [Route("addkhachhang")]
        public IActionResult AddKhachHang(KhachHang khachhang)
        {
  
            if (khachHangService.create(khachhang))
            {
                //Session chỉ xái 1 lần xong tự hủy
                //Session Flash
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("KhachHang");
        }
        [Route("removekhachhang/{id}")]

        public IActionResult RemoveKhachHang(string id)
        {
            if (khachHangService.remove(id))
            {
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("KhachHang");
        }
        [HttpGet]
        [Route("editkhachhang/{id}")]
        public IActionResult EditKhachHang(string id)
        {
            var product = khachHangService.find2(id);
            return View("EditKhachHang", product);
        }
        [HttpPost]
        [Route("editkhachhang/{id}")]
        public IActionResult EditKhachHang(string id, KhachHang product)
        {
            
            if (khachHangService.update(product))
            {
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("KhachHang");
        }
        [HttpGet]
        [Route("addnhathau")]
        public IActionResult AddNhaThau()
        {
            var khachhang = new NhaThau();
            /* {
                // Created = DateTime.Now
             };*/
            //Lấy ds danh mục ra
            // ViewBag.Categories = categoryService.findAll();
            return View("AddNhaThau", khachhang);
        }
        [HttpPost]
        [Route("addnhathau")]
        public IActionResult AddNhaThau(NhaThau nhathau)
        {

            if (nhaThauService.Create(nhathau))
            {
                //Session chỉ xái 1 lần xong tự hủy
                //Session Flash
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("NhaThau");
        }
        [Route("removenhathau/{id}")]

        public IActionResult RemoveNhaThau(string id)
        {
            if (nhaThauService.Remove(id))
            {
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("NhaThau");
        }
        [HttpGet]
        [Route("editnhathau/{id}")]
        public IActionResult EditNhaThau(string id)
        {
            var product = nhaThauService.findById(id);
            return View("EditNhaThau", product);
        }
        [HttpPost]
        [Route("editnhathau/{id}")]
        public IActionResult EditNhaThau(string id, NhaThau product)
        {

            if (nhaThauService.Update(product))
            {
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("NhaThau");
        }
        [HttpGet]
        [Route("addnhanvien")]
        public IActionResult AddNhanVien()
        {
            var khachhang = new NhanVien();
            /* {
                // Created = DateTime.Now
             };*/
            //Lấy ds danh mục ra
            // ViewBag.Categories = categoryService.findAll();
            return View("AddNhanVien", khachhang);
        }
        [HttpPost]
        [Route("addnhanvien")]
        public IActionResult AddNhanVien(NhanVien nhathau)
        {

            if (nhanVienService.Create(nhathau))
            {
                //Session chỉ xái 1 lần xong tự hủy
                //Session Flash
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("NhanVien");
        }
        [Route("removenhanvien/{id}")]

        public IActionResult RemoveNhanVien(string id)
        {
            if (nhanVienService.Delete(id))
            {
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("NhanVien");
        }
        [HttpGet]
        [Route("editnhanvien/{id}")]
        public IActionResult EditNhanVien(string id)
        {
            var product = nhanVienService.find12(id);
            return View("EditNhanVien", product);
        }
        [HttpPost]
        [Route("editnhanvien/{id}")]
        public IActionResult EditNhanVien(string id, NhanVien product)
        {

            if (nhanVienService.Update(product))
            {
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("NhanVien");
        }
        [HttpGet]
        [Route("addphanquyen")]
        public IActionResult AddPhanQuyen()
        {
            var khachhang = new PhanQuyen();
            /* {
                // Created = DateTime.Now
             };*/
            //Lấy ds danh mục ra
            // ViewBag.Categories = categoryService.findAll();
            return View("AddPhanQuyen", khachhang);
        }
        [HttpPost]
        [Route("addphanquyen")]
        public IActionResult AddPhanQuyen(PhanQuyen nhathau)
        {
            
            if (phanQuyenService.create(nhathau))
            {
                //Session chỉ xái 1 lần xong tự hủy
                //Session Flash
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("PhanQuyen");
        }
        [Route("removephanquyen/{id}")]

        public IActionResult RemovePhanQuyen(int id)
        {
            if (phanQuyenService.remove(id))
            {
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("PhanQuyen");
        }
        [HttpGet]
        [Route("editphanquyen/{id}")]
        public IActionResult EditPhanQuyen(int id)
        {
            var product = phanQuyenService.find2(id);
            return View("EditPhanQuyen", product);
        }
        [HttpPost]
        [Route("editphanquyen/{id}")]
        public IActionResult EditPhanQuyen(int id, PhanQuyen product)
        {

            if (phanQuyenService.update(product))
            {
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("PhanQuyen");
        }
        [HttpGet]
        [Route("addbophan")]
        public IActionResult AddBoPhan()
        {
            var khachhang = new BoPhan();
            /* {
                // Created = DateTime.Now
             };*/
            //Lấy ds danh mục ra
            // ViewBag.Categories = categoryService.findAll();
            return View("AddBoPhan", khachhang);
        }
        [HttpPost]
        [Route("addbophan")]
        public IActionResult AddBoPhan(BoPhan nhathau)
        {

            if (boPhanService.Create(nhathau))
            {
                //Session chỉ xái 1 lần xong tự hủy
                //Session Flash
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("BoPhan");
        }
        [Route("removebophan/{id}")]

        public IActionResult RemoveBoPhan(string id)
        {
            if (boPhanService.Remove(id))
            {
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("BoPhan");
        }
        [HttpGet]
        [Route("editbophan/{id}")]
        public IActionResult EditBoPhan(string id)
        {
            var product = boPhanService.findById(id);
            return View("EditBoPhan", product);
        }
        [HttpPost]
        [Route("editphanquyen/{id}")]
        public IActionResult EditBoPhan(string id, BoPhan product)
        {

            if (boPhanService.Create(product))
            {
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("BoPhan");
        }
        [Route("form")]
              
        public IActionResult Form()
        {

            ViewBag.forms = formService.find3();
            return View("Form", new Form());
        }
        [Route("form1")]

        public IActionResult Form1()
        {
            ViewBag.forms = formService.findAll();
            return View("Form1", new Form());
        }
        [HttpPost]
        [Route("send")]
        public IActionResult Send(Form contact)
        {
            var mailHelper = new MailHelper(_configuration);
            var content = "Email: " + contact.Gmail;
            content += "<br>Chủ đề " + contact.ChuDe;
            content += "<br>Nội dung: " + contact.NoiDung;
            contact.Status = true;
            if (mailHelper.Send(_configuration["Gmail:Username"],contact.Gmail,contact.ChuDe,content))
            {
                var forms = formService.find2(contact.Gmail);
                foreach( var form in forms)
                {
                    form.Status = true;
                    formService.Update(form);
                }
            
                TempData["Msg"] = "Success";
                return RedirectToAction("Form");
            }
            else
            {
                TempData["Msg"] = "Failed";
                return RedirectToAction("Form");
            }
        }
        [Route("removeform/{id}")]
        public IActionResult RemoveForm(int id)
        {
            if (formService.Remove(id))
            {
                TempData["msg"] = "Done";
            }
            else
            {
                TempData["msg"] = "Failed";
            }
            return RedirectToAction("Form");
        }
    }

}
