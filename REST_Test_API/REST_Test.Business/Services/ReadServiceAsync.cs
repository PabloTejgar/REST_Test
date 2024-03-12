using AutoMapper;
using REST_Test.Business.Services.Interface;
using REST_Test.Model.Repositories;

namespace REST_Test.Business.Services
{
    public class ReadServiceAsync<TEntity, TDTO> : IReadServiceAsync<TEntity, TDTO>
            where TEntity : class
            where TDTO : class
    {
        private readonly IGenericRepository<TEntity> repository;
        private readonly IMapper automapper;

        public ReadServiceAsync(IGenericRepository<TEntity> genRepository, IMapper mapper) : base()
        {
            repository = genRepository;
            automapper = mapper;
        }


        public async Task<IEnumerable<TDTO>> GetAllAsync()
        {
            try
            {
                var result = await repository.GetAllAsync();

                if (result.Any())
                {
                    return automapper.Map<IEnumerable<TDTO>>(result);
                }
                else
                {
                    throw new NotImplementedException("Needs to catch concrete exception.");
                }

            }
            catch (NotImplementedException ex)
            {
                var message = $"Error retrieving all {typeof(TDTO).Name}s";

                throw new NotImplementedException("Needs to catch concrete exception.");
            }
        }

        public async Task<TDTO> GetAsync(int id)
        {
            try
            {
                var result = await repository.GetAsync(id);

                if (result is null)
                {
                    throw new NotImplementedException("Needs to catch concrete exception.");
                }

                return automapper.Map<TDTO>(result);
            }

            catch (NotImplementedException ex)
            {
                var message = $"Error retrieving {typeof(TDTO).Name} with Id: {id}";

                throw new NotImplementedException(message, ex);
            }
        }
    }
}
