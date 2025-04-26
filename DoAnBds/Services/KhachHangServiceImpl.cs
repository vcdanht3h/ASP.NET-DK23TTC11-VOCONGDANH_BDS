using DoAnBds.Models;

namespace DoAnBds.Services
{
    public class KhachHangServiceImpl : KhachHangService
    {
        private DatabaseContext db;
        public KhachHangServiceImpl(DatabaseContext _db)
        {
            this.db = _db;

        }

        public bool create(KhachHang hang)
        {
            try
            {
                db.KhachHangs.Add(hang);
                return db.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public KhachHang find2(string id)
        {
            return db.KhachHangs.Find(id);
        }

        public List<KhachHang> findAll()
        {
           return db.KhachHangs.ToList();
        }

        public bool remove(string id)
        {
            try
            {
                db.KhachHangs.Remove(db.KhachHangs.Find(id));
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool update(KhachHang hang)
        {
            try
            {
                db.Entry(hang).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
