using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad_2.Views.Main
{
	public class MainFlotanteFlyoutMenuItem
	{
		public MainFlotanteFlyoutMenuItem()
		{
			TargetType = typeof(MainFlotanteFlyoutMenuItem);
		}
		public int Id { get; set; }
		public string Title { get; set; }

		public string Image { get; set; }

		public Type TargetType { get; set; }
	}
}