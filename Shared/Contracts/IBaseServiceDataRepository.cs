using DemoApplication.WebAPI.Shared.Responses;

namespace DemoApplication.WebAPI.Shared.Contracts
{
    public interface IBaseServiceDataRepository<TEntity> where TEntity : class
    {
        Task<PagingResponse<TEntity>> GetAll(PagingRequest request);
        Task<ServiceResponse<TEntity>> GetById(long id);
        Task<ServiceResponse<bool>> Add(TEntity transportEntity);
        Task<ServiceResponse<bool>> Update(TEntity transportEntity);
    }
}
