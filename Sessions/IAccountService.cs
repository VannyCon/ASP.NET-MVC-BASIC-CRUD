using CRUD.Models;
namespace CRUD.Sessions

{

    public interface IAccountService
    {
        public UserAccount Login(string Email_Account, string Password);
    }
}