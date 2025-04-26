using DoAnBds.Models;

namespace DoAnBds.Services
{
    

    public class DanhMucBatDongSanSeriveImpl:DanhMucBatDongSanService
    {
        private DatabaseContext db;
        public DanhMucBatDongSanSeriveImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public List<DanhMucBatDongSan> find(string id)
        { 
            return db.DanhMucBatDongSans.Where(p=>p.MaDm==id).ToList(); 
        }

        

        public List<DanhMucBatDongSan> findAll()
        {
            return db.DanhMucBatDongSans.ToList();
        }
    }
}
