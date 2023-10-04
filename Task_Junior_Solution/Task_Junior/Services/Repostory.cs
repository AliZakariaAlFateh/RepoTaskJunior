using Task_Junior.Models;

namespace Task_Junior.Services
{
    public class Repostory<TEntity> : IRepostory<TEntity> where TEntity : class
    {
        private readonly DataContext db;
        public Repostory(DataContext _db)
        {
            this.db = _db;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity GetByID(int Id)
        {
            return db.Set<TEntity>().Find(Id);
        }

        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }

        public void Delete(int Id)
        {
            var entity = db.Set<TEntity>().Find(Id);
            if (entity != null)
                db.Set<TEntity>().Remove(entity);
        }
        public void Update(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
        }
        public void Save()
        {
            
            db.SaveChanges();
        }
        

        
    }
}
