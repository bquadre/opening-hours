using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpeningHours.API.Models;
using OpeningHours.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OpeningHours.API.Controllers
{
    [Route("api/[controller]")]
    public class OpeningHoursController : Controller
    {
        private readonly ILogger<OpeningHoursController> _logger;
        private readonly IOpeningHoursService _openingHoursService;

        public OpeningHoursController(ILogger<OpeningHoursController> logger, IOpeningHoursService openingHoursService)
        {
            _logger = logger;
            _openingHoursService = openingHoursService;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] DayOfWeekInputDto input)
        {
            try
            {

                var request = _openingHoursService.ProcessRequest(input);

                if (request.IsSuccess)
                {
                    return Ok(request);
                }

                return BadRequest(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "");

                return BadRequest(ex.Message);
            }

        }

       
    }
}
