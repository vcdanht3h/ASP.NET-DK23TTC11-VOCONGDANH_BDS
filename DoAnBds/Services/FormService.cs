using DoAnBds.Models;

namespace DoAnBds.Services
{
    public interface FormService
    {
        public bool Create(Form form);
        public List<Form> findAll();
        public List<Form> Dem();
        public bool Remove(int id);
        public bool Update(Form form);
        public dynamic find2(string gmail);
        public dynamic find3();
    }
}
