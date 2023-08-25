using MyPocketAPP.Resx;
using MyPocketAPP.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;


namespace MyPocketAPP.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _login;
        private string _password;
        private string _errorMessage;

        public string Login { get => _login; set => SetProperty(ref _login, value); }
        public string Password { get => _password; set=> SetProperty(ref _password, value); }
        public string ErrorMessage { get => _errorMessage; set=> SetProperty(ref _errorMessage, value); }

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            if (ValidateFields())
            {
                await Shell.Current.GoToAsync($"//{nameof(PocketsPage)}");
            }            
        }

        private bool ValidateFields()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(Login))
            {
                ErrorMessage = AppMessages.LoginPage_EmptyLogin;
                return false;
            }

            if (Login.All(Char.IsLetter))
            {
                //User loged with email

            }
            else
            {
                //User loged with phone
                if (Login.Length != 10)
                {
                    ErrorMessage = AppMessages.LoginPage_InvalidPhoneFormat;
                    return false;
                }
            }

            if (string.IsNullOrEmpty(Password))
            {
                ErrorMessage = AppMessages.LoginPage_EmptyPassword;
                return false;
            }

            return true;
        }
    }
}
