using DoAnBds.Models;

namespace DoAnBds.Services
{
    public class BoPhanServiceImpl : BoPhanService
    {
        private DatabaseContext db;
        public BoPhanServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }

        public bool Create(BoPhan thau)
        {
            try
            {
                db.BoPhans.Add(thau);
                return db.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<BoPhan> findAll()
        {
            return db.BoPhans.ToList();
        }

        public BoPhan findById(string id)
        {
            return db.BoPhans.Find(id);
        }

        public bool Remove(string id)
        {
            try
            {
                db.BoPhans.Remove(db.BoPhans.Find(id));
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(BoPhan thau)
        {

            try
            {
                db.Entry(thau).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
