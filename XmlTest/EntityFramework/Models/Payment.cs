using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XmlTest.EntityFramework.Models
{
	public class Payment
	{
		public int Id { get; set; }
		public string MethodName { get; set; }
		public decimal Amount { get; set; }
		public Order Order { get; set; }
		public long OrderId { get; set; }
	}
}
