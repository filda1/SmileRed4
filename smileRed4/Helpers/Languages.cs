using System.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using smileRed4.Resources;
using smileRed4.Interfaces;

namespace smileRed4.Helpers
{
    
    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept
        {
            get { return Resource.Accept; }
        }

        public static string EmailValidation
        {
            get { return Resource.EmailValidation; }
        }

        public static string Error
        {
            get { return Resource.Error; }
        }

        public static string EmailPlaceHolder
        {
            get { return Resource.EmailPlaceHolder; }
        }

        public static string Rememberme
        {
            get { return Resource.Rememberme; }
        }

        public static string PasswordValidation
        {
            get { return Resource.PasswordValidation; }
        }

        public static string SomethingWrong
        {
            get { return Resource.SomethingWrong; }
        }

        public static string Login
        {
            get { return Resource.Login; }
        }

        public static string EMail
        {
            get { return Resource.EMail; }
        }

        public static string Password
        {
            get { return Resource.Password; }
        }

        public static string Forgot
        {
            get { return Resource.Forgot; }
        }

        public static string Register
        {
            get { return Resource.Register; }
        }

        public static string Search
        {
            get { return Resource.Search; }
        }
      
        public static string MyLanguages
        {
            get { return Resource.MyLanguages; }
        }

        public static string Menu
        {
            get { return Resource.Menu; }
        }

        public static string MyProfile
        {
            get { return Resource.MyProfile; }
        }

        public static string Statics
        {
            get { return Resource.Statics; }
        }

        public static string LogOut
        {
            get { return Resource.LogOut; }
        }
        public static string RegisterTitle
        {
            get { return Resource.RegisterTitle; }
        }

        public static string FirstNameLabel
        {
            get { return Resource.FirstNameLabel; }
        }

        public static string FirstNameValidation
        {
            get { return Resource.FirstNameValidation; }
        }

        public static string LastNameLabel
        {
            get { return Resource.LastNameLabel; }
        }

        public static string LastNameValidation
        {
            get { return Resource.LastNameValidation; }
        }

        public static string PhoneLabel
        {
            get { return Resource.PhoneLabel; }
        }

        public static string PhoneValidation
        {
            get { return Resource.PhoneValidation; }
        }

        public static string ConfirmLabel
        {
            get { return Resource.ConfirmLabel; }
        }

        public static string ConfirmValidation
        {
            get { return Resource.ConfirmValidation; }
        }

        public static string EmailValidation2
        {
            get { return Resource.EmailValidation2; }
        }

        public static string EmailExists
        {
            get { return Resource.EmailExists; }
        }
        
        public static string PasswordValidation2
        {
            get { return Resource.PasswordValidation2; }
        }

        public static string ConfirmValidation2
        {
            get { return Resource.ConfirmValidation2; }
        }

        public static string UserRegisteredMessage
        {
            get { return Resource.UserRegisteredMessage; }
        }

        public static string UserRegistered
        {
            get { return Resource.UserRegistered; }
        }

        public static string Cancel
        {
            get { return Resource.Cancel; }
        }

        public static string Save
        {
            get { return Resource.Save; }
        }

        public static string ChangePassword
        {
            get { return Resource.ChangePassword; }
        }

        public static string CurrentPassword
        {
            get { return Resource.CurrentPassword; }
        }


        public static string NewPassword
        {
            get { return Resource.NewPassword; }
        }

    

        public static string ConnectionError1
        {
            get { return Resource.ConnectionError1; }
        }

        public static string ConnectionError2
        {
            get { return Resource.ConnectionError2; }
        }

        public static string LoginError
        {
            get { return Resource.LoginError; }
        }

        public static string ChagePasswordConfirm
        {
            get { return Resource.ChagePasswordConfirm; }
        }

        public static string PasswordError
        {
            get { return Resource.PasswordError; }
        }

        public static string ErrorChangingPassword
        {
            get { return Resource.ErrorChangingPassword; }
        }

        public static string AddressLabel
        {
            get { return Resource.AddressLabel; }
        }

        public static string AddressValidation
        {
            get { return Resource.AddressValidation; }
        }

        public static string LocationLabel
        {
            get { return Resource.LocationLabel; }
        }

        public static string LocationValidation
        {
            get { return Resource.LocationValidation; }
        }

        public static string CodePostalLabel
        {
            get { return Resource.CodePostalLabel; }
        }

        public static string CodePostalValidation
        {
            get { return Resource.CodePostalValidation; }
        }

        public static string DoorLabel
        {
            get { return Resource.DoorLabel; }
        }

        public static string DoorValidation
        {
            get { return Resource.DoorValidation; }
        }

        public static string Register2
        {
            get { return Resource.Register2; }
        }

        public static string Enter
        {
            get { return Resource.Enter; }
        }

        public static string Help
        {
            get { return Resource.Help; }
        }

        public static string Ok
        {
            get { return Resource.Ok; }
        }

        public static string Register3
        {
            get { return Resource.Register3; }
        }

        public static string DeliveryLabel
        {
            get { return Resource.DeliveryLabel; }
        }

        public static string GeolocationLabel
        {
            get { return Resource.GeolocationLabel; }
        }

        public static string Or
        {
            get { return Resource.Or; }
        }
  
        public static string YouAreHere
        {
            get { return Resource.YouAreHere; }
        }
      
        public static string CustomDetailInfo
        {
            get { return Resource.CustomDetailInfo; }
        }

        public static string GpsFailure
        {
            get { return Resource.GpsFailure; }
        }

        public static string UbicationLabel
        {
            get { return Resource.UbicationLabel; }
        }

    }
}
