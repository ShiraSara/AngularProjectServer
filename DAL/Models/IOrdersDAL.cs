using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public interface IOrdersDAL
    {
        //הוספת הזמנה
        public List<Orders> AddOrders(Orders orders);
        //רשימת הזמנות
        public List<Orders> GetOrders();
        //עדכון הזמנה
        public List<Orders> UpdateOrder(int codeOrder, Orders orders);
        //מחיקת הזמנה
        public List<Orders> DeleteOrder(int codeOrder);
        //הזמנות שבוצעו
        public List<Orders> GetOrdersPlaced();
        //הזמנות שלא בוצעו
        public List<Orders> GetOrdersNotPlaced();
        //עדכון ביצוע הזמנה ע"י מלקט
        public bool CollectOrder(int codeCollector, int codeOrder);
        //סיום הזמנה
        public bool finishOrder(int codeOrder);
    }
}
