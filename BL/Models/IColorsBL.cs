using System;
using System.Collections.Generic;
using System.Text;
using DataObject.Models;

namespace BL.Models
{
   public interface IColorsBL
    {
        //החזרת רשימת כל הצבעים
        public List<ColorsDTO> GetColors();
        //מחיקת צבע
        public List<ColorsDTO> DeleteColor(int codeColor);
        //עדכון צבע
        public List<ColorsDTO> UpdateColor(int codeColor, ColorsDTO colors);
        //הוספת צבע
        public List<ColorsDTO> AddColor(ColorsDTO colors);
    }
}
