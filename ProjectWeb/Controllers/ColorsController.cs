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
    public class ColorsController : ControllerBase
    {
        IColorsBL _colorsBL;
        public ColorsController(IColorsBL colorsBL)
        {
            _colorsBL = colorsBL;
        }
        //רשימת צבעים
        [HttpGet]
        [Route("GetColors")]
        public IActionResult GetColors()
        {
            try { return Ok(_colorsBL.GetColors()); }
            catch { return NoContent(); }
        }
        //הוספת צבע
        [HttpPost]
        [Route("AddColor")]
        public IActionResult AddColor(ColorsDTO colorsDTO)
        {
            try { return Ok(_colorsBL.AddColor(colorsDTO)); }
            catch { return NoContent(); }
        }
        //מחיקת צבע
        [HttpDelete]
        [Route("DeleteColor/{codeColor}")]
        public IActionResult DeleteColor(int codeColor)
        {
            try { return Ok(_colorsBL.DeleteColor(codeColor)); }
            catch { return NoContent(); }
        }
        //עדכון צבע
        [HttpPut]
        [Route("UpdateColor/{codeColor}")]
        public IActionResult UpdateColor(int codeColor,ColorsDTO colorsDTO)
        {
            try { return Ok(_colorsBL.UpdateColor(codeColor, colorsDTO)); }
            catch { return NoContent(); }
        }
    }
}
