namespace REST_Test.Business.Services.Interface
{
    public interface IReadServiceAsync<TEntity, TDTO> 
        where TEntity : class 
        where TDTO : class
    {
        Task<IEnumerable<TDTO>> GetAllAsync();
        Task<TDTO> GetAsync(int id);
    }
}
