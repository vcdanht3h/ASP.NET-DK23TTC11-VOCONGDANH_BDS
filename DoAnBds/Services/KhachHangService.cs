using DoAnBds.Models;

namespace DoAnBds.Services
{
    public interface KhachHangService
    {
        public List<KhachHang> findAll();
        public bool create(KhachHang hang);
        public bool remove(string id);
        public bool update(KhachHang hang);
        public KhachHang find2(string id);
    }
}
