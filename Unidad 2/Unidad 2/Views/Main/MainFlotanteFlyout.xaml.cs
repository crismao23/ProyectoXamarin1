using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Unidad_2.Views.Main
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainFlotanteFlyout : ContentPage
	{
		public ListView ListView;

		public MainFlotanteFlyout()
		{
			InitializeComponent();

			BindingContext = new MainFlotanteFlyoutViewModel();
			ListView = MenuItemsListView;
		}

		private class MainFlotanteFlyoutViewModel : INotifyPropertyChanged
		{
			public ObservableCollection<MainFlotanteFlyoutMenuItem> MenuItems { get; set; }

			public MainFlotanteFlyoutViewModel()
			{
				MenuItems = new ObservableCollection<MainFlotanteFlyoutMenuItem>(new[]
				{
					new MainFlotanteFlyoutMenuItem { Id = 0, Title = "Registros", TargetType = typeof(MainFlotanteDetail) },
					new MainFlotanteFlyoutMenuItem { Id = 1, Title = "Salir", TargetType = typeof(Home) }
				});
			}

			#region INotifyPropertyChanged Implementation
			public event PropertyChangedEventHandler PropertyChanged;
			void OnPropertyChanged([CallerMemberName] string propertyName = "")
			{
				if (PropertyChanged == null)
					return;

				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
			#endregion
		}
	}
}