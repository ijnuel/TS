using Core.Entities;
using Core.Helpers;

namespace Services.BaseServices
{
    public interface IBaseService
    {
        Task<List<TDto>> GetAll<TDto, TEntity>();
        Task<TDto> GetById<TDto, TEntity>(Guid id);
        Task<bool> Create<TCreateRequest, TEntity>(TCreateRequest entityRequest) where TEntity : BaseEntity;
        Task<bool> Update<TUpdateRequest, TEntity>(TUpdateRequest entityRequest) where TEntity : BaseEntity;
    }
}