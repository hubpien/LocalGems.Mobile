


namespace LocalGems.Services
{
    public interface IDatabaseService
    {

        public IEnumerable<User> GetNewlyAddedUsers(string selectedUserTypes = null);

        public IEnumerable<User> GetRandomUsers(string selectedUserTypes = null);

        public IEnumerable<User> GetPopularUsers(string selectedUserTypes = null);

        public User GetUser(int userId);

        Task ToggleFavoritesAsync(int userId);
    }
}