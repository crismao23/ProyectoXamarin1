using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unidad_2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Eventos : ContentPage
    {
        public Eventos()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string nombre;
            int edad;
            try
            {

                if( swValid.IsToggled)
                {

                }
                nombre = etyNombre.Text;
                edad = int.Parse(nombre);
                if ( edad > 17)
                    DisplayAlert("Welcome", string.Concat("Mayor edad ",nombre), "OK");

            }
            catch (Exception ex)
            {
				DisplayAlert("Error" + ex, string.Concat("Error"), "OK");
			}
        }

        private void etyNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblView.Text = etyNombre.Text;
        

        }
    }
}