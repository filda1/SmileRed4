
using smileRed4.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using smileRed4.ViewModels;
using smileRed4.Helpers;
using smileRed4.Services;

namespace smileRed4.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        //private DataService dataService;
        #endregion

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        public object Navigation { get; private set; }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.apiService = new ApiService();
            //this.dataService = new DataService();
            this.IsRemembered = true;
            this.IsEnabled = true;
            LoginCommand = new Command(login);
            RegisterCommand = new Command(Register);

            { };
        }
        #endregion

        #region Commands
        private async void login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PasswordValidation,
                    Languages.Accept);
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    connection.Message,
                    Languages.Accept);
                return;
            }

            // TOKEN
            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            var token = await this.apiService.GetToken(
                apiSecurity,
                this.Email,
                this.Password);

            if (token == null)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.SomethingWrong,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(token.AccessToken))
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.LoginError,
                    Languages.Accept);
                this.Password = string.Empty;
                return;
            }

            // GET USER BY EMAIL
            var user = await this.apiService.GetUserByEmail(
              apiSecurity,
              "/api",
              "/Users/GetUserByEmail",
              token.TokenType,
              token.AccessToken,
              this.Email);

            //var userLocal = Converter.ToUserLocal(user);
            //userLocal.Password = this.Password;

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token;
            //mainViewModel.User = userLocal;

            /* if (this.IsRemembered)
             {
                 Settings.IsRemembered = "true";
             }
             else
             {
                 Settings.IsRemembered = "false";
             }*/

           /* this.dataService.DeleteAllAndInsert(userLocal);
            this.dataService.DeleteAllAndInsert(token);*/


            /*if (this.Email != "aga5@hotmail.com" || this.Password != "123")
            {
                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.LoginError,
                    Languages.Accept);

                this.Password = string.Empty;
                this.Email = string.Empty;
                return;
            }*/
            //var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Delivery = new DeliveryViewModel();       
            await Application.Current.MainPage.Navigation.PushAsync(new DeliveryPage());

            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;
        }

          private async void Register()
         {
            string infoPlace = "";
            var mainViewModel = MainViewModel.GetInstance();
             mainViewModel.Register = new RegisterViewModel();
             await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage(infoPlace));
    }
        #endregion
    }
}
