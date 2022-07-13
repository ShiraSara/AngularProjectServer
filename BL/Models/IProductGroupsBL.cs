using System;
using System.Collections.Generic;
using System.Text;
using DataObject.Models;

namespace BL.Models
{
    public interface IProductGroupsBL
    {
        //החזרת רשימת כל הקבוצות
        public List<ProductGroupsDTO> GetProductGroups();
        //החזרת קבוצה ע"פ קוד קבוצה
        public string[] GetProductGroupsByCodeGroup(int codeGroup);
        //מחיקת קבוצה
        public List<ProductGroupsDTO> DeleteProductGroup(int codeGroup);
        //עדכון קבוצה
        public List<ProductGroupsDTO> UpdateProductGroup(int codeGroup, ProductGroupsDTO p);
        //הוספת קבוצה
        public List<ProductGroupsDTO> AddProductGroup(ProductGroupsDTO productGroups);
    }
}
