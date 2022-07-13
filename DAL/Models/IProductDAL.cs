using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
   public interface IProductDAL
    {
        //החזרת רשימת מוצרים במחסן- לפי קוד מחסן
        public List<Products> GetProductByCodeStorage(int codeStorage);
        //החזרת כל המוצרים מכל המחסנים
        public List<Products> GetProducts();
        //הוספת מוצר
        public List<Products> AddProduct(Products products);
        //מחיקת מוצר
        public List<Products> DeleteProduct(int codeProduct);
        //עדכון מוצר
        public List<Products> UpdateProduct(int codeProduct, Products products);
        //החזרת דגמים לפי קוד קבוצה
        public List<Products> GetProductBtCodeGroup(int codeGroup);
    }
}
