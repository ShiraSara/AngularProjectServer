using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Models
{
    public class StorageDAL:IStorageDAL
    {
        //הוספת מחסן
        public List<Storage> AddStorage(Storage storage)
        {
            using(var Data=new DataProject())
            {
                Data.Storage.Add(storage);
                Data.SaveChanges();
                return Data.Storage.ToList();
            }
        }
        //מחיקת מחסן
        public List<Storage> DeleteStorage(int codeStorage)
        {
            using (var Data = new DataProject())
            {
                Storage storage = Data.Storage.Where(s => s.CodeStorage == codeStorage).FirstOrDefault();
                Data.Storage.Remove(storage);
                Data.SaveChanges();
                return Data.Storage.ToList();
            }
        }
        //עדכון מחסן
        public List<Storage> UpdateStorage(int codeStorage, Storage storage)
        {
            using (var Data = new DataProject())
            {
                Storage storage1 = Data.Storage.Where(s => s.CodeStorage == codeStorage).FirstOrDefault();
                Storage s = new Storage();
                if(storage1!=null)
                {
                    s.CodeStorage = codeStorage;
                    s.NameStorage = storage.NameStorage;
                    s.X = storage.X;
                    s.Y = storage.Y;
                    Data.Storage.Remove(storage1);
                    Data.Storage.Add(s);
                    Data.SaveChanges();
                }
                return Data.Storage.ToList();

            }
        }
        //רשימת מחסנים
        public List<Storage> GetStorage()
        {
            using (var Data = new DataProject())
            {
                return Data.Storage.ToList();
            }
        }
        //מקבלת קוד מחסן ומחזיר שם מחסן
        public string[] nameStorage(int codeStorage)
        {
            string[] vs = new string[1];
            using (var Data = new DataProject())
            {
                vs[0] = Data.Storage.FirstOrDefault(s => s.CodeStorage == codeStorage).NameStorage;
                return vs;
            }
        }

     
    }
}
