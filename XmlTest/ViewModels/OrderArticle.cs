using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XmlTest.EntityFramework.ViewModels
{
	public class OrderArticleVM
	{
		public string ArtNum { get; set; }
		public string Title { get; set; }
		public int Amount { get; set; }
		public decimal BrutPrice { get; set; }
	}
}
