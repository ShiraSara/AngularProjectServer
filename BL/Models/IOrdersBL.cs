using System;
using System.Collections.Generic;
using System.Text;
using DataObject.Models;

namespace BL.Models
{
    public interface IOrdersBL
    {
        //הוספת הזמנה
        public List<OrdersDTO> AddOrders(OrdersDTO orders);
        //רשימת הזמנות
        public List<OrdersDTO> GetOrders();
        //עדכון הזמנה
        public List<OrdersDTO> UpdateOrder(int codeOrder, OrdersDTO orders);
        //מחיקת הזמנה
        public List<OrdersDTO> DeleteOrder(int codeOrder);
        //קריאה מקובץ אקסל
        public bool ReadFromExcel(string fileName);
        //הזמנות שבוצעו
        public List<OrdersDTO> GetOrdersPlaced();
        //הזמנות שלא בוצעו
        public List<OrdersDTO> GetOrdersNotPlaced();
        //עדכון ביצוע הזמנה ע"י מלקט
        public bool CollectOrder(int codeCollector, int codeOrder);
        //סיום הזמנה
        public bool finishOrder(int codeOrder);
    }
}
