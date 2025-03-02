namespace DP.Services.Interfaces
{
    public interface IValidationService
    {
        Task CheckUserExistsAsync(string userId);
        Task CheckUserExistsAndEnabledAsync(string userId);
        Task CheckUsernameExistsAsync(string username);
        bool CheckPasswordMatchHash(string password, string passwordHash);
        (bool exists, string suggestedUsername) CheckUsernameExists(string username);
    }
}
