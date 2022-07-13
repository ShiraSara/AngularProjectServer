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
    public class ProductGroupsController : ControllerBase
    {
        IProductGroupsBL _productGroupsBL;
        public ProductGroupsController(IProductGroupsBL productGroupsBL)
        {
            _productGroupsBL = productGroupsBL;
        }
        //כל הקבוצות
        [HttpGet]
        [Route("GetProductGroups")]
        public IActionResult GetProductGroup()
        {
            try
            {
                return Ok(_productGroupsBL.GetProductGroups());
            }
            catch
            {
                return NoContent();
            }
        }
        //לפי קוד קבוצה
        [HttpGet]
        [Route("GetProductGroupsByCodeGroup/{codeGroup}")]
        public IActionResult GetProductGroupsByCodeGroup(int codeGroup)
        {
            try
            {
                return Ok(_productGroupsBL.GetProductGroupsByCodeGroup(codeGroup));
            }
            catch
            {
                return NoContent();
            }
        }
        //הוספת קבוצה חדשה
        [HttpPost]
        [Route("AddProductGroups")]
        public IActionResult AddProductGroups([FromBody] ProductGroupsDTO p)
        {
            try
            {
                return Ok(_productGroupsBL.AddProductGroup(p));
            }
            catch
            {
                return NoContent();
            }
        }
        //מחיקת קבוצת מוצרים
        [HttpDelete]
        [Route("DeleteProductGroups/{codeGroup}")]
        public IActionResult DeleteProductGroups(int codeGroup)
        {
            try
            {
                return Ok(_productGroupsBL.DeleteProductGroup(codeGroup));
            }
            catch
            {
                return NoContent();
            }
        }
        //עדכון קבוצת מוצרים
        [HttpPut]
        [Route("UpdateProductGroups/{codeGroup}")]
        public IActionResult UpdateProductGroups(int codeGroup,ProductGroupsDTO productGroupsDTO)
        {
            try
            {
                return Ok(_productGroupsBL.UpdateProductGroup(codeGroup,productGroupsDTO));
            }
            catch
            {
                return NoContent();
            }
        }
    }
}
