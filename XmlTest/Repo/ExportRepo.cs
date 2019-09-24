using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using XmlTest.EntityFramework;
using XmlTest.EntityFramework.Models;
using XmlTest.EntityFramework.ViewModels;

namespace XmlTest.Repo
{
	public class ExportRepo
	{
		private readonly AppDbContext _context;

		private readonly IMapper _mapper;

		public ExportRepo(AppDbContext context,
			IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<OrderVM>> GetAllOrders()
		{
			return await _context.Orders
				.Include(z => z.Articles)
				.Include(z => z.BillingAddress)
				.Include(z => z.Payments)
				.AsQueryable()
				.ProjectTo<OrderVM>(_mapper.ConfigurationProvider)
				.ToListAsync();
		}

		public async Task<OrderVM> GetOrderById(long id)
		{
			return await _context.Orders
				.Where(z => z.Oxid == id)
				.Include(z => z.Articles)
				.Include(z => z.BillingAddress)
				.Include(z => z.Payments)
				.AsQueryable()
				.ProjectTo<OrderVM>(_mapper.ConfigurationProvider)
				.FirstOrDefaultAsync();
		}
	}
}
