using System.Linq.Expressions;

namespace EducationalMaterialsAPI.Data.Repository
{
    public interface IRepo<Type> where Type : class
    {
        public Task<ICollection<Type>> GetAll();
        public Task<ICollection<Type>> GetAll(Expression<Func<Type, bool>> predicate);
        public Task<Type> Get(int id);
        public Task Delete(Type type);
        public Task Add(Type type);
        public Task Update(Type type);
        public Task SaveChanges();
    }
}
