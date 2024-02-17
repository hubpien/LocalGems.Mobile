using LocalGems.Models;
using System.Collections.ObjectModel;

namespace LocalGems.Services
{
    public interface IDatabaseService
    {

        public ObservableCollection<User> GetUsers(string selectedUserTypes = null);

        public ObservableCollection<User> GetUser(Guid userId);

        

    }
}