using AutoMapper;
using REST_Test.Business.Services.Interface;
using REST_Test.Model.Repositories;

namespace REST_Test.Business.Services
{
    public class GenericServiceAsync<TEntity, TDto> : ReadServiceAsync<TEntity, TDto>, IGenericServiceAsync<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        private readonly IGenericRepository<TEntity> repository;
        private readonly IMapper automapper;


        public GenericServiceAsync(IGenericRepository<TEntity> genRepository, IMapper mapper) : base(genRepository, mapper)
        {
            repository = genRepository;
            automapper = mapper;
        }

        public async Task AddAsync(TDto dto)
        {
            await repository.CreateAsync(automapper.Map<TEntity>(dto));
            await repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await repository.RemoveAsync(id);
            await repository.SaveAsync();
        }

        public async Task UpdateAsync(TDto dto)
        {
            var entity = automapper.Map<TEntity>(dto);
            await repository.UpdateAsync(entity);
            await repository.SaveAsync();
        }
    }

}
