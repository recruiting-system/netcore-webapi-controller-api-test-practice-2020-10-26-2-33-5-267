using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netcore_webapi_controller_api.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace netcore_webapi_controller_api.Controllers
{
    [ApiController]
    [Route("shows")]
    public class ShowController : Controller
    {
        
        private ShowService _showService;

        public ShowController(ShowService showService)
        {
            _showService = showService;
        }

        // GET: /<controller>/
        public ActionResult GetAll()
        {
            return Ok(_showService.GetShowLabel());
        }
    }
}
