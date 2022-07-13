using DataObject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Models
{
    public interface IProductBL
    {
        //החזרת רשימת מוצרים במחסן- לפי קוד מחסן
        public List<ProductDTO> GetProductByCodeStorage(int codeStorage);
        //החזרת כל המוצרים מכל המחסנים
        public List<ProductDTO> GetProducts();
        //הוספת מוצר
        public List<ProductDTO> AddProduct(ProductDTO products);
        //מחיקת מוצר
        public List<ProductDTO> DeleteProduct(int codeProduct);
        //עדכון מוצר
        public List<ProductDTO> UpdateProduct(int codeProduct, ProductDTO products);
        //החזרת דגמים לפי קוד קבוצה
        public List<ProductDTO> GetProductBtCodeGroup(int codeGroup);
    }
}
