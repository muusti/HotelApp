using Microsoft.EntityFrameworkCore;
using AppCore.Records.Bases;
using System.Linq.Expressions;
using AppCore.DataAccsess.Results.Bases;
using AppCore.DataAccsess.Results;

namespace AppCore.DataAccsess.Services
{
    // new ServiceBase <Oyun>();
    // new ServiceBase <Urun>();
    // new ServiceBase <int>();
    // new ServiceBase <string>();

    //Repository Pattern
    //                                         : IDisposable interface
    public abstract class ServiceBase<TEntity> : IDisposable where TEntity : RecordBase, new()  //  where TEntity : RecordBase, new() => TEntity parametresine sacede newlene bilen class veri tipleri ve RecordBase clasından miras alan classlar  gönderilebilir
    {
        protected readonly DbContext _dbContext; //DbContext Base classdır bütün veri tabanı işlenmlerini bu class üzerinden işlem yaparız
        //Her yerde kullanılılcak objeleri newlemek yerine dependyInjection ile obje göndermemiz gerekir


        const string _errorMessage = "Changes not saved!";

        protected ServiceBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // ServiceBase _service = new ServiceBase<Katagorei>();
        //_service.Query();
        public virtual IQueryable<TEntity> Query()// Sadece sorguyu oluşturur çağırmaz /* bu Kodun SQL deki Karşılığı Select * from Tablo Adı (TEntity) "bu sorgu bütün verileri getirir" */
        {
            return _dbContext.Set<TEntity>();
        }

        public virtual List<TEntity> GetList()// ToList() oluşturulan sorguyu çalıştırır 
        {
            return Query().ToList();
        }

        public virtual async Task <List<TEntity>> GetListAsync()
        {
            return await Query().ToListAsync();
        }

        //db.Oyunlar.where(oyun => oyun.Adi == "RDR 2").ToList();
        public virtual List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)// Func delege çeşididir 
        {
            return Query().Where(predicate).ToList();
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)// Func delege çeşididir 
        {
            return await Query().Where(predicate).ToListAsync(); 
        }

        public virtual TEntity? GetItem(int id)
        {
            // Methodun sonunda OrDefault var ise kayıt bulamadığı zaman null döner 
            //Methodun sonunda OrDefault yok ise kayıt bulamadığı zaman hata fırlatır  

            return Query().SingleOrDefault(q => q.Id == id);// koşula uyan kayıtı bulamaz ise null döner // tek obje döner// birden fazla kayıot bulursa hata fırlatır 

            //return Query().Find(id); // Sadece DbSet tipindeki koleksiyonlarda kullanılabilir.
            //return Query().Single(q => q.Id == id);// Single de koşula uyan kayıt bulamaz ise hata fırlatır // tek obje döner 
            //return Query().FirstOrDefault(q => q.Id == id);// koşula birden fazla uyan kayıt var ise ilk bulduğu kayıtı döner// kayıt bulamaz ise null döner
            //return Query().LastOrDefault(q => q.Id == id);// Koşula birden falza uyan kayıt varsa en son kayıtı getirir
            //return Query().First(q => q.Id == id);//
            //return Query().Last(q => q.Id == id);// koşula uymuyorsa hata fırlatır

        }

        //Db.Oyunlar.Add(oyun);
        // return new SuccessResult();
        // return new ErrorResult ("Gta V adına oyun mevcuttur!");

        public virtual Result Add(TEntity entity, bool save = true)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            if (save) // save false olduğu zaman değişikliği veri tabanına kaydetmez sadece obje üzerinde değişiklik yapar 
            {
                Save();// objedeki değişikleri tek sefer de yazabilmek için bool veri tipi tanımladık birden fazla işlem yapacaksak değişiklikleri yaptıkdan sonra tek bir sefer save methodu çağırarak performanstan tasarruf etmiş oluruz 
                return new SuccessResult("Added Successfully.");
            }

            return new ErrorResult(_errorMessage);
        }

        public virtual Result Update(TEntity entity, bool save = true)
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
            if (save) // save false olduğu zaman değişikliği veri tabanına kaydetmez sadece obje üzerinde değişiklik yapar 
            {
                Save();// objedeki değişikleri tek sefer de yazabilmek için bool veri tipi tanımladık birden fazla işlem yapacaksak değişiklikleri yaptıkdan sonra tek bir sefer save methodu çağırarak performanstan tasarruf etmiş oluruz 
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

        public virtual Result Delete(Expression<Func<TEntity, bool>> predicate, bool save = true) // Delete (e => e.Id ==5), service.Delete(e => eMarkasi =="Auidi"); 
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
                return _dbContext.SaveChanges(); //_dbContext.SaveChangesAsync(); ASenkron demek
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public void Dispose()
        {
            _dbContext?.Dispose(); // eğer null değil ise çalışır
            GC.SuppressFinalize(this);
        }
    }
}
