using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public interface IColorDAL
    {
        //החזרת רשימת כל הצבעים
        public List<Colors> GetColors();
        //מחיקת צבע
        public List<Colors> DeleteColor(int codeColor);
        //עדכון צבע
        public List<Colors> UpdateColor(int codeColor, Colors colors);
        //הוספת צבע
        public List<Colors> AddColor(Colors colors);
    }
}
