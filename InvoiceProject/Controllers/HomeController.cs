using InvoiceProject.Data;
using InvoiceProject.Models;
using InvoiceProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InvoiceProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Invoice()
        {
            return View(new BuyInvoiceViewModel
            {
                CategoriesList = _context.Categories.Where(x => x.CurrentState > 0 && x.BranchId == 2).ToList(),
                SuppllierList = _context.Suppliers.Where(x => x.CurrentState > 0 && x.BranchId == 2).ToList()

            });
        }

        public IActionResult GetProduct(int? id)
        {
            return Json(_context.Products.Where(x => x.CurrentState > 0 && x.BranchId == 2 && x.CategoryId == id).ToList());
        }

        public IActionResult GetPriceProduct(int? id)
        {
            return Json(_context.Products.FirstOrDefault(x => x.CurrentState > 0 && x.BranchId == 2 && x.ProductId == id));
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
    }
}
