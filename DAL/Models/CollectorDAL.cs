using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class CollectorDAL : ICollectorDAL
    {

        //שליפת מלקט ע"פ קוד מלקט
        public Collector GetCollectorByCode(int codeCollector)
        {
            using (var Data = new DataProject())
            {
                Collector collector = Data.Collector.ToList().FirstOrDefault(collector => collector.CodeCollector == codeCollector);
                return collector;
            }
        }

        //הוספת מלקט
        public List<Collector> AddCollector(Collector c)
        {
            using (var Data = new DataProject())
            {
                Data.Collector.Add(c);
                Data.SaveChanges();
                return Data.Collector.ToList();
            }
        }
        //החזרת רשימת מלקטים
        public List<Collector> GetCollectors()
        {
            using (var Data = new DataProject())
            {
                return Data.Collector.ToList();
            }
        }
        //מחיקת מלקט
        public List<Collector> DeleteCollector(int codeCollector)
        {
            using (var Data = new DataProject())
            {
                Collector collector = Data.Collector.ToList().FirstOrDefault(c => c.CodeCollector == codeCollector);
                Data.Collector.Remove(collector);
                Data.SaveChanges();
                return Data.Collector.ToList();
            }
        }
        //עדכון מלקט
        public List<Collector> UpdateCollector(int codeCollector, Collector collector)
        {
            using (var Data = new DataProject())
            {
                Collector collector1 = new Collector();
                Collector c = Data.Collector.ToList().FirstOrDefault(c => c.CodeCollector == codeCollector);
                if (c != null)
                {
                    collector1.CodeCollector = codeCollector;
                    collector1.NameCollector = collector.NameCollector;
                    collector1.Password = collector.Password;
                    collector1.Email = collector.Email;
                    collector1.Username = collector.Username;
                    Data.Collector.Remove(c);
                    Data.Collector.Add(collector1);
                    Data.SaveChanges();
                }
                return Data.Collector.ToList();
            }
        }
        //אימות מלקט
        public Collector Login(string userName, string password)
        {
            using (var Data = new DataProject())
            {
                Collector c = Data.Collector.FirstOrDefault(c => c.Username.StartsWith(userName) && c.Password.StartsWith(password));
                return c;
            }
        }
        //אינדקס הכי גבוה
        public int index()
        {
            int max;
            using (var Data = new DataProject())
            {
                max = Data.Collector.Max(i => i.CodeCollector);
            }
            return max + 1;
        }
        //הקצאת הזמנה חדשה 
        public Orders ChoodeOrder(int codeCollector)
        {
            using (var Data = new DataProject())
            {
                Orders oo = Data.Orders.Where(p => p.Status == 0).OrderByDescending(x => x.DateOrder).Last();
                return oo;
            }
        }
        //אימייל
        public string sendEmail(string UserName)
        {
            using(var Data=new DataProject())
            {
                string s = Data.Collector.FirstOrDefault(c => c.Username.StartsWith(UserName)).Email;
                return s;
            }
        }
        //החזרת סיסמא
        public string GetPassword(string userName)
        {
            using (var Data = new DataProject())
            {
                string s = Data.Collector.FirstOrDefault(c => c.Username.StartsWith(userName)).Password;
                return s;
            }
        }
        //שליפת מלקט ע"פ קוד מלקט
        public Collector GetCollectorByName(string nameCollector)
        {
            using (var Data = new DataProject())
            {
                Collector s = Data.Collector.FirstOrDefault(c => c.NameCollector.StartsWith(nameCollector));
                return s;
            }
        }
    }
}
