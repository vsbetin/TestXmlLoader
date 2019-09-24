using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XmlTest.EntityFramework.ViewModels
{
	public class OrderVM
	{
		public long Oxid { get; set; }
		public DateTime OrderDate { get; set; }
		public ICollection<PaymentVM> Payments { get; set; }
		public ICollection<OrderArticleVM> Articles { get; set; }
		public BillingAddressVM BillingAddress { get; set; }
		public string Status { get; set; }		
	}
}
