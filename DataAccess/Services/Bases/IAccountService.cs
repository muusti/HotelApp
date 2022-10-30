using AppCore.DataAccsess.Results.Bases;
using DataAccess.Entities;
using DataAccess.Models;

namespace DataAccess.Services.Bases
{
    public interface IAccountService
    {
        User Login(AccountLoginModel mdoel);
        Result Register(AccountRegisterModel model);
    }
}
