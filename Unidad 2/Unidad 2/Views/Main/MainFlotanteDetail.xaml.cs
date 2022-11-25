using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Unidad_2.Models;
using Unidad_2.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unidad_2.Views.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainFlotanteDetail : ContentPage
	{
		public MainFlotanteDetail()
		{
			InitializeComponent();
		}
	}
}