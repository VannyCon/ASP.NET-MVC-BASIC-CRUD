using CRUD.Models;
namespace CRUD.Sessions
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        public AccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserAccount Login(string email, string pass)
        {
            return _context.UserAccount.SingleOrDefault(u => u.Email_Account == email && u.Password == pass);
        }
    }
}
