using HandleExcel.Common.DTOs;
using HandleExcel.Services.Interfaces;
using HandleExcel.Services.Services;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Xunit;
using Xunit.Sdk;

namespace HandleExcel.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserFileController : Controller
    {
        private readonly IUserService _userService;
        public UserFileController(IUserService userService)
        {
            _userService = userService;
        }

        //Get
        [HttpGet]
        public List<UserDTO> Get()
        {
            return _userService.GetValidTzList();
        }

        [HttpPost]
        public IActionResult Post(IFormFile file)
        //public IActionResult Post([FromForm(Name = "file")] IFormFile file)
        {
            var supportedTypes = new[] { "txt", "doc", "docx", "pdf", "xls", "xlsx" };
            var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
            if (!supportedTypes.Contains(fileExt))
            {
                return BadRequest("File Extension Is InValid - Only Upload WORD/PDF/EXCEL/TXT File");
            }
            if (file == null || file.Length == 0)
                return BadRequest ("File Not Selected");

            string fileExtension = Path.GetExtension(file.FileName);
            if (fileExtension != ".xls" && fileExtension != ".xlsx")
                return BadRequest("File Not Selected");

            var rootFolder = @"D:\Files";
            var fileName = file.FileName;
            var filePath = Path.Combine(rootFolder, fileName);
            var fileLocation = new FileInfo(filePath);

            if (file.Length <= 0)
                throw new Exception("Bad File");

            using (ExcelPackage package = new ExcelPackage(fileLocation))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Table1"];
                int totalRows = workSheet.Dimension.Rows;

                for (int i = 2; i <= totalRows; i++)
                {
                    _userService.IsValidTz(workSheet.Cells[i, 1].Value.ToString() + " " + workSheet.Cells[i, 2].Value.ToString(),
                                            workSheet.Cells[i, 3].Value.ToString(),
                                            (int)workSheet.Cells[i, 4].Value);
                }

            }
            return Ok();

        }
    }
    }
