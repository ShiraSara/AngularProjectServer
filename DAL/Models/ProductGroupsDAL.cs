using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class ProductGroupsDAL : IProductGroupsDAL
    {
        //הוספת קבוצת מוצרים
        public List<ProductGroups> AddProductGroup(ProductGroups productGroups)
        {
            using(var Data=new DataProject())
            {
                Data.ProductGroups.Add(productGroups);
                Data.SaveChanges();
                return Data.ProductGroups.ToList();
            }
        }
        //מחיקת קבוצת מוצרים
        public List<ProductGroups> DeleteProductGroup(int codeGroup)
        {
            using (var Data = new DataProject())
            {
                ProductGroups p = Data.ProductGroups.ToList().FirstOrDefault(p => p.CodeGroups == codeGroup);
                if(p!=null)
                {
                    Data.ProductGroups.Remove(p);
                    Data.SaveChanges();
                }
                return Data.ProductGroups.ToList();
            }
        }
        //החזרת כל קבוצות המוצרים
        public List<ProductGroups> GetProductGroups()
        {
            using (var Data = new DataProject())
            {
                return Data.ProductGroups.ToList();
            }
        }
        //החזרת קבוצה מסוימת ע"פ קוד קבוצה
        public string[] GetProductGroupsByCodeGroup(int codeGroup)
        {
            string[] vs = new string[1];
            using (var Data = new DataProject())
            {
                ProductGroups p = Data.ProductGroups.ToList().FirstOrDefault(p => p.CodeGroups == codeGroup);
                if (p != null)
                {
                    vs[0] = p.NaneGroups;
                    return vs;
                }
                return null;
            }
        }
        //עדכון קבוצת מוצרים
        public List<ProductGroups> UpdateProductGroup(int codeGroup, ProductGroups p)
        {
            using (var Data = new DataProject())
            {
                ProductGroups productGroup = Data.ProductGroups.ToList().FirstOrDefault(p => p.CodeGroups == codeGroup);
                ProductGroups p1 = new ProductGroups();
                if(productGroup!=null)
                {
                    p1.CodeGroups = codeGroup;
                    p1.NaneGroups = p.NaneGroups;
                    p1.Products = p.Products;
                    Data.ProductGroups.Remove(productGroup);
                    Data.ProductGroups.Add(p1);
                    Data.SaveChanges();
                }
                return Data.ProductGroups.ToList();
            }
        }
    }
}
