using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using RestApi.Data.Entities;
using RestApi.Data.Repositories;
using RestApi.Services;
using System;
using System.IO;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngestsController : ControllerBase
    {
        private readonly IIngestService _ingestService;
        private readonly IIngestRepository _ingestRepository;

        public IngestsController(IIngestService ingestService, IIngestRepository iingestRepository)
        {
            _ingestService = ingestService;
            _ingestRepository = iingestRepository;  
        }
        [HttpGet]
        public IActionResult Get()//nháp
        {
            var entities = _ingestService.Get();
            return Ok(entities);
        }
        [HttpGet("GetBroadcastProgram")]
        public IActionResult GetBroadcastProgram()
        {
            var rs = _ingestService.GetBroadcastProgram();
            return Ok(rs);
        }
        [HttpGet("GetIngestGenre")]
        public IActionResult GetIngestGenre()
        {
            return Ok(_ingestService.GetIngestGenre());
        }
        [HttpPost]
        public IActionResult AddIngest([FromBody]Ingest ingest)
        {
            var rs=_ingestService.AddIngest(ingest);
            return StatusCode(201, rs);
        }

        [HttpGet("Export")]
        public IActionResult Export()
        {

            ////Format Ctrl+A -> Home -> Format -> Column(with, height)

            var stream = new MemoryStream();
            var result = _ingestRepository.Gets();
            var filePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\RestApi.Data\ExcelTemplate\Danh_sach_ingest.xlsx"));
            FileInfo existingFile = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            // If you use EPPlus in a noncommercial context
            // according to the Polyform Noncommercial license:
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet sheet = package.Workbook.Worksheets[0];
                // đổ dữ liệu vào sheet

                int rowId = 4;
                int stt = 1;
                foreach (var row in result)
                {
                    sheet.Cells[rowId, 1].AutoFitColumns(10, 10);
                    for (int i = 1; i <= 9; i++)
                    {
                        // Thêm border cho cột
                        sheet.Cells[rowId, i].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        sheet.Cells[rowId, i].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        sheet.Cells[rowId, i].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        sheet.Cells[rowId, i].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                        // Thêm width vs height cho cột
                        sheet.Cells[rowId, i + 1].AutoFitColumns(20, 20);
                        sheet.Cells[rowId, i + 1].Merge = true;
                    }

                    sheet.Cells[rowId, 1].Value = stt;
                    sheet.Cells[rowId, 2].Value = row.FileName;
                    sheet.Cells[rowId, 3].Value = row.Reporter;
                    sheet.Cells[rowId, 4].Value = row.Subscriber;
                    sheet.Cells[rowId, 5].Value = row.Production;
                    sheet.Cells[rowId, 6].Value = row.film;
                    sheet.Cells[rowId, 7].Value = row.CreateDate;
                    sheet.Cells[rowId, 8].Value = row.Status;
                    sheet.Cells[rowId, 9].Value = row.CreateBy;
                    stt++;
                    rowId++;
                }
                stream = new MemoryStream(package.GetAsByteArray());
            }
            stream.Position = 0;
            var fileName = $"DanhSachPhieuIngest_{DateTime.Now.ToString("dd-MM-yyyy")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }

    }
}
