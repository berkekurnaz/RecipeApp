using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Business.Concrete.LiteDb;

namespace Recipe.MvcWebUI.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/AArticles")]
    public class AArticlesController : Controller
    {

        LDArticleManager articleManager = new LDArticleManager("Articles");
        LDAuthorManager authorManager = new LDAuthorManager("Authors");

        /******************** Example : www.yoursite.com/api/AArticles/yourApiKey ********************/
        [HttpGet("{apiKey}")]
        public async Task<ActionResult> GetAll(string apiKey)
        {
            var author = authorManager.CheckByApiKey(apiKey);
            if (author != null)
            {
                var query = articleManager.GetAll().OrderByDescending(x => x.Id).ToList();
                return Ok(query);
            }
            else
            {
                return NotFound();
            }
        }

        /******************** Example : www.yoursite.com/api/AArticles/2/yourApiKey ********************/
        [HttpGet("{id}/{apiKey}")]
        public async Task<ActionResult> GetById(int Id, string apiKey)
        {
            var author = authorManager.CheckByApiKey(apiKey);
            if (author != null)
            {
                var query = articleManager.GetById(Id);
                return Ok(query);
            }
            else
            {
                return NotFound();
            }
        }

        /******************** Example : www.yoursite.com/api/AArticles/1/5/yourApiKey ********************/
        [HttpGet("{id}/{count}/{apiKey}")]
        public async Task<ActionResult> GetByCount(int Id, int count, string apiKey)
        {
            var author = authorManager.CheckByApiKey(apiKey);
            if (author != null)
            {
                var query = articleManager.GetAll().OrderByDescending(x => x.Id).Take(count).ToList();
                return Ok(query);
            }
            else
            {
                return NotFound();
            }
        }

    }
}