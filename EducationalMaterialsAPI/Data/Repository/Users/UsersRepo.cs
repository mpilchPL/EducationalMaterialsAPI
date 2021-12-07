using EducationalMaterialsAPI.Data.DAL;
using EducationalMaterialsAPI.Model.User;
using Microsoft.EntityFrameworkCore;

namespace EducationalMaterialsAPI.Data.Repository.Users
{
    public class UsersRepo : IUsersRepo
    {
        private readonly UsersDbContext _context;
        public UsersRepo(UsersDbContext context)
        {
            _context = context;
        }
        public async Task Add(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> Get(int id) => await _context.Users.FindAsync(id);

        public async Task<User> Get(string username, string password) 
        {
            return await _context.Users.Where(u => u.Name == username && u.Password == password).FirstOrDefaultAsync();
        }

        public async Task<ICollection<User>> GetAll() => await _context.Users.ToListAsync();
    }
}
