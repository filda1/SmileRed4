using Rg.Plugins.Popup.Services;
using smileRed4.Domain;
using smileRed4.Helpers;
using smileRed4.Models;
using smileRed4.Services;
using smileRed4.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace smileRed4.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
     
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private bool isRunning;
        private bool isEnabled;
        private ImageSource imageSource;
        
        #endregion

        #region Properties
        public ImageSource ImageSource
        {
            get { return this.imageSource; }
            set { SetValue(ref this.imageSource, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Telephone
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public string Confirm
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string Location
        {
            get;
            set;
        }

        public int Code
        {
            get;
            set;
        }

        public int Door
        {
            get;
            set;
        }

        public string PlaceLabel
        {
            get;
            set;
        }
        public Command MapsCommand { get; }
        public Command AddressCommand { get; }
        #endregion

        #region Constructors
        public RegisterViewModel()
        {
            //string session_Place = (Application.Current.Properties["Place"].ToString());
            //Application.Current.Properties.Clear();
            //Application.Current.Properties["Place"] = null;
            this.apiService = new ApiService();
            this.IsEnabled = true;
            MapsCommand = new Command(Ubications);
            AddressCommand = new Command(FullAddress);
            //this.ImageSource = "Camera";
            //this.PlaceLabel = session_Place;


        }
        #endregion

        #region Commands
        private async void FullAddress()
        {
            this.IsEnabled = false;
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.FullAddress = new AddressViewModel();
            await PopupNavigation.Instance.PushAsync(new FullAddress());
        }

        private async void Ubications()
        {
            this.IsEnabled = false;       
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Ubications = new UbicationsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new UbicationsView());           
        }

        public Command RegisterCommand
        {
            get
            {
                return new Command(Register);
            }
        }

        private async void Register()
        {
            if (string.IsNullOrEmpty(this.FirstName))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.FirstNameValidation,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(this.LastName))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.LastNameValidation,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept);
                return;
            }


            if (!RegexUtilities.IsValidEmail(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                     Languages.Error,
                     Languages.EmailValidation2,
                     Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(this.Telephone))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PhoneValidation,
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

            if (this.Password.Length < 6)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PasswordValidation2,
                    Languages.Accept);
                return;

            }

            if (string.IsNullOrEmpty(this.Confirm))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.ConfirmValidation,
                    Languages.Accept);
                return;
            }

            if (this.Password != this.Confirm)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.ConfirmValidation2,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(this.Address))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.AddressValidation,
                    Languages.Accept);
                return;
            }

            if (this.Code == 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.CodePostalValidation,
                    Languages.Accept);
                return;
            }

            if (this.Door == 0)
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.DoorValidation,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(this.Location))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.LocationValidation,
                    Languages.Accept);
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

             var checkConnetion = await this.apiService.CheckConnection();

             if (!checkConnetion.IsSuccess)
             {
                 this.IsRunning = false;
                 this.IsEnabled = true;
                 await Application.Current.MainPage.DisplayAlert(
                     Languages.Error,
                     checkConnetion.Message,
                     Languages.Accept);
                return;

             }
          
            // EXISTS EMAIL
           /* var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            var username = await this.apiService.GetEmailExists(
              apiSecurity,         
                 "/api",
                 "/Users/GetEmailExists",
                 this.Email);

            NumberRequest number2 = new NumberRequest();
            number2.Number = username.Number;
          
            if (number2.Number == 1)
            {
                await Application.Current.MainPage.DisplayAlert(
                   Languages.Error,
                   Languages.EmailExists,
                   Languages.Accept);
                
                this.IsRunning = false;
                this.IsEnabled = true;
                this.Email = string.Empty;
                return;
            }
           
                /*byte[] imageArray = null;
                if (this.file != null)
                {
                    imageArray = FilesHelper.ReadFully(this.file.GetStream());
                }*/

                //REGISTER USERS
                var user = new User
             {
                 TypeofUserId = 2,
                 Email = this.Email,
                 FirstName = this.FirstName,
                 LastName = this.LastName,
                 Telephone = this.Telephone,
                 ImageArray = null,
                 ImagePath = null,
                 ImageFullPath = "noimage",
                 Passwords = this.Password,
                 Password = this.Password,
                 Address = this.Address,
                 Location = this.Location,
                 Code = this.Code,
                 Door = this.Door,
                 FullName = this.FirstName + "" + this.LastName,
                 Active = true,
              };

            var apiSecurity = Application.Current.Resources["APISecurity"].ToString();
            var response = await this.apiService.Post(
                 apiSecurity,
                 "/api",
                 "/Users",
                 user);

            if (!response.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    response.Message,
                    Languages.Accept);
                return;
            }

            this.IsRunning = false;
             this.IsEnabled = true;

             await Application.Current.MainPage.DisplayAlert(
                    Languages.ConfirmLabel,
                    Languages.UserRegisteredMessage,
                    Languages.Accept);
            await Application.Current.MainPage.Navigation.PopAsync();
             }

        /* public Command ChangeImageCommand
             {
               get
               {
                 return new Command(ChangeImage);
               }
             }

         private async void ChangeImage()
         {
             await CrossMedia.Current.Initialize();

             if (CrossMedia.Current.IsCameraAvailable &&
               CrossMedia.Current.IsTakePhotoSupported)
             {
                 var source = await Application.Current.MainPage.DisplayActionSheet(
                     "Onde você quer tirar a imagen?",
                     "Cancelar",
                     null,
                     "Da galeria",
                     "Da câmera");

                 if (source == "Cancelar")
                 {
                     this.file = null;
                     return;
                 }

                 if (source == "Da câmera")
                 {
                     this.file = await CrossMedia.Current.TakePhotoAsync(
                         new StoreCameraMediaOptions
                         {
                             Directory = "Sample",
                             Name = "test.jpg",
                             PhotoSize = PhotoSize.Small,
                         }
                     );
                 }
                 else
                 {
                     this.file = await CrossMedia.Current.PickPhotoAsync();
                 }
             }
             else
             {
                 this.file = await CrossMedia.Current.PickPhotoAsync();
             }

             if (this.file != null)
             {
                 this.ImageSource = ImageSource.FromStream(() =>
                 {
                     var stream = file.GetStream();
                     return stream;
                 });
             }*/
    }
    #endregion
}



