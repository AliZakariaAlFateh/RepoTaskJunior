namespace Task_Junior.Services
{
    public interface IRepostory<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetByID(int Id);
        void Add(TEntity entity);
        void Delete(int Id);
        void Update(TEntity entity);
        void Save();
    }
}
