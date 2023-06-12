using AutoMapper;
using Core.Entities;
using Core.Helpers;
using Repositories.BaseRepositories;

namespace Services.BaseServices
{
    public class BaseService : IBaseService
    {
        private readonly IBaseRepository _baseRepo;
        private readonly IMapper _mapper;
        public BaseService(IBaseRepository baseRepo, IMapper mapper)
        {
            _baseRepo = baseRepo;
            _mapper = mapper;
        }

        public async Task<List<TDto>> GetAll<TDto, TEntity>()
        {
            var result = await _baseRepo.GetAll<TEntity>();
            return _mapper.Map<List<TDto>>(result);
        }

        public async Task<TDto> GetById<TDto, TEntity>(Guid id)
        {
            var result = await _baseRepo.GetById<TEntity>(id);
            return _mapper.Map<TDto>(result);
        }

        public async Task<bool> Create<TCreateRequest, TEntity>(TCreateRequest entityRequest) where TEntity : BaseEntity
        {
            var entity = _mapper.Map<TEntity>(entityRequest);
            if (entity != null)
            {
                entity.Id = Guid.NewGuid();
                var columns = EntityHelper.GetColumns<TEntity>();
                var value = EntityHelper.GetValue(entity);
                return await _baseRepo.Insert<TEntity>(columns, new List<List<string>> { value });
            }
            return false;
        }

        public async Task<bool> Update<TUpdateRequest, TEntity>(TUpdateRequest entityRequest) where TEntity : BaseEntity
        {
            var entity = _mapper.Map<TEntity>(entityRequest);
            if (entity != null)
            {
                var columnsValue = EntityHelper.GetColumnsValue(entity);
                return await _baseRepo.Update<TEntity>(entity.Id, columnsValue);
            }
            return false;
        }
    }
}
