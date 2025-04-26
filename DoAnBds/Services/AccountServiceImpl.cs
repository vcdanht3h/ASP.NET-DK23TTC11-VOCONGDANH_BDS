using DoAnBds.Models;

namespace DoAnBds.Services
{
    public class AccountServiceImpl : AccountService
    {
        private DatabaseContext db;
        public AccountServiceImpl(DatabaseContext _db)
        {
            this.db = _db;
        }

        public bool Login(string username, string password)
        {
            var account = db.PhanQuyens.SingleOrDefault(x => x.Username == username);
            if (account != null && account.Password == password)
            {
                /*return BCrypt.Net.BCrypt.Verify(password, account.Password);*/
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
