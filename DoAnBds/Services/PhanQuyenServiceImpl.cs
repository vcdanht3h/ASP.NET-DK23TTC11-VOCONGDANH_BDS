using DoAnBds.Models;

namespace DoAnBds.Services
{
    public class PhanQuyenServiceImpl : PhanQuyenService
    {
        private DatabaseContext db;
        public PhanQuyenServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }

        public bool create(PhanQuyen hang)
        {
            try
            {
                db.PhanQuyens.Add(hang);
                return db.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public dynamic find2(int id)
        {
            return db.PhanQuyens.Find(id);
        }

        public List<PhanQuyen> findAll()
        {
            return db.PhanQuyens.ToList();
        }

        public bool remove(int id)
        {
            try
            {
                db.PhanQuyens.Remove(db.PhanQuyens.Find(id));
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       
        public bool update(PhanQuyen hang)
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
