using Microsoft.AspNetCore.Mvc;
using SalesReportUI.Models;
using SalesReportUI.Service;
using System.Diagnostics;

using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;
using System.Collections.Generic;
using System.Text;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace SalesReportUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;
        private readonly IConverter _converter;

        public HomeController(IApiService apiService, IConverter converter)
        {
            _apiService = apiService;
            _converter = converter;
        }     

        public async Task<IActionResult> Index(SalesFilter filter)
        {
            //List<SalesOrderDetails> list = await _apiService.GetSalesOrderDetailsAsync();
            var list = await _apiService.GetSalesOrderDetailsAsync();
            var yearsResult = await _apiService.GetAllYears();
            var years = yearsResult.Select(y => y.OrderDate).ToList();

            var model = new SalesReport
            {
                SalesOrderDetails = list,
                Years = years
            };    
            return View(model);
            //return View(list);
        }

        public IActionResult DowloadPDF()
        {
            string pagActually = HttpContext.Request.Path;
            string url_pag = HttpContext.Request.GetEncodedUrl();
            url_pag = url_pag.Replace(pagActually, "");
            url_pag = $"{url_pag}";


            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = {
                    new ObjectSettings(){
                        Page = url_pag
                    }
                }
            };

            var archivoPDF = _converter.Convert(pdf);
            string nombrePDF = "report_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            return File(archivoPDF, "application/pdf", nombrePDF);
        }

        
        public async Task<IActionResult> Privacy(SalesFilter filter)
        {
            var list = await _apiService.GetSalesPerson();
            var yearsResult = await _apiService.GetAllYears();
            var years = yearsResult.Select(y => y.OrderDate).ToList();
            var model = new SalesReport
            {
                SalesPerson = list,
                Years = years
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
