using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public interface IStorageDAL
    {
        //הוספת מחסן
        public List<Storage> AddStorage(Storage storage);
        //מחיקת מחסן
        public List<Storage> DeleteStorage(int codeStorage);
        //עדכון מחסן
        public List<Storage> UpdateStorage(int codeStorage,Storage storage);
        //רשימת מחסנים
        public List<Storage> GetStorage();
        //מקבל מספר מחסן ומחזיר את שם המחסן
        public string[] nameStorage(int codeStorage);
    }
}
