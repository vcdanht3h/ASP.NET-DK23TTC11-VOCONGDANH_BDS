using DoAnBds.Models;

namespace DoAnBds.Services
{
    public class BaiVietServiceImpl : BaiVietService
    {
        private DatabaseContext db;
        public BaiVietServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public dynamic find1(string id)
        {
            return db.BaiViets.Where(p=>p.MaBv==id).ToList();    
        }

        public List<BaiViet> find3Top()
        {
            return db.BaiViets.OrderBy(p => p.MaBv).Skip(0).Take(3).ToList();
        }
        public List<BaiViet> find31Top()
        {
            return db.BaiViets.OrderBy(p => p.MaBv).Skip(3).Take(6).ToList();
        }
        public List<BaiViet> findall()
        {
            return db.BaiViets.ToList();
        }
    }
}
