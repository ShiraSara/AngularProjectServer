using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL.Models;
using DataObject.Models;
using BL;

namespace ProjectWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        IStorageBL _storageBL;

        public StorageController(IStorageBL storageBL)
        {
            _storageBL = storageBL;
        }
        //רשימת מחסנים
        [HttpGet]
        [Route("GetStorage")]
        public IActionResult GetStorage()
        {

            try { return Ok(_storageBL.GetStorage()); }
            catch { return NoContent(); }
        }
        //הוספת מחסן
        [HttpPost]
        [Route("AddStorage")]
        public IActionResult AddStorage(StorageDTO s)
        {
            try { return Ok(_storageBL.AddStorage(s)); }
            catch { return NoContent(); }
        }
        //מחיקת מחסן
        [HttpDelete]
        [Route("DeleteStorage/{codeStorsge}")]
        public IActionResult DeleteStorage(int codeStorsge)
        {
            try { return Ok(_storageBL.DeleteStorage(codeStorsge)); }
            catch { return NoContent(); }
        }
        //עדכון מחסן
        [HttpPut]
        [Route("UpdateStorage/{codeStorage}")]
        public IActionResult UpdateStorage(int codeStorage, StorageDTO s)
        {
            try { return Ok(_storageBL.UpdateStorage(codeStorage, s)); }
            catch { return NoContent(); }
        }
        //החזרת שם מחסן עפ קוד
        [HttpGet]
        [Route("NameStorage/{code}")]
        public IActionResult NameStorage(int code)
        {
            try { return Ok(_storageBL.nameStorage(code)); }
            catch { return NoContent(); }
        }

       
    }
}
