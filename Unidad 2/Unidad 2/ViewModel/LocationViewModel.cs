using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Unidad_2.Models;

namespace Unidad_2.ViewModel
{
	internal class LocationViewModel: BaseViewModel
	{
		#region Atributos
		public List<Resu> listResul;
		#endregion


		#region  Propiedades
		//Son las comunicadoras entre el view y viewmodel

		public List<Resu> LocationList
		{
			get { return listResul; }
			set { SetValue(ref this.listResul, value); }
		}

		#endregion

		#region Command
		public ICommand GetData
		{

			get
			{
				return new RelayCommand(GetDataMethod);
			}
		}
		#endregion

		#region Method
		public async void GetDataMethod()
		{

			var client = new HttpClient();
			string url = "https://rickandmortyapi.com/api/location";

			var request = new HttpRequestMessage(HttpMethod.Get, url);

			HttpResponseMessage RespServ = await client.SendAsync(request);

			HttpContent content = RespServ.Content;
			string data = await content.ReadAsStringAsync();

			if (data != null)
			{
				var list = JsonConvert.DeserializeObject<LocationModel>(data);

				LocationList = list.results;

			}
			else
			{ }



		}

		public LocationViewModel()
		{
			GetDataMethod();
		}

		#endregion

	}
}
