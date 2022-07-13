using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class ProductsOnOrderDAL : IProductsOnOrderDAL
    {
        //רשימת מוצרים בהזמנה
        public List<ProductsOnOrder> GetProductsOnOrders()
        {
            using (var Data = new DataProject())
            {
                return Data.ProductsOnOrder.ToList();
            }
        }
        //הוספת מוצר בהזמנה
        public List<ProductsOnOrder> AddproductsOnOrders(ProductsOnOrder productsOnOrder)
        {
            using (var Data = new DataProject())
            {
                Data.ProductsOnOrder.Add(productsOnOrder);
                Data.SaveChanges();
                return Data.ProductsOnOrder.ToList();
            }
        }
        //מחיקת מוצר מהזמנה
        public List<ProductsOnOrder> DeleteproductsOnOrders(int codePrductOnOrder)
        {

            using (var Data = new DataProject())
            {
                ProductsOnOrder productsOnOrder = Data.ProductsOnOrder.Where(p => p.CodeProductsOnOrder == codePrductOnOrder).FirstOrDefault();
                Data.ProductsOnOrder.Remove(productsOnOrder);
                Data.SaveChanges();
                return Data.ProductsOnOrder.ToList();
            }
        }
        //עדכון סטטוס מוצר בהזמנה
        public List<ProductsOnOrder> UpdateproductsOnOrders(int codePrductOnOrder)
        {
            using (var Data = new DataProject())
            {
                ProductsOnOrder productsOnOrder1 = Data.ProductsOnOrder.Where(p => p.CodeProductsOnOrder == codePrductOnOrder).FirstOrDefault();
                ProductsOnOrder p = new ProductsOnOrder();
                if (productsOnOrder1 != null)
                {
                    p.CodeProductsOnOrder = codePrductOnOrder;
                    p.CodeOrder = productsOnOrder1.CodeOrder;
                    p.CodeModel = productsOnOrder1.CodeModel;
                    p.Count = productsOnOrder1.Count;
                    p.Status = 1;
                    Data.ProductsOnOrder.Remove(productsOnOrder1);
                    Data.ProductsOnOrder.Add(p);
                    Data.SaveChanges();
                }
                return Data.ProductsOnOrder.Where(o=>o.CodeOrder==productsOnOrder1.CodeOrder).ToList();
            }
        }
        //רשימת מוצרים בהזמנה על פי מספר הזמנה
        public List<ProductsOnOrder> GetProductsOnOrdersByCodeOrder(int codeOrder)
        {
            using (var Data = new DataProject())
            {
                List<ProductsOnOrder> productsOnOrdersList = Data.ProductsOnOrder.Where(p => p.CodeOrder == codeOrder).ToList();
                return productsOnOrdersList;
            }
        }
        //עדכון  סטטוס כל המוצרים בהזמנה מסוימת+עדכון סיום הזמנה מסוימת 
        public List<ProductsOnOrder> UpdateproductsOnOrdersByCodeOrder(int codeOrder)
        {
            using (var Data = new DataProject())
            {
                //עדכון הזמנה שבוצעה
                foreach (var item in Data.ProductsOnOrder.ToList())
                {
                    if (item.CodeOrder == codeOrder)
                    {
                        item.Status = 1;
                        Data.SaveChanges();

                    }
                }
                return Data.ProductsOnOrder.Where(p=>p.CodeOrder==codeOrder).ToList();
            }
        }
        

    }
}
