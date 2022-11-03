using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebNetCoreEFCore_App.Data.Contexts;
using WebNetCoreEFCore_App.Data.Entities;

namespace WebNetCoreEFCore_App.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProjectContext _db;

        public ProductController(ProjectContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            List<Product> plist = _db.Products.ToList();

            List<Product> plist1 = _db.Products.Include(x => x.Category).ToList();

            List<Product> plist2 = _db.Products.Include(x => x.Category).ThenInclude(x=>x.CategorySuppliers). ToList();

            return View();
        }

        public IActionResult EFCoreViews()
        {
            var pView = _db.ProductViews.ToList();

            return View(pView);
        }

        public IActionResult EFCoreStoreProcedures()
        {
            var param1 = new SqlParameter("@ProductName", "Urun-1");
            var param2 = new SqlParameter("@Price", 10.5);
            var param3 = new SqlParameter("@Stock", 30);
            var param4 = new SqlParameter("@CategoryId", 1);

            int result = _db.Database.ExecuteSqlRaw("Exec ProductCreate @ProductName,@Price,@Stock,@CategoryId", param1, param2, param3, param4);

            //int result = _db.Database.ExecuteSqlCommand("Exec ProductCreate @ProductName,@Price,@Stock,@CategoryId", param1, param2, param3, param4);

            if (result > 0)
            {
                ViewBag.Message = "Başarılı";
                return View();
           
            }



            return NotFound();
        }

        public IActionResult EFCoreStoreProcedureDbQuery()
        {
            var param = new SqlParameter("@CategoryId", 1);

            var products = _db.Products.FromSqlRaw("GetProductByCategoryId @CategoryId", param).ToList();

            return View();
        }

    }
}
