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
    [Route("api/AComments")]
    public class ACommentsController : Controller
    {

        LDCommentManager commentManager = new LDCommentManager("Comments");
        LDAuthorManager authorManager = new LDAuthorManager("Authors");

        /******************** Example : www.yoursite.com/api/AComments/yourApiKey ********************/
        [HttpGet("{articleId}/{apiKey}")]
        public async Task<ActionResult> GetAll(int articleId, string apiKey)
        {
            var author = authorManager.CheckByApiKey(apiKey);
            if (author != null)
            {
                var query = commentManager.GetAll().Where(x => x.Article.Id == articleId).OrderByDescending(x => x.Id).ToList();
                return Ok(query);
            }
            else
            {
                return NotFound();
            }
        }

        /******************** Example : www.yoursite.com/api/AComments/2/yourApiKey ********************/
        [HttpGet("{articleId}/{commentId}/{apiKey}")]
        public async Task<ActionResult> GetById(int articleId, int commentId, string apiKey)
        {
            var author = authorManager.CheckByApiKey(apiKey);
            if (author != null)
            {
                var query = commentManager.GetById(commentId);
                return Ok(query);
            }
            else
            {
                return NotFound();
            }
        }

    }
}