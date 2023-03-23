using System.Collections.Generic;
using System.Threading.Tasks;
using FinalExercise.Domain.Interfaces;
using FinalExercise.Data;
using Microsoft.EntityFrameworkCore;

namespace FinalExercise.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly FinalExerciseContext _context;

        protected GenericRepository(FinalExerciseContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
