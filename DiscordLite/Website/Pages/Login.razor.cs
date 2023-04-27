using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Database.Interfaces;
using Common.Helpers;
using Common.Entities;

namespace Website.Pages
{
    public partial class Login : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IUserRepository UserRepository { get; set; }
        [Inject]
        public PasswordHelper PasswordHelper { get; set; }

        bool success;
        MudTextField<string> usernameField;
        MudTextField<string> passwordField;

        private async Task LoginUser()
        {
            string username = usernameField.Value;
            string password = passwordField.Value;
            string hash = PasswordHelper.HashPasword(password, out var salt);

            User dbUser = UserRepository.GetUserByUsername(username);

            if (dbUser == null)
            {
                return;
            }

            bool verifiedPassword = PasswordHelper.VerifyPassword(password, hash, salt);

            if (!verifiedPassword)
            {
                return;
            }

            NavigationManager.NavigateTo("home");
        }

        private async Task NavigateToRegisterPage()
        {
            NavigationManager.NavigateTo("register");
        }
    }
}
