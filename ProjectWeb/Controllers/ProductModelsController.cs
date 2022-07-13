using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Models;
using Microsoft.AspNetCore.Http;
using DataObject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjectWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductModelsController : ControllerBase
    {
        IProductModelsBL _productModelsBL;
        public ProductModelsController(IProductModelsBL productModelsBL)
        {
            _productModelsBL = productModelsBL;
        }
        //רשימת דגמים
        [HttpGet]
        [Route("GetProductModels")]
        public IActionResult GetProductModels()
        {
            try
            {
                return Ok(_productModelsBL.GetProductModels());
            }
            catch { return NoContent(); }
        }
        //הוספת דגם
        [HttpPost]
        [Route("AddProductModels")]
        public IActionResult AddProductModels(ProductModelsDTO productModelsDTO)
        {
            try
            {
                return Ok(_productModelsBL.AddProductModels(productModelsDTO));
            }
            catch(Exception e)
            {
                return NoContent();
            }
        }
        //עדכון דגם
        [HttpPut]
        [Route("UpdateProductModels/{codeProductModels}")]
        public IActionResult UpdateProductModels(int codeProductModels,[FromBody]ProductModelsDTO productModelsDTO)
        {
            try
            {
                return Ok(_productModelsBL.UpdateProductModels(codeProductModels, productModelsDTO));
            }
            catch { return NoContent(); }
        }
        //מחיקת דגם
        [HttpDelete]
        [Route("DeleteProductModels/{codeProductModels}")]
        public IActionResult DeleteProductModels(int codeProductModels)
        {
            try
            {
                return Ok(_productModelsBL.DeleteProductModels(codeProductModels));
            }
            catch
            {
                return NoContent();
            }
        }
        //החזרת דגמים לפי קוד מוצר
        [HttpGet]
        [Route("GetProductModelsByCodeProduct/{codeP}")]
        public IActionResult GetProductModelsByCodeProduct(int codeP)
        {
            try
            {
                return Ok(_productModelsBL.GetProductModelsByCodeProduct(codeP));
            }
            catch { return NoContent(); }
        }
        //החזרת שם מוצר
        [HttpGet]
        [Route("GetNameProduct/{codeModel}")]
        public IActionResult GetNameProduct(int codeModel)
        {
            try
            {
                return Ok(_productModelsBL.GetNameProduct(codeModel));
            }
            catch { return NoContent(); }
        }
    }
}
