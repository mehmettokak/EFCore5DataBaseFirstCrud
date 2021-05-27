using EFCORE5.Models;
using EFCORE5.Models.DataBaseFirstPostgreSql.Entity;
using EFCORE5.Models.DataBaseFirstPostgreSql.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EFCORE5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private readonly dbEFContext _db;
        private readonly dbPostgreSqlContext _db;
        public HomeController(ILogger<HomeController> logger/*, dbEFContext db*/, dbPostgreSqlContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult Add()
        {
            var time = DateTime.Now.Millisecond;
            var model = new Person()
            {
                Firstname = "Firstname_" + time,
                Lastname = "LastName_" + time
            };
            _db.People.Add(model);
            return Json(_db.SaveChanges() > 0 ? model.Firstname + " Ekleme başarılı." : "Ekleme başarısız!!!");
        }
        public JsonResult GetModel(int id)
        {
            var model = _db.People.Where(x => x.Id == id).FirstOrDefault();
            return Json(model);
        }
        public JsonResult GetList()
        {
            var list = _db.People.ToList();
            return Json(list);
        }

        public JsonResult Update(int id)
        {
            var model = _db.People.Where(x => x.Id == id).FirstOrDefault();
            model.Firstname += "_updated_" + DateTime.Now.Millisecond;
            return Json(_db.SaveChanges() > 0 ? model.Lastname + " Güncelleme başarılı." : "Güncelleme başarısız!!!");
        }


        public JsonResult Delete(int id)
        {
            var model = _db.People.Where(x => x.Id == id).FirstOrDefault();
            _db.Remove(model);
            return Json(_db.SaveChanges() > 0 ? model.Firstname + " Silme işlemi başarılı." : "silme işlemi başarısız!!!");
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
