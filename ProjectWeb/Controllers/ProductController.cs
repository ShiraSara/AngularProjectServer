using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataObject.Models;
using BL.Models;

namespace ProjectWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductBL _productsBL;
        public ProductController(IProductBL productsBL)
        {
            _productsBL = productsBL;
        }
        //החזרת רשימת מוצרים במחסן ע"י קבלת קוד מחסן
        [HttpGet]
        [Route("GetProductByCodeStorage/{codeStorage}")]
        public IActionResult GetProductByCodeStorage(int codeStorage)
        {
            try
            {
                return Ok(_productsBL.GetProductByCodeStorage(codeStorage));
            }
            catch
            {
                return NoContent();
            }
        }
        //מחיקת מוצר
        [HttpDelete]
        [Route("DeleteProduct/{codeProduct}")]
        public IActionResult DeleteProduct(int codeProduct)
        {
            try
            {
                return Ok( _productsBL.DeleteProduct(codeProduct));
            }
            catch
            {
                return NoContent();
            }
        }
        //עדכון מוצר
        [HttpPut]
        [Route("UpdateProduct/{codeProduct}")]
        public IActionResult UpdateProduct(int codeProduct,[FromBody]ProductDTO productDTO)
        {
            try
            {
                return Ok( _productsBL.UpdateProduct(codeProduct, productDTO));
            }
            catch
            {
                return NoContent();
            }
        }
        //החזרת כל המוצרים
        [HttpGet]
        [Route("GetProduct")]
        public IActionResult GetProduct()
        {
            try
            {
                return Ok(_productsBL.GetProducts());
            }
            catch
            {
                return NoContent();
            }
        }
        //הוספת מוצר
        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(ProductDTO productDTO)
        {
            try
            {
                return Ok(_productsBL.AddProduct(productDTO));
            }
            catch(Exception e)
            {
                string s = e.Message;
                return NoContent();
            }
        }
        //החזרת מוצרים לפי קוד קבוצה
        [HttpGet]
        [Route("GetProductByCodeGroup/{codeGroup}")]
        public IActionResult GetProductByCodeGroup(int codeGroup)
        {
            try
            {
                return Ok(_productsBL.GetProductBtCodeGroup(codeGroup));
            }
            catch
            {
                return NoContent();
            }
        }
    }
}
