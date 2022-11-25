using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Xamarin.Forms;

namespace Unidad_2.Models
{
	internal class DataLoggerServiceModel
	{
		public List<DataLogger> DataLoggerList { get; set; }
	}

	public class DataLogger
	{
		public int id { get; set; }
		public string fecha_registro { get; set; }
		public int temperatura { get; set; }
		public int humedad_relativa { get; set; }
		public string identificacion { get; set; }
		public string email { get; set; }
	}

}