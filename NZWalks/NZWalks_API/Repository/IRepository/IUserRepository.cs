namespace NZWalks_API.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<bool> AuthenticateUser(string username, string password);
    }
}
