using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public interface ICollectorDAL
    {
        //שליפת מלקט ע"פ קוד מלקט
        public Collector GetCollectorByCode(int codeCollector);
        //שליפת מלקט ע"פ שם מלקט
        public Collector GetCollectorByName(string nameCollector);
        //הוספת מלקט
        public List<Collector> AddCollector(Collector c);
        //החזרת רשימת מלקטים
        public List<Collector> GetCollectors();
        //מחיקת מלקט
        public List<Collector> DeleteCollector(int codeCollector);
        //עדכון מלקט
        public List<Collector> UpdateCollector(int codeCollector, Collector c);
        //אימות מלקט
        public Collector Login(string userName, string password);
        //אינדקס הכי גבוה
        public int index();
        //בחירת הזמנות
        public Orders ChoodeOrder(int codeCollector);
        //שחזור סיסמא למלקט באמצעות כתובת מייל
        public string sendEmail(string UserName);
        //סיסמא
        public string GetPassword(string userName);
    }
}
