using LocalGems.Models;
using Bogus;
using System.Collections.ObjectModel;
using LocalGems.ViewModels;


namespace LocalGems.Services
{
    public class DatabaseService : IDatabaseService
    {
        private Faker<User> fakerUser;
        private List<User> _users;

        public DatabaseService()
        {
            _users = GenerateFakeUsers(22);
        }

        public List<User> GenerateFakeUsers(int numberOfUsers)
        {
            Randomizer.Seed = new Random(8675309);
            var fakerCustomMarker = new Faker<CustomMarker>()
               .RuleFor(u => u.Name, f => f.Address.StreetAddress())
               .RuleFor(u => u.Description, f => f.Company.Bs());

            var userId = 1;
            fakerUser = new Faker<User>()
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.Description, f => f.Lorem.Lines(2))
                .RuleFor(u => u.Category, f => f.Lorem.Word())
                .RuleFor(u => u.Image, f => f.Internet.Avatar())
                .RuleFor(u => u.Type, f => f.PickRandom(new UserType[]
                {
                   new UserType("Jewelery"),
                   new UserType("Art"),
                   new UserType("Food"),
                }))
                .RuleFor(u => u.Location, f => fakerCustomMarker.Generate());

            return fakerUser.Generate(numberOfUsers);
        }

        public ObservableCollection<User> GetUser(Guid userId)
        {
            return new ObservableCollection<User>(_users.Where(x => x.Id == userId));
        }

        public ObservableCollection<User> GetUsers(string selectedUserTypes)
        {
             

            if (selectedUserTypes != null)
            {
                var users = _users
                    .Where( u => selectedUserTypes == u.Type.Value)
                    .ToList(); 
                return new ObservableCollection<User>(users);
            }

            return new ObservableCollection<User>(_users);
        }

        public void AddUsers(List<User> usersToAdd)
        {
            _users.AddRange(usersToAdd);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }
    }
}
