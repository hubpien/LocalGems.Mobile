using LocalGems.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGems.Repository
{
    public class UsersRepository
    {
        private ObservableCollection<User> users;

        public ObservableCollection<User> Users
        {
            get { return users; }
            set { this.users = value; }
        }

        public UsersRepository()
        {
            GenerateUserInfo();
        }

        internal void GenerateUserInfo()
        {
            Users = new ObservableCollection<User>();
            users.Add(new User() { Name = "Object-Oriented Programming in C#", Description = "Object-oriented programming is a programming paradigm based on the concept of objects" });
            users.Add(new User() { Name = "C# Code Contracts", Description = "Code Contracts provide a way to convey code assumptions" });
            users.Add(new User() { Name = "Machine Learning Using C#", Description = "You will learn several different approaches to applying machine learning" });
            users.Add(new User() { Name = "Neural Networks Using C#", Description = "Neural networks are an exciting field of software development" });
            users.Add(new User() { Name = "Visual Studio Code", Description = "It is a powerful tool for editing code and serves for end-to-end programming" });
            users.Add(new User() { Name = "Android Programming", Description = "It provides a useful overview of the Android application life cycle" });
            users.Add(new User() { Name = "iOS Succinctly", Description = "It is for developers looking to step into frightening world of iPhone" });
            users.Add(new User() { Name = "Visual Studio 2015", Description = "The new version of the widely-used integrated development environment" });
            users.Add(new User() { Name = "Xamarin.Forms", Description = "It creates mappings from its C# classes and controls directly" });
            users.Add(new User() { Name = "Windows Store Apps", Description = "Windows Store apps present a radical shift in Windows development" });
        }
    }
}
