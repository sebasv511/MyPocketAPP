using MyPocketAPP.Resx;
using MyPocketAPP.Services;
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
        private readonly IAccountService _accountService;

        public LoginViewModel(IAccountService accountService)
        {
            _accountService = accountService;
            LoginCommand = new Command(OnLoginClicked);
        }

        private string _login = string.Empty;
        private string _password = string.Empty;
        private string _errorMessage = string.Empty ;

        public string Login { get => _login; set => SetProperty(ref _login, value); }
        public string Password { get => _password; set=> SetProperty(ref _password, value); }
        public string ErrorMessage { get => _errorMessage; set=> SetProperty(ref _errorMessage, value); }

        public Command LoginCommand { get; }

        private async void OnLoginClicked(object obj)
        {
            if (ValidateFields())
            {
                if (!await _accountService.LoginAsync(_login, _password))
                {
                    //_errorMessage = AppMessages.LoginPage_WrongCredentials;
                    await Application.Current.MainPage.DisplayAlert("", AppMessages.LoginPage_WrongCredentials, "Ok");                    
                    return;
                }

                await Shell.Current.GoToAsync($"//{nameof(PocketsPage)}");
            }            
        }

        private bool ValidateFields()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(Login))
            {
                //_errorMessage = AppMessages.LoginPage_EmptyLogin;
                Application.Current.MainPage.DisplayAlert("", AppMessages.LoginPage_EmptyLogin, "Ok");
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
                    //_errorMessage = AppMessages.LoginPage_InvalidPhoneFormat;
                    Application.Current.MainPage.DisplayAlert("", AppMessages.LoginPage_InvalidPhoneFormat, "Ok");
                    return false;
                }
            }

            if (string.IsNullOrEmpty(Password))
            {
                //_errorMessage = AppMessages.LoginPage_EmptyPassword;
                Application.Current.MainPage.DisplayAlert("", AppMessages.LoginPage_EmptyPassword, "Ok");
                return false;
            }

            return true;
        }
    }
}
