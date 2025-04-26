using DoAnBds.Models;

namespace DoAnBds.Services
{
    public interface BatDongSanService
    {
        public List<BatDongSan> findAll();
        public List<BatDongSan> find4Top();
        public List<BatDongSan> find3Top();
        public List<BatDongSan> find2Top();
        public List<BatDongSan> find5Top();
        public List<BatDongSan> find(string id);
        public dynamic find1(string id);
        public BatDongSan find2(string id);
        public List<BatDongSan> search(string keyword);
        public List<BatDongSan> search1(string categoryId);
        public List<BatDongSan> search2(double price);
        public bool Create(BatDongSan product);
        public bool Delete(string id);
        public bool Update(BatDongSan product);

    }
}
