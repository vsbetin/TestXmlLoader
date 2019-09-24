using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XmlTest.EntityFramework.Models
{
	public class OrderArticle
	{
		public string ArtNum { get; set; }
		public string Title { get; set; }
		public int Amount { get; set; }
		public decimal BrutPrice { get; set; }
		public Order Order { get; set; }
		public long OrderId { get; set; }
	}
}
