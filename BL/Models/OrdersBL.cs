using DataObject.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using AutoMapper;
using DataObject;
using System.IO;
using System.Linq;

namespace BL.Models
{
    public class OrdersBL : IOrdersBL
    {
        IOrdersDAL _IorderDAL;
        IMapper iMapper;
        public OrdersBL(IOrdersDAL ordersDAL)
        {
            _IorderDAL = ordersDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Auto>();
            });
            iMapper = config.CreateMapper();
        }
        //הוספת הזמנה
        public List<OrdersDTO> AddOrders(OrdersDTO orders)
        {
            Orders orders1 = iMapper.Map<OrdersDTO, Orders>(orders);
            return iMapper.Map<List<Orders>, List<OrdersDTO>>(_IorderDAL.AddOrders(orders1));
        }
        //מחיקת הזמנה
        public List<OrdersDTO> DeleteOrder(int codeOrder)
        {
            return iMapper.Map<List<Orders>, List<OrdersDTO>>(_IorderDAL.DeleteOrder(codeOrder));
        }
        //רשימת הזמנות
        public List<OrdersDTO> GetOrders()
        {
            return iMapper.Map<List<Orders>, List<OrdersDTO>>(_IorderDAL.GetOrders());
        }
        //עדכון הזמנה
        public List<OrdersDTO> UpdateOrder(int codeOrder, OrdersDTO orders)
        {
            Orders orders1 = iMapper.Map<OrdersDTO, Orders>(orders);
            return iMapper.Map<List<Orders>, List<OrdersDTO>>(_IorderDAL.UpdateOrder(codeOrder, orders1));
        }
        //קריאת נתונים מקובץ אקסל
        public bool ReadFromExcel(string fileName)
        {
            try
            {
                OrdersDTO o = new OrdersDTO();
                StreamReader read = new StreamReader(fileName, Encoding.Default);

                string str = read.ReadToEnd();

                string[] arr = str.Split('\n');
                for (int i = 1; i < arr.Length-1; i++)
                {
                    int j = 0;
                    string[] arr1 = arr[i].Split(',');
                    o.DateOrder = Convert.ToDateTime(arr1[j++]);
                    o.ExecutionDate = Convert.ToDateTime(arr1[j++]);
                    o.ProductFile = int.Parse(arr1[j++]);
                    o.Status = Convert.ToInt32(arr1[j++]);
                    o.CodeCollector = int.Parse(arr1[j++]);
                    Orders o1 = iMapper.Map<OrdersDTO, Orders>(o);
                    List<Orders> l = _IorderDAL.AddOrders(o1);
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        //הזמנות שבוצעו
        public List<OrdersDTO> GetOrdersPlaced()
        {
            return iMapper.Map<List<Orders>, List<OrdersDTO>>(_IorderDAL.GetOrdersPlaced());
        }
        //הזמנות שלא בוצעו
        public List<OrdersDTO> GetOrdersNotPlaced()
        {
            return iMapper.Map<List<Orders>, List<OrdersDTO>>(_IorderDAL.GetOrdersNotPlaced());
        }
        //עדכון ביצוע הזמנה ע"י מלקט
        public bool CollectOrder(int codeCollector, int codeOrder)
        {
            return _IorderDAL.CollectOrder(codeCollector, codeOrder);
        }

        public bool finishOrder(int codeOrder)
        {
            return _IorderDAL.finishOrder(codeOrder);
        }
    }
}
