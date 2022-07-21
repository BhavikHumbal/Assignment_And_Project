using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cookies.Controllers
{
    public class bhavikController : Controller
    {
        // GET: bhavik
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            string uname = fc["txtuname"];
            string pass = fc["txtpass"];

            if(uname=="bhavik" && pass=="1234")
            {
                HttpCookie couname = new HttpCookie("uname");
                couname.Expires = DateTime.Now.AddDays(2);
                couname.Value = uname;
                Response.Cookies.Add(couname);

                HttpCookie copass = new HttpCookie("pass");
                copass.Expires = DateTime.Now.AddDays(2);
                copass.Value = pass;
                Response.Cookies.Add(copass);
            }
            return View();
        }

        public ActionResult querystring()
        {
            return View();
        }
        public ActionResult GetQ(string fname, string mobile)
        {
            ViewBag.fname = fname;
            ViewBag.mobile = mobile;
            return View();
        }

        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(FormCollection fc)
        {
            string uname = fc["txtname"];
            string pass = fc["txtpass"];

            if(uname=="bhavik" && pass=="1234")
            {
                Session["uname"] = uname;
                Session["pass"] = pass;
                Session.Timeout = 30;
                return RedirectToAction("Homepage");
            }
            else
            {
                ViewBag.loginerror = "invalid user name or password..";
            }
            return View();
        }
        public ActionResult Homepage()
        {
            return View();
        }

        public ActionResult logout()
        {
            Session.Abandon();
            return RedirectToAction("login");
        }

        public ActionResult svar()
        {
            ViewData["info"] = "waiting infi ti view data";
            ViewBag.msg = "waiting message to view bag";
            TempData["data"] = "displaying data from temp data";
            return View();
        }

        public ActionResult second()
        {
            return View();
        }
    }
}