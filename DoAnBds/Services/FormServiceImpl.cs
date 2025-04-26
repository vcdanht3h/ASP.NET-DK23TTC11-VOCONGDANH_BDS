using DoAnBds.Models;

namespace DoAnBds.Services
{
    public class FormServiceImpl : FormService
    {
        private DatabaseContext db;
        public FormServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public bool Create(Form form)
        {
            try
            {
                db.Forms.Add(form);
                return db.SaveChanges() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Form> Dem()
        {
            throw new NotImplementedException();
        }
        public dynamic find2(string gmail)
        {
          return db.Forms.Where(p => p.Gmail == gmail).ToList();
        }

        public dynamic find3()
        {
            return db.Forms.Where(p => p.Status == false).ToList();
        }

        public List<Form> findAll()
        {
           return db.Forms.ToList();
        }

        public bool Remove(int id)
        {
            try
            {
                db.Forms.Remove(db.Forms.Find(id));
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Update(Form form)
        {
            try
            {
                db.Entry(form).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
