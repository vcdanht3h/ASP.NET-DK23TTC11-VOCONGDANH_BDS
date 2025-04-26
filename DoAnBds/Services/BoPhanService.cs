using DoAnBds.Models;

namespace DoAnBds.Services
{
    public interface BoPhanService
    {
        public List<BoPhan> findAll();
        public BoPhan findById(string id);
        public bool Create(BoPhan thau);
        public bool Remove(string id);
        public bool Update(BoPhan thau);
    }
}
