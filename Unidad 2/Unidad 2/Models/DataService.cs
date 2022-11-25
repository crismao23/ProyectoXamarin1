using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Unidad_2.Models
{
	public class DataService
	{
		#region Fields 

		System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

		#endregion

		#region Properties 

		public dynamic Items { get; private set; }

		public string RestUrl { get; private set; }
		#endregion

		#region Constructor
		public DataService()
		{
			RestUrl = "https://ambi.azurewebsites.net/api/GetAmbiData?code=b-tezz0suZz0oWp5KYTJXWVFwiga8Ta6Rc7WY6lzS-ABAzFuOjgFVw==&email=cmarenas@utp.edu.co"; // Set your REST API url here
			client = new HttpClient();
		}

		#endregion

		#region Methods

		public async Task<dynamic> GetDataAsync()
		{
			try
			{
				//Sends request to retrieve data from the web service for the specified Uri
				var response = await client.GetAsync(RestUrl);

				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync(); //Returns the response as JSON string
					Items = JsonConvert.DeserializeObject<dynamic>(content); //Converts JSON string to dynamic
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"ERROR {0}", ex.Message);
			}
			return Items;
		}
		#endregion
	}
}
