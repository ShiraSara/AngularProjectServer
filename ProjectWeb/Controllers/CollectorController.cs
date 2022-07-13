using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Models;
using DataObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectorController : ControllerBase
    {
        ICollectorBL _collectorBL;
        public CollectorController(ICollectorBL collectorBL)
        {
            _collectorBL = collectorBL;
        }

        //שליפת מלקט ע"פ קוד מלקט
        [HttpGet("{codeCollector}")]
        [Route("GetCollectorByCode/{codeCollector}")]
        public IActionResult GetCollectorByCode(int codeCollector)
        {
            try
            {
                return Ok(_collectorBL.GetCollectorByCode(codeCollector));
            }
            catch
            {
                return NoContent();
            }
        }
        //הוספת מלקט
        [HttpPost]
        [Route("AddCollector")]
        public IActionResult AddCollector([FromBody] CollectorDTO c)
        {
            try { return Ok(_collectorBL.AddCollector(c)); }

            catch (Exception e)
            {
                return NoContent();
            }
        }
        //החזרת רשימה של כל המלקטים
        [HttpGet]
        [Route("GetCollectors")]
        public IActionResult GetCollectors()
        {
            try
            {
                return Ok(_collectorBL.GetCollectors());
            }
            catch
            {
                return NoContent();
            }
        }
        //מחיקת מלקט
        [HttpDelete]
        [Route("DeleteCollector/{codeCollector}")]
        public IActionResult DeleteCollector(int codeCollector)
        {
            try
            {
                return Ok(_collectorBL.DeleteCollector(codeCollector));
            }
            catch
            {
                return NoContent();
            }
        }
        //עדכון מלקט
        [HttpPut]
        [Route("UpdateCollector/{codeCollector}")]
        public IActionResult UpdateCollector(int codeCollector, [FromBody] CollectorDTO c)
        {
            try
            {
                return Ok(_collectorBL.UpdateCollector(codeCollector, c));
            }
            catch
            {
                return NoContent();
            }
        }

        //אימות פרטי מלקט
        [HttpGet]
        [Route("Login/{userName}/{password}")]
        public IActionResult Login(string userName, string password)
        {
            try
            {
                return Ok(_collectorBL.Login(userName, password));
            }
            catch { return NoContent(); }
        }
        //אינדקס הכי גדול
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            try
            {
                return Ok(_collectorBL.index());
            }
            catch { return NoContent(); }
        }
        //הזמנה חדשה
        [HttpGet]
        [Route("ChooseOrder/{codeCollector}")]
        public IActionResult ChooseOrder(int codeCollector)
        {
            try
            {
                return Ok(_collectorBL.ChoodeOrder(codeCollector));
            }
            catch
            {
                return NoContent();
            }
        }
        //שחזור סיסמא
        [HttpGet]
        [Route("RestorationPassword/{userName}")]
        public IActionResult RestorationPassword(string userName)
        {
            try
            {
                return Ok(_collectorBL.RestorationPassword(userName));
            }
            catch
            {
                return NoContent();
            }
        }
        //שליפת מלקט ע"פ שם
        [HttpGet]
        [Route("GetCollectorByName/{name}")]
        public IActionResult GetCollectorByName(string name)
        {
            try
            {
                return Ok(_collectorBL.GetCollectorByName(name));
            }
            catch
            {
                return NoContent();
            }
        }

    }
}
