using System;
using System.Collections.Generic;
using System.Text;

namespace Unidad_2.Models
{
	internal class LocationModel
	{
		public Inf info { get; set; }
		public List<Resu> results { get; set; }
	}
	public class Resu
	{
		public int id { get; set; }
		public string name { get; set; }
		public string type { get; set; }
		public string dimension { get; set; }
		public List<string> residents { get; set; }
		public string url { get; set; }
		public DateTime created { get; set; }
	}
	public class Inf
	{
		public int count { get; set; }
		public int pages { get; set; }
		public string next { get; set; }
		public object prev { get; set; }
	}

}
