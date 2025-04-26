using DoAnBds.Models;

namespace DoAnBds.Services
{
    public interface BaiVietService
    {
        public List<BaiViet> findall();
        public dynamic find1(string id);
        public List<BaiViet> find3Top();
        public List<BaiViet> find31Top();
    }
}
