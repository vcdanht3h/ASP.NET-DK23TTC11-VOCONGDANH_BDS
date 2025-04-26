using DoAnBds.Models;

namespace DoAnBds.Services
{
    public interface NhanVienService
    {
        public dynamic find(string id);
        public dynamic find1(string id);
        public dynamic findnhanvien(int id);
        public List<NhanVien> findAll();
        public bool Create(NhanVien product);
        public bool Delete(string id);
        public bool Update(NhanVien product);
        public NhanVien find12(string id);
    }
}
