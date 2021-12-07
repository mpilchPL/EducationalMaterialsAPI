using System.Security.Claims;

namespace EducationalMaterialsAPI.Logger.Extensions
{
    public static class LoggerExt
    {
        public static void LogInfo<T>(this ILogger<T> logger, ClaimsPrincipal? user, string action)
        {
            if(user == null)
            {
                logger.LogInformation($"[unauthorized] Action: {action}");
            }
            else
            {
                logger.LogInformation($"[UserName: {user.Identity.Name} | Admin: {user.IsInRole("Admin")}] Action: {action}");
            }
        }
    }
}
