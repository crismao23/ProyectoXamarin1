using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Unidad_2.Views.Main;

namespace Unidad_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        async void Button_Login(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());

        }

		async void Button_Register(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Register());

		}

		async void Button_Maestro_Detalle(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Rick());

		}
	}
}