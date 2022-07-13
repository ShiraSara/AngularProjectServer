using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public interface IProductGroupsDAL
    {
        //החזרת רשימת כל הקבוצות
        public List<ProductGroups> GetProductGroups();
        //החזרת קבוצה ע"פ קוד קבוצה
        public string[] GetProductGroupsByCodeGroup(int codeGroup);
        //מחיקת קבוצה
        public List<ProductGroups> DeleteProductGroup(int codeGroup);
        //עדכון קבוצה
        public List<ProductGroups> UpdateProductGroup(int codeGroup, ProductGroups p);
        //הוספת קבוצה
        public List<ProductGroups> AddProductGroup(ProductGroups productGroups);
    }
}
