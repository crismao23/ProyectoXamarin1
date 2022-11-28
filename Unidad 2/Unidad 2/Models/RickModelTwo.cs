using System;
using System.Collections.Generic;
using System.Text;

namespace Unidad_2.Models
{
	public class RickModelTwo
	{
			public int id { get; set; }
			public string name { get; set; }
			public string status { get; set; }
			public string species { get; set; }
			public string type { get; set; }
			public string gender { get; set; }
			public Orig origin { get; set; }
			public Loc location { get; set; }
			public string image { get; set; }
			public List<string> episode { get; set; }
			public string url { get; set; }
			public DateTime created { get; set; }
		
	}
	public class Loc
	{
		public string name { get; set; }
		public string url { get; set; }
	}

	public class Orig
	{
		public string name { get; set; }
		public string url { get; set; }
	}
}
