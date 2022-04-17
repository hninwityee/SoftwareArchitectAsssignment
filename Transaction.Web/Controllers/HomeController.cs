using Transaction.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Transaction.Services.Interfaces;

namespace Transaction.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IFileUploadService _fileUploadService;

        public HomeController(ILogger<HomeController> logger,  IConfiguration config,IFileUploadService fservice)
        {
            _logger = logger;
             _configuration = config;
            _fileUploadService = fservice;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Index(IFormFile postedFile)
        {
            var uploadResponse = _fileUploadService.UploadFile(postedFile);
            if (uploadResponse.ErrorMessage != "")
                return BadRequest(new { error = uploadResponse.ErrorMessage });
            return Ok(uploadResponse);
        }


        //Using sql bulk import
        //[HttpPost] 
        //public IActionResult Index(IFormFile postedFile)
        //{
        //    if (postedFile != null)
        //    {
        //        string path = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }

        //        string fileName = Path.GetFileName(postedFile.FileName);
        //        string filePath = Path.Combine(path, fileName);
        //        using (FileStream stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            postedFile.CopyTo(stream);
        //        }
        //        //Read the contents of CSV file.
        //        string csvData = System.IO.File.ReadAllText(filePath);

        //        //Create a DataTable.
        //        DataTable dt = new DataTable();
        //        dt.Columns.AddRange(new DataColumn[6] { new DataColumn("TransId", typeof(string)),
        //                        new DataColumn("Amount", typeof(decimal)),
        //                        new DataColumn("CurCode", typeof(string)),
        //                        new DataColumn("TransDate", typeof(DateTime)),
        //                        new DataColumn("Status", typeof(string)),
        //                        new DataColumn("FileType",typeof(string)) });



        //        //Execute a loop over the rows.
        //        foreach (string row in csvData.Split('\n'))
        //        {
        //            if (!string.IsNullOrEmpty(row))
        //            {
        //                dt.Rows.Add();
        //                int i = 0;

        //                //Execute a loop over the columns.
        //                string[] cell = row.Split(',');
        //                dt.Rows[dt.Rows.Count - 1][0] = cell[0];
        //                dt.Rows[dt.Rows.Count - 1][1] = cell[1];
        //                dt.Rows[dt.Rows.Count - 1][2] = cell[2];
        //                dt.Rows[dt.Rows.Count - 1][3] = DateTime.ParseExact(cell[3], "dd/MM/yyyy hh:mm:ss", null);//TransDate
        //                dt.Rows[dt.Rows.Count - 1][4] = cell[4];
        //                dt.Rows[dt.Rows.Count - 1][5] = "csv";
        //            }
        //        }

        //        //Save in database 

        //        string conString = _configuration.GetConnectionString("TransactionDBContext");
        //        using (SqlConnection con = new SqlConnection(conString))
        //        {
        //            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
        //            {
        //                //Set the database table name.
        //                sqlBulkCopy.DestinationTableName = "dbo.TransactionLog";

        //                //[OPTIONAL]: Map the DataTable columns with that of the database table
        //                sqlBulkCopy.ColumnMappings.Add("TransId", "TransactionID");
        //                sqlBulkCopy.ColumnMappings.Add("Amount", "Amount");
        //                sqlBulkCopy.ColumnMappings.Add("CurCode", "CurrencyCode");
        //                sqlBulkCopy.ColumnMappings.Add("TransDate", "TransactionDate");
        //                sqlBulkCopy.ColumnMappings.Add("Status", "Status");
        //                sqlBulkCopy.ColumnMappings.Add("FileType", "InputSource");

        //                con.Open();
        //                sqlBulkCopy.WriteToServer(dt);
        //                con.Close();
        //                ViewData["result"] = "Imported successfully!";
        //                TempData["Message"] = "Imported successfully!";
        //            }
        //        }
        //    }
        //    return View();
        //}


    }



}
