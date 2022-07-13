using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace DAL.Models
{
    public class OrdersDAL : IOrdersDAL
    {
        //הוספת הזמנה
        public List<Orders> AddOrders(Orders orders)
        {
            using (var Data = new DataProject())
            {
                Data.Orders.Add(orders);
                Data.SaveChanges();
                return Data.Orders.ToList();
            }
        }
        //מחיקת הזמנה
        public List<Orders> DeleteOrder(int codeOrder)
        {
            using (var Data = new DataProject())
            {
                Orders orders1 = Data.Orders.Where(o => o.CodeOrder == codeOrder).FirstOrDefault();
                Data.Orders.Remove(orders1);
                Data.SaveChanges();
                return Data.Orders.ToList();
            }
        }
        //קבלת רשימת הזמנות
        public List<Orders> GetOrders()
        {
            using (var Data = new DataProject())
            {
                return Data.Orders.ToList();
            }
        }
        //הזמנות שבוצעו
        public List<Orders> GetOrdersPlaced()
        {
            using (var Data = new DataProject())
            {
                var q = Data.Orders.Where(o => o.Status == 1);
                return q.ToList();
            }
        }
        //הזמנות שלא בוצעו
        public List<Orders> GetOrdersNotPlaced()
        {
            using (var Data = new DataProject())
            {
                var q = Data.Orders.Where(o => o.Status == 0);
                return q.ToList();
            }
        }
        //עדכון הזמנה
        public List<Orders> UpdateOrder(int codeOrder, Orders orders)
        {
            using (var Data = new DataProject())
            {
                Orders orders1 = Data.Orders.Where(o => o.CodeOrder == codeOrder).FirstOrDefault();
                Orders o = new Orders();
                if (orders1 != null)
                {
                    o.CodeCollector = codeOrder;
                    o.CodeCollector = orders.CodeCollector;
                    o.DateOrder = orders.DateOrder;
                    o.ExecutionDate = orders.ExecutionDate;
                    o.ProductFile = orders.ProductFile;
                    o.Status = orders.Status;
                    Data.Orders.Remove(orders1);
                    Data.Orders.Add(o);
                    Data.SaveChanges();
                }
                return Data.Orders.ToList();
            }

        }
        //עדכון התחלת הזמנה ע"י מלקט
        public bool CollectOrder(int codeCollector,int codeOrder)
        {
            using (var Data = new DataProject())
            {
                Orders o = Data.Orders.FirstOrDefault(o => o.CodeOrder == codeOrder);
                if(o!=null)
                {
                    o.CodeCollector = codeCollector;
                    o.Status = 2;
                    o.ExecutionDate = DateTime.Now;
                    Data.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool finishOrder(int codeOrder)
        {
            using (var Data = new DataProject())
            {
                Orders o = Data.Orders.FirstOrDefault(o => o.CodeOrder == codeOrder);
                if (o != null)
                {
                    o.Status = 1;
                    Data.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    
    }
}
