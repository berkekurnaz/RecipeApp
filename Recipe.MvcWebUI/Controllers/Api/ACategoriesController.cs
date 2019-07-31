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

        public async Task<ActionResult> Get()
        {
            var query = categoryManager.GetAll();
            return Ok(query);
        }

    }
}