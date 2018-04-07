using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TubaSaday.Models;
using TubaSaday.Utils;

namespace TubaSaday.Controllers
{
    public class HomeController : Controller
    {
        public  ProductContext _con=new ProductContext();
       
        public ActionResult Index()

        {
            var exist=_con.Database.Exists();
            if (exist==true)
            {
                CreateCache.Create();
                return RedirectToAction("List", "Home");
            }
            else
            {
                return RedirectToAction("Connect", "Home");
            }
            return View();
        }


        public ActionResult Connect()
        {
            return View(new ConnectionString());
        }


        [HttpPost]
        public ActionResult Connect(ConnectionString model)
        {
            
            ////ilk açılış cache'i tetikledik
            //CreateCache.Create();
            ////we are updating connection string on web.config
            var updatedResult = UpdateConfig.update(model.connectionString);
            CreateDB.create();
            CreateCache.Create();
            //return RedirectToAction("Product", "Index");
            return RedirectToAction("List","Home");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Nasıl Kullanılır";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Proje Yazarı hakkında";

            return View();
        }

        public ActionResult List()
        {
            ViewBag.Message = "Your contact page.";
            var products = CreateCache.cache["Products"] as List<Product>;
            return View(products);
        }
    }
}