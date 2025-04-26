using DoAnBds.Models;

namespace DoAnBds.Services
{
    public class NhaThauServiceImpl : NhaThauService
    {
        private DatabaseContext db;
        public NhaThauServiceImpl(DatabaseContext _db) {
            this.db = _db;
        }

        public bool Create(NhaThau thau)
        {
            try
            {
                db.NhaThaus.Add(thau);
                return db.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<NhaThau> findAll()
        {
            return db.NhaThaus.ToList();
        }

        public dynamic findById(string id)
        {
            return db.NhaThaus.Find(id);
        }

        public bool Remove(string id)
        {
            try
            {
                db.NhaThaus.Remove(db.NhaThaus.Find(id));
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(NhaThau thau)
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
