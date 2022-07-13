using DataObject.Models;
using System;
using DataObject;
using DAL.Models;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace BL.Models
{
    public class CollectorBL : ICollectorBL
    {
        ICollectorDAL _collectorDAL;
        IMapper iMapper;
        public CollectorBL(ICollectorDAL collectorDAL)
        {
            _collectorDAL = collectorDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Auto>();
            });
            iMapper = config.CreateMapper();
        }
        //שליפת מלקט ע"פ קוד מלקט
        public CollectorDTO GetCollectorByCode(int codeCollector)
        {
            CollectorDTO collectorDTO = iMapper.Map<Collector, CollectorDTO>(_collectorDAL.GetCollectorByCode(codeCollector));
            return collectorDTO;
        }
        //הוספת מלקט
        public List<CollectorDTO> AddCollector(CollectorDTO c)
        {
            Collector collector = iMapper.Map<CollectorDTO, Collector>(c);
            List<CollectorDTO> collectorDTOs = iMapper.Map<List<Collector>, List<CollectorDTO>>(_collectorDAL.AddCollector(collector));
            return collectorDTOs;
        }
        //החזרת רשימת מלקטים
        public List<CollectorDTO> GetCollectors()
        {
            List<CollectorDTO> collectorDTOs = iMapper.Map<List<Collector>, List<CollectorDTO>>(_collectorDAL.GetCollectors());
            return collectorDTOs;
        }
        //מחיקת מלקט
        public List<CollectorDTO> DeleteCollector(int codeCollector)
        {
            List<CollectorDTO> collectorDTOs = iMapper.Map<List<Collector>, List<CollectorDTO>>(_collectorDAL.DeleteCollector(codeCollector));
            return collectorDTOs;
        }
        //עדכון מלקט
        public List<CollectorDTO> UpdateCollector(int codeCollector, CollectorDTO c)
        {
            Collector collector = iMapper.Map<CollectorDTO, Collector>(c);
            List<CollectorDTO> collectorDTOs = iMapper.Map<List<Collector>, List<CollectorDTO>>(_collectorDAL.UpdateCollector(codeCollector,collector));
            return collectorDTOs;
        }
        //אימות פרטי מלקט
        public CollectorDTO Login(string userName, string password)
        {
            CollectorDTO collector = iMapper.Map<Collector, CollectorDTO>(_collectorDAL.Login(userName,password));
            return collector;
        }
        //החזרת אינדקס הכי גדול
        public int index()
        {
            return _collectorDAL.index();
        }
        //בחירת הזמנות
        public OrdersDTO ChoodeOrder(int codeCollector)
        {
           OrdersDTO orders = iMapper.Map<Orders,OrdersDTO>(_collectorDAL.ChoodeOrder(codeCollector));
           return orders;
        }
        //שחזור סיסמא
        public bool RestorationPassword(string Uname)
        {
            string Email = _collectorDAL.sendEmail(Uname);
            string pas = _collectorDAL.GetPassword(Uname);
            try
            {
                sendEmail.Func(Email,pas);
                return true;
            }
            catch { return false; }
        }
        //שליפת מלקט ע"פ שם מלקט
        public CollectorDTO GetCollectorByName(string nameCollector)
        {
            CollectorDTO collector = iMapper.Map<Collector, CollectorDTO>(_collectorDAL.GetCollectorByName(nameCollector));
            return collector;
        }
    }
}
