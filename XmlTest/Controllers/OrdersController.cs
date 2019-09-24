using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XmlTest.EntityFramework.Models;
using XmlTest.EntityFramework.ViewModels;
using XmlTest.Repo;

namespace XmlTest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly ExportRepo _exportRepo;

		public OrdersController(ExportRepo exportRepo)
		{
			_exportRepo = exportRepo;
		}

		[Route("GetAll")]
		[HttpGet]
		public async Task<ActionResult<IEnumerable<OrderVM>>> GetAll()
		{
			return await _exportRepo.GetAllOrders();
		}

		[Route("GetById")]
		[HttpGet]
		public async Task<ActionResult<OrderVM>> GetById(long id)
		{
			return await _exportRepo.GetOrderById(id);
		}
	}
}
