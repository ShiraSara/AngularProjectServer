using System;
using System.Collections.Generic;
using System.Text;
using DataObject.Models;

namespace BL.Models
{
    public interface IStorageBL
    {
        //הוספת מחסן
        public List<StorageDTO> AddStorage(StorageDTO storage);
        //מחיקת מחסן
        public List<StorageDTO> DeleteStorage(int codeStorage);
        //עדכון מחסן
        public List<StorageDTO> UpdateStorage(int codeStorage, StorageDTO storage);
        //רשימת מחסנים
        public List<StorageDTO> GetStorage();
        //מקבל מספר מחסן ומחזיר את שם המחסן
        public string[] nameStorage(int codeStorage);

    }
}
