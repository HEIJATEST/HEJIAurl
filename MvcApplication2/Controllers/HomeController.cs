using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiContrib.Filters;
using WebApiContrib.Selectors;
using System.IO;
using MvcApplication2.Models;


namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult JQGrid()
        {
            return View();
        }

        [EnableCors]
        public ActionResult Exhibition()
        {
            return View();
        }

        [EnableCors]
        public ActionResult Exhibition_Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Exhibition_Add(String ExhibitionName, IEnumerable<HttpPostedFileBase> files, IEnumerable<HttpPostedFileBase> iconfiles, IEnumerable<HttpPostedFileBase> mapfiles, String test_p, String test_i, String test_m)
        {

            ViewBag.ed = ExhibitionName;
                foreach (var file in files)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(test_p);
                        var path = Path.Combine(Server.MapPath("~/Images/Exhibition_picture"), fileName);
                        file.SaveAs(path);
                    }
                }
           
           


                foreach (var file in mapfiles)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(test_m);
                        var path = Path.Combine(Server.MapPath("~/Images/Exhibition_picture"), fileName);
                        file.SaveAs(path);
                    }
                }

                foreach (var file in iconfiles)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(test_i);
                        var path = Path.Combine(Server.MapPath("~/Images/Exhibition_icon"), fileName);
                        file.SaveAs(path);
                    }
                }

                // after successfully uploading redirect the user
                return RedirectToAction("Exhibitors_Detail", "Home");
            
        }
        [EnableCors]
        public ActionResult Exhibition_revise(string exhibition_name)
        {

            ViewBag.ed = exhibition_name;
            return View();
        }
        [EnableCors]
        public ActionResult Exhibitors(string exhibitors_name)
        {
            ViewBag.ed = exhibitors_name;
            return View();
        }
         [EnableCors]
        public ActionResult Exhibitors_Add()
        {
            return View();
        }
        [EnableCors]
        public ActionResult Exhibitors_revise(string exhibitors_name)
        {
            ViewBag.ed = exhibitors_name;
            return View();
        }
        [EnableCors]
        public ActionResult Product()
        {         
            return View();
        }
        [EnableCors]
        public ActionResult Product_Add()
        {
            return View();
        }
        [EnableCors]
        public ActionResult Product_revise()
        {
            return View();
        }
        [EnableCors]
        public ActionResult Member()
        {
           return View();
        }
        [EnableCors]
        public ActionResult Member_revise(string member_account, string name)
        {
            ViewBag.ma = member_account;
            ViewBag.n = name;
            

            return View();
        }
        [HttpPost]
        public ActionResult Member_revise(string account, string name, string sex, string qq, string phone, string password, string birthday)
        {
            ViewData["account"] = account;
            ViewData["name"] = name;
            ViewData["sex"] = sex;
            ViewData["qq"] = qq;
            ViewData["phone"] = phone;
            ViewData["password"] = password;
            ViewData["birthday"] = birthday;
          

            return View();
        }
        [EnableCors]
        public ActionResult Exhibition_Detail(string exhibition_name)
        {

            ViewBag.ed = exhibition_name;
            return View();
        }
        [EnableCors]
        public ActionResult Exhibitors_Detail(string exhibitor_name)
        {
            ViewBag.en = exhibitor_name;
            return View();
        }

        [HttpPost]
        public ActionResult MultiUpload(IEnumerable<HttpPostedFileBase> files)
    {
        foreach (var file in files)
        {
        if (file != null && file.ContentLength >0)
        {
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/Images/profile"),fileName);
            file.SaveAs(path);
        }
       }
        // after successfully uploading redirect the user
        return RedirectToAction("Exhibitors_Detail", "Home");
    }



    }

  
}
