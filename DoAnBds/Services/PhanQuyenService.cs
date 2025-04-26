using DoAnBds.Models;

namespace DoAnBds.Services
{
    public interface PhanQuyenService
    {
        public List<PhanQuyen> findAll();
        public bool create(PhanQuyen hang);
        public bool remove(int id);
        public bool update(PhanQuyen hang);
        public dynamic find2(int id);
    }
}
