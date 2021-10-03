using MarsRovers.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsRovers.Web.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CommunicationController : ControllerBase
    {
        private readonly ILogger<CommunicationController> _logger;
        private readonly IMarsRoversCommunicationService _marsRoversCommunicationService;
        public CommunicationController(ILogger<CommunicationController> logger, IMarsRoversCommunicationService marsRoversCommunicationService)
        {
            _logger = logger;
            _marsRoversCommunicationService = marsRoversCommunicationService;
        }

        [HttpPost]
        public JsonResult Communicate([FromBody]  CommunicationRequest request)
        {
            try
            {
                return new JsonResult(_marsRoversCommunicationService.SendCommand(request.Command));
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message);
            }
            
        }
    }
    public class CommunicationRequest
    {
        public string Command { get; set; }
    }
}
