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
    [Route("api/ASettings")]
    public class ASettingsController : Controller
    {

        LDSettingManager settingManager = new LDSettingManager("Settings");
        LDAuthorManager authorManager = new LDAuthorManager("Authors");

        /******************** Example : www.yoursite.com/api/ASettings/yourApiKey ********************/
        [HttpGet("{apiKey}")]
        public async Task<ActionResult> GetAll(string apiKey)
        {
            var author = authorManager.CheckByApiKey(apiKey);
            if (author != null)
            {
                var query = settingManager.GetById(1);
                return Ok(query);
            }
            else
            {
                return NotFound();
            }
        }

    }
}