using DoAnBds.Models;

namespace DoAnBds.Services
{
    public class NhanVienServiceImpl : NhanVienService
    {
        private DatabaseContext db;
        public NhanVienServiceImpl (DatabaseContext _db)
        {
            this.db = _db;
        }

        public bool Create(NhanVien product)
        {
            try
            {
                db.NhanViens.Add(product);
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
                db.NhanViens.Remove(db.NhanViens.Find(id));
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public dynamic find(string mabp)
        {
            return db.NhanViens.Where(p=>p.MaBp==mabp).ToList();
        }
        public dynamic find1(string mabp)
        {
            return db.NhanViens.Where(p => p.MaNv == mabp).ToList();
        }

        public NhanVien find12(string id)
        {
            return db.NhanViens.Find(id);
        }

        public List<NhanVien> findAll()
        {
           return db.NhanViens.ToList();
        }

        public dynamic findnhanvien(int id)
        {
            return db.NhanViens.Find(id);
        }

        public bool Update(NhanVien product)
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
