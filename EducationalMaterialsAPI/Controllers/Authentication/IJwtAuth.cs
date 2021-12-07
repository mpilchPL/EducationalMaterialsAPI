using EducationalMaterialsAPI.Data.Repository.Users;

namespace EducationalMaterialsAPI.Controllers.Authentication
{
    public interface IJwtAuth
    {
        public Task<string> Authentication(string username, string password, IUsersRepo usersRepo);
    }
}
