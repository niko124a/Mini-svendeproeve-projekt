using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Common.Helpers;
using Database.Interfaces;
using Common.Entities;

namespace Website.Pages
{
    public partial class Register : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IUserRepository UserRepository { get; set; }
        [Inject]
        public PasswordHelper PasswordHelper { get; set; }

        bool success;
        string[] errors = { };
        MudTextField<string> usernameField;
        MudTextField<string> passwordField;
        MudForm form;

        private async Task RegisterUser()
        {
            string username = usernameField.Value;
            string password = passwordField.Value;
            string hash = PasswordHelper.HashPasword(password, out var salt);

            User dbUser = UserRepository.GetUserByUsername(username);

            if (dbUser != null)
            {
                // a user with the given username already exists. Display a message to the user.
                return;
            }

            User newUser = new User()
            {
                Username = username,
                Password = hash,
                Salt = Convert.ToHexString(salt),
                IsLoggedIn = false
            };

            UserRepository.Insert(newUser);

            NavigationManager.NavigateTo("login");
        }

        private IEnumerable<string> PasswordStrength(string pw)
        {
            if (string.IsNullOrWhiteSpace(pw))
            {
                yield return "Password is required!";
                yield break;
            }
            if (pw.Length < 8)
                yield return "Password must be at least of length 8";
            if (!Regex.IsMatch(pw, @"[A-Z]"))
                yield return "Password must contain at least one capital letter";
            if (!Regex.IsMatch(pw, @"[a-z]"))
                yield return "Password must contain at least one lowercase letter";
            if (!Regex.IsMatch(pw, @"[0-9]"))
                yield return "Password must contain at least one digit";
        }

        private string PasswordMatch(string arg)
        {
            if (passwordField.Value != arg)
                return "Passwords don't match";
            return null;
        }
    }
}
