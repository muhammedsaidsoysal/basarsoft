using harita.Abstract;
using harita.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace harita.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public Response<T> Add(T entity)
        {
            if (entity == null)
            {
                return Response<T>.ErrorResponse("Invalid data.");
            }

            _dbSet.Add(entity);
            _context.SaveChanges();

            return Response<T>.SuccessResponse(entity, $"{typeof(T).Name} added successfully.");
        }

        public Response<bool> Delete(long id)
        {
            var entity = _dbSet.Find(id);

            if (entity == null)
            {
                return Response<bool>.ErrorResponse($"{typeof(T).Name} not found.");
            }

            _dbSet.Remove(entity);
            _context.SaveChanges();

            return Response<bool>.SuccessResponse(true, $"{typeof(T).Name} deleted successfully.");
        }

        public Response<List<T>> GetAll()
        {
            var entities = _dbSet.ToList();

            return Response<List<T>>.SuccessResponse(entities, $"{typeof(T).Name}s retrieved successfully.");
        }

        public Response<T> GetById(long id)
        {
            var entity = _dbSet.Find(id);

            if (entity == null)
            {
                return Response<T>.ErrorResponse($"{typeof(T).Name} not found.");
            }

            return Response<T>.SuccessResponse(entity, $"{typeof(T).Name} retrieved successfully.");
        }

        public Response<T> Update(long id, T updatedEntity)
        {
            var entity = _dbSet.Find(id);

            if (entity == null)
            {
                return Response<T>.ErrorResponse($"{typeof(T).Name} not found.");
            }

            _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
            _context.SaveChanges();

            return Response<T>.SuccessResponse(entity, $"{typeof(T).Name} updated successfully.");
        }
    }
}
