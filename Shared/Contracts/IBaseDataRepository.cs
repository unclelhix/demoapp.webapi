namespace DemoApplication.WebAPI.Services
{
    public interface IBaseDataRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(long id);
        Task<bool> Add(TEntity transportEntity);
        Task<bool> Update(TEntity transportEntity);
    }
}
