namespace harita.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Response<T> Add(T entity);
        Response<T> GetById(long id);
        Response<List<T>> GetAll();
        Response<T> Update(long id, T updatedEntity);
        Response<bool> Delete(long id);
    }
}
