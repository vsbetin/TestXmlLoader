using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using XmlTest.EntityFramework;
using XmlTest.EntityFramework.Models;

namespace XmlTest.Repo
{
	public class XmlImportRepo
	{
		private readonly AppDbContext _context;

		public XmlImportRepo(AppDbContext context)
		{
			_context = context;
		}

		public async Task<bool> ImportXml(Stream xmlFile, Status status)
		{
			try
			{
				var doc = new XmlDocument();
				doc.Load(xmlFile);

				var root = doc.DocumentElement;

				var orderNodes = root.SelectNodes("descendant::order");

				foreach (XmlNode order in orderNodes)
				{
					await _context.Orders.AddAsync(new Order()
					{
						Oxid = Convert.ToInt64(order.SelectSingleNode("descendant::oxid").InnerText),
						OrderDate = Convert.ToDateTime(order.SelectSingleNode("descendant::orderdate").InnerText),
						Status = status,
						Payments = GetPaymentsFromXml(order.SelectSingleNode("descendant::payments")),
						Articles = GetArticlesFromXml(order.SelectSingleNode("descendant::articles")),
						BillingAddress = GetBillingFromXml(order.SelectSingleNode("descendant::billingaddress"))
					});
				}

				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}

		private List<OrderArticle> GetArticlesFromXml(XmlNode node)
		{
			if (node.ChildNodes.Count > 0)
			{
				var articles = new List<OrderArticle>(node.ChildNodes.Count);
				foreach (XmlNode article in node.ChildNodes)
				{
					articles.Add(new OrderArticle
					{
						ArtNum = article.SelectSingleNode("descendant::artnum").InnerText,
						Title = article.SelectSingleNode("descendant::title").InnerText,
						Amount = Convert.ToInt32(article.SelectSingleNode("descendant::amount").InnerText),
						BrutPrice = Convert.ToDecimal(article.SelectSingleNode("descendant::brutprice").InnerText, CultureInfo.InvariantCulture),
					});
				}

				return articles;
			}
			return null;
		}

		private List<Payment> GetPaymentsFromXml(XmlNode node)
		{
			if (node.ChildNodes.Count > 0)
			{
				var payments = new List<Payment>(node.ChildNodes.Count);
				foreach (XmlNode payment in node.ChildNodes)
				{
					payments.Add(new Payment
					{
						Amount = Convert.ToDecimal(payment.SelectSingleNode("descendant::amount").InnerText, CultureInfo.InvariantCulture),
						MethodName = payment.SelectSingleNode("descendant::method-name").InnerText,
					});
				}

				return payments;
			}
			return null;
		}

		private BillingAddress GetBillingFromXml(XmlNode node)
		{
			if (node.ChildNodes.Count > 0)
			{
				return new BillingAddress
				{
					Email = node.SelectSingleNode("descendant::billemail").InnerText,
					Name = node.SelectSingleNode("descendant::billfname").InnerText,
					Street = node.SelectSingleNode("descendant::billstreet").InnerText,
					StreetNumber = node.SelectSingleNode("descendant::billstreetnr").InnerText,
					City = node.SelectSingleNode("descendant::billcity").InnerText,
					Country = node.SelectSingleNode("country/descendant::geo").InnerText,
					Zip = Convert.ToInt32(node.SelectSingleNode("descendant::billzip").InnerText),
				};
			}
			return null;
		}
	}
}
