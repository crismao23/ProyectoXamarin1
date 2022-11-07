using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows.Input;
using Unidad_2.Models;
using Xamarin.Forms;

namespace Unidad_2.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        #region Atributos
        public string user;
        public string password;
        #endregion

        #region  Propiedades
        public string UserTxt
        {
            get { return user; }
            set { SetValue(ref this.user, value); }
        }

        public string PasswordTxt
        {
            get { return password; }
            set { SetValue(ref this.password, value); }
        }

        #endregion

        #region  Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginMethod);
            }

        }

        #endregion

        #region Methods
        public async void LoginMethod()
        {
            string _query = "SELECT * FROM UserModel WHERE UserName = '"+ UserTxt.ToString() + "' AND Password = '"+ PasswordTxt.ToString() + "' ";
            List<UserModel> ListUser = App.Db.QueryUserModel(_query).Result;
            if(ListUser.Count>0)
            {
               await Application.Current.MainPage.DisplayAlert("Welcome", "Bienvenido", "Aceptar");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Usuario incorrecto", "Aceptar");
            }

        }
        #endregion

    }
}
