using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using BL.Models;
using DataObject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjectWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrdersBL _ordersBL;
        public OrderController(IOrdersBL ordersBL)
        {
            _ordersBL = ordersBL;
        }

        //רשימת הזמנות
        [HttpGet]
        [Route("GetOrders")]
        public IActionResult GetOrders()
        {
            try
            {
                return Ok(_ordersBL.GetOrders());
            }
            catch
            {
                return NoContent();
            }
        }
        //מחיקת הזמנה
        [HttpDelete]
        [Route("DeleteOrder/{codeOrder}")]
        public IActionResult DeleteOrder(int codeOrder)
        {
            try
            {
                return Ok(_ordersBL.DeleteOrder(codeOrder));
            }
            catch
            {
                return NoContent();
            }
        }
        //עדכון הזמנה
        [HttpPut]
        [Route("UpdateOrder/{codeOrder}")]
        public IActionResult UpdateOrder(int codeOrder, OrdersDTO ordersDTO)
        {
            try
            {
                return Ok(_ordersBL.UpdateOrder(codeOrder, ordersDTO));
            }
            catch { return NoContent(); }
        }
        //הוספת הזמנה
        [HttpPost]
        [Route("AddOrder")]
        public IActionResult AddOrder(OrdersDTO ordersDTO)
        {
            try
            {
                return Ok(_ordersBL.AddOrders(ordersDTO));
            }
            catch { return NoContent(); }
        }
        //הזמנות שבוצעו
        [HttpGet]
        [Route("GetOrdersPlaced")]
        public IActionResult GetOrdersPlaced()
        {
            try { return Ok(_ordersBL.GetOrdersPlaced()); }
            catch { return NoContent(); }
        }
        //הזמנות שלא בוצעו
        [HttpGet]
        [Route("GetOrdersNotPlaced")]
        public IActionResult GetOrdersNotPlaced()
        {
            try { return Ok(_ordersBL.GetOrdersNotPlaced()); }
            catch { return NoContent(); }

        }

        //עדכון ביצוע הזמנה ע"י מלקט
        [HttpGet]
        [Route("CollectOrder/{codeCollector}/{codeOrder}")]
        public IActionResult CollectOrder(int codeCollector,int codeOrder)
        {
            try
            {
                return Ok(_ordersBL.CollectOrder(codeCollector, codeOrder));
            }
            catch { return NoContent(); }
        }

        //סיום הזמנה
        [HttpGet]
        [Route("finishOrder/{codeOrder}")]
        public IActionResult finishOrder(int codeOrder)
        {
            try
            {
                return Ok(_ordersBL.finishOrder(codeOrder));
            }
            catch
            {
                return NoContent();
            }
        }

    }
}
