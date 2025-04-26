namespace WebApplicationEXAM_N1.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T newEntity, int id);
        void Delete(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByCondition(Func<T, bool> predicate);

    }
}
