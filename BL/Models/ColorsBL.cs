using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DAL.Models;
using DataObject;
using DataObject.Models;

namespace BL.Models
{
    public class ColorsBL:IColorsBL
    {

        IColorDAL _colorDAL;
        IMapper iMapper;
        public ColorsBL(IColorDAL colorDALL)
        {
            _colorDAL = colorDALL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Auto>();
            });
            iMapper = config.CreateMapper();
        }
        //החזרת רשימת כל הצבעים
        public List<ColorsDTO> GetColors()
        {
            return iMapper.Map<List<Colors>, List<ColorsDTO>>(_colorDAL.GetColors());
        }
        //מחיקת צבע
        public List<ColorsDTO> DeleteColor(int codeColor)
        {
            return iMapper.Map<List<Colors>, List<ColorsDTO>>(_colorDAL.DeleteColor(codeColor));
        }
        //עדכון צבע
        public List<ColorsDTO> UpdateColor(int codeColor, ColorsDTO colors)
        {
            Colors colors1 = iMapper.Map<ColorsDTO, Colors>(colors);
            return iMapper.Map<List<Colors>, List<ColorsDTO>>(_colorDAL.UpdateColor(codeColor,colors1));
        }
        //הוספת צבע
        public List<ColorsDTO> AddColor(ColorsDTO colors)
        {
            Colors colors1 = iMapper.Map<ColorsDTO, Colors>(colors);
            return iMapper.Map<List<Colors>, List<ColorsDTO>>(_colorDAL.AddColor(colors1));
        }
    }
}
