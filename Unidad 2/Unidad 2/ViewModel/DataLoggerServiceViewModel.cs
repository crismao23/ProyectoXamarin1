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

namespace Unidad_2.ViewModel
{
	internal class DataLoggerServiceViewModel: BaseViewModel
	{
		#region Atributos
		public List<DataLogger> dataLoggerList;
		public int id;
		public string fecha_registro;
		public int temperatura;
		public int humedad_relativa;
		public string identificacion;
		public string email;
		#endregion


		#region  Propiedades
		//Son las comunicadoras entre el view y viewmodel

		public List<DataLogger> DataTxt {
			get { return dataLoggerList; }
			set { SetValue(ref this.dataLoggerList, value); }

		}
		public string FechaTxt
		{
			get { return fecha_registro; }
			set { SetValue(ref this.fecha_registro, value); }
		}

		public int TempTxt
		{
			get { return temperatura; }
			set { SetValue(ref this.temperatura, value); }
		}

		public int HumTxt
		{
			get { return humedad_relativa; }
			set { SetValue(ref this.humedad_relativa, value); }
		}

		public string IdentificacionTxt
		{
			get { return identificacion; }
			set { SetValue(ref this.identificacion, value); }
		}

		public string EmailTxt
		{
			get { return email; }
			set { SetValue(ref this.email, value); }
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
			string url = "https://ambi.azurewebsites.net/api/GetAmbiData?code=b-tezz0suZz0oWp5KYTJXWVFwiga8Ta6Rc7WY6lzS-ABAzFuOjgFVw==&email=all";

			var request = new HttpRequestMessage(HttpMethod.Get, url);

			HttpResponseMessage RespServ = await client.SendAsync(request);

			HttpContent content = RespServ.Content;
			string data = await content.ReadAsStringAsync();

			if (data != null)
			{
				var listData = JsonConvert.DeserializeObject<List<DataLogger>>(data);

				DataTxt = listData;
				EmailTxt = listData[0].ToString();

			}
			else
			{ }



		}

		#endregion
	}
}
