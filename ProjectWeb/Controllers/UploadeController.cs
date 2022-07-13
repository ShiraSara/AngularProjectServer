using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using BL.Models;
using BL;

namespace ProjectWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadeController : ControllerBase
    {
        IOrdersBL _iorderBL;
        Igrafh _igrafh;
        public UploadeController(Igrafh igrafh,IOrdersBL ordersBL)
        {
            _iorderBL = ordersBL;
            _igrafh = igrafh;
        }
        [HttpPost, DisableRequestSizeLimit]
        //העלאת תמונה
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        //העלאת אקסל
        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadExcel")]
        public IActionResult UploadExcel()
        {
            try
            {

                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "Orders");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    try
                    {
                        _iorderBL.ReadFromExcel(fullPath);
                        return Ok(new { dbPath });
                    }
                    catch { return NoContent(); }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        //-מחסנים--העלאת קובץ לקריאת נתונים
        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadDataStorage")]
        public IActionResult UploadData()
        {
            try
            {

                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "Data");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    try
                    {
                        _igrafh.ReadFromExcelToList1(fullPath);
                        return Ok(new { dbPath });
                    }
                    catch { return NoContent(); }

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        //-מעברים--העלאת קובץ לקריאת נתונים
        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadDataIntersection")]
        public IActionResult UploadData1()
        {
            try
            {

                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "Data");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    try
                    {
                        _igrafh.ReadFromExcelToList2(fullPath);
                        return Ok(new { dbPath });
                    }
                    catch { return NoContent(); }

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
