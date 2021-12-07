using EducationalMaterialsAPI.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EducationalMaterialsAPI.Data.Repository
{
    public class Repo<Type> : IRepo<Type> where Type : class
    {
        private readonly EduMaterialsContext _context;
        public Repo(EduMaterialsContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Type>> GetAll() => await _context.Set<Type>().ToListAsync();

        public async Task<ICollection<Type>> GetAll(Expression<Func<Type, bool>> predicate)
        {
            return await _context.Set<Type>().Where(predicate).ToListAsync();
        }

        public async Task<Type> Get(int id) => await _context.Set<Type>().FindAsync(id);
        public async Task Add(Type type)
        {
            await _context.Set<Type>().AddAsync(type);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Type type)
        {
            _context.Set<Type>().Remove(type);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Type type)
        {
            await _context.SaveChangesAsync();
        }

        public async Task SaveChanges() => await _context.SaveChangesAsync();
    }
}
