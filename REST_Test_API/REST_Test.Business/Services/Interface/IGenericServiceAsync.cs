namespace REST_Test.Business.Services.Interface
{
    public interface IGenericServiceAsync<TEntity, TDTO> : IReadServiceAsync<TEntity, TDTO>
           where TEntity : class
           where TDTO : class
    {
        Task AddAsync(TDTO dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(TDTO dto);
    }
}
