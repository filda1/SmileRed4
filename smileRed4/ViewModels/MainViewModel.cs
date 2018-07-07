using smileRed4.Domain;
using smileRed4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace smileRed4.ViewModels
{
    public class MainViewModel
    {
        #region Attibrutes
        //private UserLocal user;
        #endregion

        #region Properties
        public List<Product> ProductsList
        {
            get;
            set;
        }

        public TokenResponse Token
        {
            get;
            set;
        }

        /*public ObservableCollection<MenuItemViewModel> Menus
        {
            get;
            set;
        }*/


       /* public UserLocal User
        {
            get { return this.user; }
            set { SetValue(ref this.user, value); }
        }*/
        #endregion


        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }

        public RegisterViewModel Register
        {
            get;
            set;
        }

        public DeliveryViewModel Delivery
        {
            get;
            set;
        }

        public UbicationsViewModel Ubications
        {
            get;
            set;
        }

        public AddressViewModel FullAddress
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
