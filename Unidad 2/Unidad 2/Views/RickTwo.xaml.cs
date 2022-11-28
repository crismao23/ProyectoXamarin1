using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net;
using Xamarin.Forms;
using static Unidad_2.Models.RickModel;
using System.Text.Json;
using Unidad_2.Models;

namespace Unidad_2.Views
{
	public partial class RickTwo : ContentPage
	{
		public RickTwo()
		{
			InitializeComponent();
		}
	

		private async void Get_Character(object sender, EventArgs e)
		{
			var request = new HttpRequestMessage();
			request.RequestUri = new Uri("https://rickandmortyapi.com/api/character/1,2,3,4,5");
			request.Method = HttpMethod.Get;
			request.Headers.Add("Accept", "application/json");
			var client = new HttpClient();
			HttpResponseMessage response = await client.SendAsync(request);
			if (response.StatusCode == HttpStatusCode.OK)
			{
				string content = await response.Content.ReadAsStringAsync();
				var resultado = JsonSerializer.Deserialize<List<RickModelTwo>>(content);
				Character.ItemsSource = resultado;
			}
		}
	}
}