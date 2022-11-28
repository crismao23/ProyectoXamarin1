using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using Unidad_2.Models;
using static Unidad_2.Models.RickModel;

namespace Unidad_2.ViewModel
{
	internal class RickViewModel: BaseViewModel
	{
		#region Atributos

		public string name;
		public string species;
		public List<Result> listResults;

		#endregion


		#region  Propiedades
		//Son las comunicadoras entre el view y viewmodel

		public List<Result> ResultsList
		{
			get { return listResults; }
			set { SetValue(ref this.listResults, value); }
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
			string url = "https://rickandmortyapi.com/api/character";

			var request = new HttpRequestMessage(HttpMethod.Get, url);

			HttpResponseMessage RespServ = await client.SendAsync(request);

			HttpContent content = RespServ.Content;
			string data = await content.ReadAsStringAsync();

			if (data != null)
			{
				var listData = JsonConvert.DeserializeObject<RickModel>(data);

				ResultsList = listData.results;
				
			}
			else
			{ }



		}

		public RickViewModel() {
			GetDataMethod();
		}

		#endregion
	}
}
