using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DAL.Models;
using DataObject;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using DataObject.Models;
using BL;

namespace BL.Models
{
    public class StorageBL : IStorageBL
    {
        IStorageDAL _storageOnOrderDAL;
        IMapper iMapper;
        public StorageBL(IStorageDAL storageOnOrderDAL)
        {
            _storageOnOrderDAL = storageOnOrderDAL;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<Auto>();
            });
            iMapper = config.CreateMapper();
        }
        //הוספת מחסן
        public List<StorageDTO> AddStorage(StorageDTO storage)
        {
            Storage s = iMapper.Map<StorageDTO, Storage>(storage);
            return iMapper.Map<List<Storage>, List<StorageDTO>>(_storageOnOrderDAL.AddStorage(s));
        }
        //מחיקת מחסן
        public List<StorageDTO> DeleteStorage(int codeStorage)
        {
            return iMapper.Map<List<Storage>, List<StorageDTO>>(_storageOnOrderDAL.DeleteStorage(codeStorage));
        }
        //עדכון מחסן
        public List<StorageDTO> UpdateStorage(int codeStorage, StorageDTO storage)
        {

            Storage s = iMapper.Map<StorageDTO, Storage>(storage);
            return iMapper.Map<List<Storage>, List<StorageDTO>>(_storageOnOrderDAL.UpdateStorage(codeStorage, s));
        }
        //רשימת מחסנים
        public List<StorageDTO> GetStorage()
        {
            return iMapper.Map<List<Storage>, List<StorageDTO>>(_storageOnOrderDAL.GetStorage());
        }
        //מחזיר שם מחסן ע"פ קוד
        public string[] nameStorage(int codeStorage)
        {
            return _storageOnOrderDAL.nameStorage(codeStorage);
        }     
    }
}
