using DoAnBds.Models;

namespace DoAnBds.Services
{
    public interface NhaThauService
    {
        public List<NhaThau> findAll();
        public dynamic findById(string id);
        public bool Create(NhaThau thau);
        public bool Remove(string id);
        public bool Update(NhaThau thau);

    }
}
