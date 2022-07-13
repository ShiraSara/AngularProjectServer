using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrafhController : ControllerBase
    {
        Igrafh _grafh;
        public GrafhController(Igrafh grafh)
        {
            _grafh = grafh;
        }


        [HttpGet]
        [Route("GetnameOfMap/{codeOrder}")]
        public IActionResult GetnameOfMap(int codeOrder)
        {
            try
            {
                return Ok(_grafh.findStorage(codeOrder));
            }
            catch (Exception e){ return NoContent(); }
        }
    }
}
