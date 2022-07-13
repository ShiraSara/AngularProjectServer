using System;
using System.Collections.Generic;
using System.Text;
using DataObject.Models;

namespace BL.Models
{

    public interface ICollectorBL
    {
        //שליפת מלקט ע"פ קוד מלקט
        public CollectorDTO GetCollectorByCode(int codeCollector);
        //הוספת מלקט
        public List<CollectorDTO> AddCollector(CollectorDTO c);
        //החזרת רשימת מלקטים
        public List<CollectorDTO> GetCollectors();
        //מחיקת מלקט
        public List<CollectorDTO> DeleteCollector(int codeCollector);
        //עדכון מלקט
        public List<CollectorDTO> UpdateCollector(int codeCollector, CollectorDTO c);
        //אימות פרטי מלקט
        public CollectorDTO Login(string userName, string password);
        //החזרת אינדקס הכי גדול
        public int index();
        //בחירת הזמנות
        public OrdersDTO ChoodeOrder(int codeCollector);
        //שחזור סיסמא
        public bool RestorationPassword(string Uname);
        //שליפת מלקט ע"פ שם מלקט
        public CollectorDTO GetCollectorByName(string nameCollector);

    }
}