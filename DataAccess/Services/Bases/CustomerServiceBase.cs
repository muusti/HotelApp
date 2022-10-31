using AppCore.DataAccsess.Services;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services.Bases
{
    public abstract class CustomerServiceBase : ServiceBase<Customer>
    {
        public CustomerServiceBase(Db db) : base(db)
        {
        }
    }
}
