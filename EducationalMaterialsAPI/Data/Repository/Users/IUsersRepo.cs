using EducationalMaterialsAPI.Model.User;

namespace EducationalMaterialsAPI.Data.Repository.Users
{
    public interface IUsersRepo
    {
        public Task Add(User user);
        public Task<User> Get(int id);
        public Task<User> Get(string username, string password);
        public Task<ICollection<User>> GetAll();
    }
}
