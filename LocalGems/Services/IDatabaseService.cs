



namespace LocalGems.Services
{
    public interface IDatabaseService
    {

        public IEnumerable<User> GetNewlyAddedUsers(string selectedUserTypes = null);

        public IEnumerable<User> GetRandomUsers(string selectedUserTypes = null);

        public IEnumerable<User> GetPopularUsers(string selectedUserTypes = null);

        public User GetUser(int userId);

        public User GetUser();

        User ToggleFavoritesAsync(int userId);

        IEnumerable<User> GetAllUsers();

        IEnumerable<User> GetUserFavoritesAsync();
    }
}