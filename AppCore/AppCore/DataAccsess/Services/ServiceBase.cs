using Microsoft.EntityFrameworkCore;
using AppCore.Records.Bases;
using System.Linq.Expressions;
using AppCore.DataAccsess.Results.Bases;
using AppCore.DataAccsess.Results;

namespace AppCore.DataAccsess.Services
{

    public abstract class ServiceBase<TEntity> : IDisposable where TEntity : RecordBase, new()
    {
        protected readonly DbContext _dbContext;


        const string _errorMessage = "Changes not saved!";

        protected ServiceBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public virtual IQueryable<TEntity> Query()
        {
            return _dbContext.Set<TEntity>();
        }

        public virtual List<TEntity> GetList()
        {
            return Query().ToList();
        }

        public virtual async Task<List<TEntity>> GetListAsync()
        {
            return await Query().ToListAsync();
        }

        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return Query().Where(predicate).ToList();
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Query().Where(predicate).ToListAsync();
        }

        public virtual TEntity? GetItem(int id)
        {

            return Query().SingleOrDefault(q => q.Id == id);
        }

        public virtual Result Add(TEntity entity, bool save = true)
        {
            _dbContext.Set<TEntity>().Add(entity);
            if (save)
            {
                Save();
                return new SuccessResult("Added Successfully.");
            }

            return new ErrorResult(_errorMessage);
        }

        public virtual Result Update(TEntity entity, bool save = true)
        {
            _dbContext.Set<TEntity>().Update(entity);
            if (save)
            {
                Save();
                return new SuccessResult("Updated Successfully.");
            }

            return new ErrorResult(_errorMessage);
        }

        public virtual Result Delete(TEntity entity, bool save = true)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            if (save)
            {
                Save();
                return new SuccessResult("Deleted successfully.");
            }

            return new ErrorResult(_errorMessage);

        }

        public virtual Result Delete(Expression<Func<TEntity, bool>> predicate, bool save = true)
        {
            var entities = Query().Where(predicate).ToList();
            foreach (var entity in entities)
            {
                Delete(entity, false);
            }
            if (save)
            {
                Save();
                return new SuccessResult("Deleted Successfully.");
            }

            return new ErrorResult(_errorMessage);
        }
        public virtual int Save()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
