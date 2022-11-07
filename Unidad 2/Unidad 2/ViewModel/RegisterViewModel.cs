using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Unidad_2.Models;
using Xamarin.Forms;

namespace Unidad_2.ViewModel
{
	internal class RegisterViewModel : BaseViewModel
	{
		#region Atributos
		public string email;
		public string user;
		public string name;
		public string age;
		public string password;


		#endregion

		#region  Propiedades

		public string EmailTxt
		{
			get { return email; }
			set { SetValue(ref this.email, value); }
		}

		public string UserTxt
		{
			get { return user; }
			set { SetValue(ref this.user, value); }
		}

		public string NameTxt
		{
			get { return name; }
			set { SetValue(ref this.name, value); }
		}

		public string AgeTxt
		{
			get { return age; }
			set { SetValue(ref this.age, value); }
		}

		public string PasswordTxt
		{
			get { return password; }
			set { SetValue(ref this.password, value); }
		}

		#endregion

		#region  Commands
		public ICommand RegisterCommand
		{
			get
			{
				return new RelayCommand(RegisterMethod);
			}

		}

		#endregion

		#region Methods
		public async void RegisterMethod()
		{
			if (string.IsNullOrEmpty(this.email))
			{
				await Application.Current.MainPage.DisplayAlert(
					"Error",
					"Debes ingresar un email",
					"Aceptar");
				return;
			}

			if (string.IsNullOrEmpty(this.user))
			{
				await Application.Current.MainPage.DisplayAlert(
					"Error",
					"Debes ingresar un usuario",
					"Aceptar");
				return;
			}

			if (string.IsNullOrEmpty(this.name))
			{
				await Application.Current.MainPage.DisplayAlert(
					"Error",
					"Debes ingresar el nombre completo",
					"Aceptar");
				return;
			}

			if (string.IsNullOrEmpty(this.age))
			{
				await Application.Current.MainPage.DisplayAlert(
					"Error",
					"Debes ingresar la edad",
					"Aceptar");
				return;
			}

			if (string.IsNullOrEmpty(this.password))
			{
				await Application.Current.MainPage.DisplayAlert(
					"Error",
					"Debes ingresar una contrasena",
					"Aceptar");
				return;
			}
			
			try
			{
				await App.Db.SaveUserModelAsync(new UserModel() {
					UserName = UserTxt.ToString(),
					Password = PasswordTxt.ToString(),
					Nombre = NameTxt.ToString(),
					Email = EmailTxt.ToString(),
					Edad = AgeTxt.ToString()

				});
				await Application.Current.MainPage.DisplayAlert("Welcome", "Agregado de manera exitosa", "Aceptar");
			}
			catch (Exception ex){
				throw new Exception(ex.Message);
			}
		}
		#endregion
	}
}