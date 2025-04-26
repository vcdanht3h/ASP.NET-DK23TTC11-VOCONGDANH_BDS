using DoAnBds.Models;

namespace DoAnBds.Services
{
    public interface DanhMucBatDongSanService
    {
        public List<DanhMucBatDongSan> findAll();
        public List<DanhMucBatDongSan> find(string id);
        

    }
}
