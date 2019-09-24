using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XmlTest.EntityFramework.Models;
using XmlTest.EntityFramework.ViewModels;

namespace XmlTest
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			CreateMap<Order, OrderVM>();

			CreateMap<Payment, PaymentVM>();

			CreateMap<OrderArticle, OrderArticleVM>();

			CreateMap<BillingAddress, BillingAddressVM>();
		}
	}
}
