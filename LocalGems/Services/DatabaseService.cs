using LocalGems.Models;
using Bogus;
using System.Collections.ObjectModel;
using LocalGems.ViewModels;
using System.Collections.Generic;
using Bogus.DataSets;

namespace LocalGems.Services
{
    public class DatabaseService : IDatabaseService
    {
        private Faker<CustomMarker> fakerCustomMarker;
        private Faker<Product> productFaker;
        private Faker<User> fakerUser;
        private List<User> _users;

        public DatabaseService()
        {
            _users = GenerateFakeUsers(22);
        }

        public List<User> GenerateFakeUsers(int numberOfUsers)
        {
            Randomizer.Seed = new Random(8675309);

            fakerCustomMarker = new Faker<CustomMarker>()
               .RuleFor(u => u.Name, f => f.Address.StreetAddress())
               .RuleFor(u => u.Description, f => f.Company.Bs());

             productFaker = new Faker<Product>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductAdjective())
                .RuleFor(p => p.Tags, f => f.Commerce.Categories(5))
                .RuleFor(p => p.ImageUrl, f => f.Image.PicsumUrl());

            var userIds = 0;
            fakerUser = new Faker<User>()
                .RuleFor(u => u.Id, f => userIds++)
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.Description, f => f.Lorem.Lines(2))
                .RuleFor(u => u.Category, f => f.Lorem.Word())
                .RuleFor(u => u.Image, f => f.Image.PicsumUrl())
                .RuleFor(u => u.Views, f => f.Random.Number(50, 1000))
                .RuleFor(u => u.IsFavorite, f => f.Random.Bool())
                .RuleFor(u => u.Type, f => f.PickRandom(new UserType[]
                {
                   new UserType("Jewelery"),
                   new UserType("Art"),
                   new UserType("Food"),
                }))
                .RuleFor(u => u.Location, (f,u) =>
                {
                    if (u.Location == null)
                    {
                        u.Location = new List<CustomMarker>();
                    }
                    u.Location.AddRange(fakerCustomMarker.GenerateBetween(1, 4));
                    return u.Location;
                })
                .RuleFor(u => u.Products, (f,u) =>
                {
                    if (u.Products == null)
                    {
                        u.Products = new List<Product>();
                    }
                    u.Products.AddRange(productFaker.GenerateBetween(5, 15));
                    return u.Products;
                }
            );

            return fakerUser.Generate(numberOfUsers);
        }

        public User GetUser(int userId)
        {
            return _users.FirstOrDefault(x => x.Id == userId);
        }

        public User GetUser()
        {
            return _users.FirstOrDefault();
        }

        public IEnumerable<User> GetNewlyAddedUsers(string selectedUserTypes = null)
        {
            return _users
                .OrderByDescending(p => p.Id)
                .Take(6)
                .ToList();
                    
        }

        public IEnumerable<User> GetPopularUsers(string selectedUserTypes = null)
        {

            return _users
                .OrderByDescending(p => p.Views)
                .Take(6)
                .ToList();

        }

        public IEnumerable<User> GetRandomUsers(string selectedUserTypes = null)
        {

            return _users
                 .OrderByDescending(_ => Guid.NewGuid())
                 .Take(6)
                 .ToList();

        }



        public void AddUsers(List<User> usersToAdd)
        {
            _users.AddRange(usersToAdd);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public User ToggleFavoritesAsync(int userId)
        {
            var user = GetUser(userId);

            if (user != null)
            {
                user.IsFavorite = !user.IsFavorite;
            }
            return user;
        }

        public IEnumerable<User> GetUserFavoritesAsync()
        {
            return _users.Where(x => x.IsFavorite == true);
        }
    }

    

}
