using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class ColorsDAL:IColorDAL
    {
        //החזרת רשימת כל הצבעים
        public List<Colors> GetColors()
        {
            using(var Data=new DataProject())
            {
                return Data.Colors.ToList();
            }
        }
        //מחיקת צבע
        public List<Colors> DeleteColor(int codeColor)
        {
            using (var Data = new DataProject())
            {
                Colors colors = Data.Colors.Where(c => c.CodeColor == codeColor).FirstOrDefault();
                Data.Colors.Remove(colors);
                Data.SaveChanges();
                return Data.Colors.ToList();
            }
        }
        //עדכון צבע
        public List<Colors> UpdateColor(int codeColor, Colors colors)
        {
            using (var Data = new DataProject())
            {
                Colors colors1 = Data.Colors.Where(c => c.CodeColor == codeColor).FirstOrDefault();
                Colors c = new Colors();
                if(colors1!=null)
                {
                    c.CodeColor = codeColor;
                    c.NameColor = colors.NameColor;
                    Data.Colors.Remove(colors1);
                    Data.Colors.Add(c);
                    Data.SaveChanges();
                        
                }
                return Data.Colors.ToList();
            }
        }
        //הוספת צבע
        public List<Colors> AddColor(Colors colors)
        {
            using (var Data = new DataProject())
            {
                Data.Colors.Add(colors);
                Data.SaveChanges();
                return Data.Colors.ToList();
            }
        }
    }
}
