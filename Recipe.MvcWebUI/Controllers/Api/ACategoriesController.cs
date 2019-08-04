using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Business.Concrete.LiteDb;
using Recipe.Entities.Concrete;

namespace Recipe.MvcWebUI.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/ACategories")]
    public class ACategoriesController : Controller
    {

        LDCategoryManager categoryManager = new LDCategoryManager("Categories");
        LDAuthorManager authorManager = new LDAuthorManager("Authors");

        [HttpGet("{apiKey}")]
        public async Task<ActionResult> GetAll(string apiKey)
        {
            var author = authorManager.CheckByApiKey(apiKey);
            if (author != null)
            {
                var query = categoryManager.GetAll();
                return Ok(query);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/{apiKey}")]
        public async Task<ActionResult> GetById(int Id, string apiKey)
        {
            var author = authorManager.CheckByApiKey(apiKey);
            if (author != null)
            {
                var query = categoryManager.GetById(Id);
                return Ok(query);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/{count}/{apiKey}")]
        public async Task<ActionResult> GetByCount(int Id, int count, string apiKey)
        {
            var author = authorManager.CheckByApiKey(apiKey);
            if (author != null)
            {
                var query = categoryManager.GetAll().Take(count).ToList();
                return Ok(query);
            }
            else
            {
                return NotFound();
            }
        }

    }
}