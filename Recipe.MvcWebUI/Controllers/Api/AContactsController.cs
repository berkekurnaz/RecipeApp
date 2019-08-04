using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Business.Concrete.LiteDb;
using Recipe.Entities.Concrete;

namespace Recipe.MvcWebUI.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/AContacts")]
    public class AContactsController : Controller
    {

        LDContactManager contactManager = new LDContactManager("Contacts");
        LDAuthorManager authorManager = new LDAuthorManager("Authors");

        /******************** Example : www.yoursite.com/api/AContacts/yourApiKey ********************/
        [HttpPost("{apiKey}")]
        public async Task<IActionResult> Post([FromBody] Contact model, string apiKey)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var author = authorManager.CheckByApiKey(apiKey);
            if (author != null)
            {
                contactManager.Add(model);
                return Ok(model);
            }
            else
            {
                return NotFound();
            }
        }

        /******************** Example : www.yoursite.com/api/AContacts/yourApiKey ********************/
        [HttpGet("{apiKey}")]
        public async Task<ActionResult> GetAll(string apiKey)
        {
            var author = authorManager.CheckByApiKey(apiKey);
            if (author != null)
            {
                var query = contactManager.GetAll().OrderByDescending(x => x.Id).ToList();
                return Ok(query);
            }
            else
            {
                return NotFound();
            }
        }

        /******************** Example : www.yoursite.com/api/AContacts/2/yourApiKey ********************/
        [HttpGet("{id}/{apiKey}")]
        public async Task<ActionResult> GetById(int Id, string apiKey)
        {
            var author = authorManager.CheckByApiKey(apiKey);
            if (author != null)
            {
                var query = contactManager.GetById(Id);
                return Ok(query);
            }
            else
            {
                return NotFound();
            }
        }

        /******************** Example : www.yoursite.com/api/AContacts/yourApiKey ********************/
        [HttpDelete("{id}/{apiKey}")]
        public async Task<ActionResult> Delete(int Id, string apiKey)
        {
            var author = authorManager.CheckByApiKey(apiKey);
            if (author != null)
            {
                var item = contactManager.GetById(Id);
                contactManager.Delete(Id);
                return Ok(item);
            }
            else
            {
                return NotFound();
            }
        }

        /******************** Example : www.yoursite.com/api/AContacts/yourApiKey ********************/
        [HttpPut("{id}/{apiKey}")]
        public async Task<ActionResult> Update(int Id, [FromBody] Contact model, string apiKey)
        {
            var author = authorManager.CheckByApiKey(apiKey);
            if (author != null)
            {
                var item = contactManager.GetById(Id);

                if (model.NameSurname != null) { item.NameSurname = model.NameSurname; }
                if (model.Mail != null) { item.Mail = model.Mail; }
                if (model.Title != null) { item.Title = model.Title; }
                if (model.Content != null) { item.Content = model.Content; }

                contactManager.Update(item);
                return Ok(item);
            }
            else
            {
                return NotFound();
            }
        }

    }
}