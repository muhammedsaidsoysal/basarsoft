using harita.Abstract;
using harita.Context;
using harita.Repositories;

namespace harita.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }
        public Response<bool> Commit()
        {
            try
            {
                int changes = _context.SaveChanges();
                return Response<bool>.SuccessResponse(true, $"{changes} changes saved successfully.", 200);
            }
            catch (Exception ex)
            {
                return Response<bool>.ErrorResponse($"An error occurred while saving changes: {ex.Message}", 500);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T);
            if (!_repositories.TryGetValue(type, out var repositoryInstance))
            {
                repositoryInstance = new GenericRepository<T>(_context);
                _repositories[type] = repositoryInstance;
            }
            return (IGenericRepository<T>)repositoryInstance;
        }


        public void Rollback()
        {
            throw new NotImplementedException("Rollback is not implemented. Use transactions if necessary.");
        }
    }
}
