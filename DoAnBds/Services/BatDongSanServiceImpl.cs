using DoAnBds.Models;

namespace DoAnBds.Services
{
    public class BatDongSanServiceImpl : BatDongSanService
    {
        private DatabaseContext db;
        public BatDongSanServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public List<BatDongSan> find(string id)
        {
            return db.BatDongSans.Where(p=>p.MaDm==id).ToList();
        }

        public List<BatDongSan> find3Top()
        {
            return db.BatDongSans.OrderBy(p => p.GiaBds).Skip(2).Take(3).ToList();
        }
    
        public List<BatDongSan> find4Top()
        {
            return db.BatDongSans.OrderBy(p => p.GiaBds).Skip(1).Take(3).ToList();
        }
        public List<BatDongSan> find2Top()
        {
            return db.BatDongSans.OrderBy(p => p.GiaBds).Skip(1).Take(4).ToList();
        }
        public List<BatDongSan> findAll()
        {
            return db.BatDongSans.ToList();
        }
        public dynamic find1(string id)
        {
            return db.BatDongSans.Where(p => p.MaBds == id).ToList();
        }

        public List<BatDongSan> find5Top()
        {
            return db.BatDongSans.OrderBy(p => p.GiaBds).Skip(5).Take(9).ToList();
        }

        public List<BatDongSan> search(string keyword)
        {
            return db.BatDongSans.Where(p => p.TenBds.Contains(keyword)).ToList();
        }

        public List<BatDongSan> search1(string categoryId)
        {
            return db.BatDongSans.Where(p=>p.MaDm == categoryId).ToList();
        }

        public List<BatDongSan> search2(double price)
        {
            return db.BatDongSans.Where(p => p.GiaBds==price).ToList();
        }

        public bool Create(BatDongSan product)
        {
            try
            {
                db.BatDongSans.Add(product);
                return db.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                db.BatDongSans.Remove(db.BatDongSans.Find(id));
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public BatDongSan find2(string id)
        {
            return db.BatDongSans.Find(id);
        }
        public bool Update(BatDongSan product)
        {
            try
            {
                db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

      
    }
}
