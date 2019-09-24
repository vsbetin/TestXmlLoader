using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XmlTest.EntityFramework.Models;
using XmlTest.Repo;

namespace XmlTest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ImportController : ControllerBase
	{
		private readonly XmlImportRepo _xmlImportRepo;

		public ImportController(XmlImportRepo xmlImportRepo)
		{
			_xmlImportRepo = xmlImportRepo;
		}
		
		[HttpPost]
		public async Task<ActionResult> Post([FromForm] IFormFile file, [FromForm] Status status = Status.Processed)
		{
			if(file != null && file.Length == 0)
			{
				return BadRequest("You have to upload xml file.");
			}

			var result = await _xmlImportRepo.ImportXml(file.OpenReadStream(), status);

			return result ? Ok() : (ActionResult)BadRequest("Wrong xml format.");
		}
	}
}
