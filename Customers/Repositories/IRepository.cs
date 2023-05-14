namespace Customers.Repositories
{
    public interface IRepository<TEntity>
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Create(TEntity customer);
        void Update(TEntity customer, TEntity updatedCustomer);
        void Delete(TEntity customer);
    }
}
