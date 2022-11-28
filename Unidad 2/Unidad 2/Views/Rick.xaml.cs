using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unidad_2.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unidad_2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Rick : ContentPage
	{
		public Rick()
		{
			InitializeComponent();
			BindingContext = new RickViewModel();
		}
	}
}