using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Unidad_2.Models;

namespace Unidad_2.ViewModel
{
	public class DataServiceViewModel : INotifyPropertyChanged
	{
		#region Fields

		private dynamic dataInfo;
		#endregion

		#region Properties
		public static DataService DataServices { get; private set; }

		public dynamic DataInfo
		{
			get { return dataInfo; }
			set
			{
				dataInfo = value;
				RaisedOnPropertyChanged("DataInfo");
			}
		}
		#endregion

		#region Constructor

		public DataServiceViewModel()
		{
			DataServices = new DataService();

			//Gets data from REST service and set it to the ItemsSource collection
			RetrieveDataAsync();
		}

		#endregion

		#region Method

		public async void RetrieveDataAsync()
		{
			DataInfo = await DataServices.GetDataAsync();
		}
		#endregion

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisedOnPropertyChanged(string _PropertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
			}
		}
		#endregion
	}
}
