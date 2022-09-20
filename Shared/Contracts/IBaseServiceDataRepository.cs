using DemoApplication.WebAPI.Shared.Responses;

namespace DemoApplication.WebAPI.Shared.Contracts
{
    public interface IBaseServiceDataRepository<TEntity> where TEntity : class
    {
        Task<ServiceResponse<IEnumerable<TEntity>>> GetAll();
        Task<ServiceResponse<TEntity>> GetById(long id);
        Task<ServiceResponse<bool>> Add(TEntity transportEntity);
        Task<ServiceResponse<bool>> Update(TEntity transportEntity);
    }
}
