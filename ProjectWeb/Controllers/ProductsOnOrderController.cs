using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL.Models;
using DataObject.Models;

namespace ProjectWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsOnOrderController : ControllerBase
    {
        IProductsOnOrderBL _productsOnOrder;
        public ProductsOnOrderController(IProductsOnOrderBL productsOnOrder)
        {
            _productsOnOrder = productsOnOrder;
        }
        //רשימת מוצרים בזמנה
        [HttpGet]
        [Route("GetProductsOnOrder")]
        public IActionResult GetProductsOnOrder()
        {
            try { return Ok(_productsOnOrder.GetProductsOnOrders()); }
            catch {return NoContent(); }
        }
        //הוספת מוצר להזמנה
        [HttpPost]
        [Route("AddProductsOnOrder")]
        public IActionResult AddProductsOnOrder(ProductsOnOrderDTO p)
        {
            try { return Ok(_productsOnOrder.AddproductsOnOrders(p)); }
            catch { return NoContent(); }
        }
        //מחיקת מוצר להזמנה
        [HttpDelete]
        [Route("DeleteProductsOnOrder/{codeProductsOnOrder}")]
        public IActionResult DeleteProductsOnOrder(int codeProductsOnOrder)
        {
            try { return Ok(_productsOnOrder.DeleteproductsOnOrders(codeProductsOnOrder)); }
            catch { return NoContent();}
        }
        //עדכון מוצר בהזמנה
        [HttpGet]
        [Route("UpdateProductsOnOrder/{codeProductsOnOrder}")]
        public IActionResult UpdateProductsOnOrder(int codeProductsOnOrder)
        {
            try { return Ok(_productsOnOrder.UpdateproductsOnOrders(codeProductsOnOrder)); }
            catch { return NoContent(); }
        }
        
        //החזרת רשימת מוצרים בהזמנה על פי קוד הזמנה
        [HttpGet]
        [Route("GetProductsOnOrdersByCodeOrder/{codeOrder}")]
        public IActionResult GetProductsOnOrdersByCodeOrder(int codeOrder)
        {
            try { return Ok(_productsOnOrder.GetProductsOnOrdersByCodeOrder(codeOrder)); }
            catch { return NoContent(); }
        }

        //עדכון  סטטוס כל המוצרים בהזמנה מסוימת 
        [HttpGet]
        [Route("UpdateproductsOnOrdersByCodeOrder/{codeOrder}")]
        public IActionResult UpdateproductsOnOrdersByCodeOrder(int codeOrder)
        {
            try { return Ok(_productsOnOrder.UpdateproductsOnOrdersByCodeOrder(codeOrder)); }
            catch { return NoContent(); }
        }
    }
}
