using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bQsLoanModule.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult LoanEqual()
        {
            ViewBag.Title = "Loan equal installments";

            return View();
        }
        public ActionResult LoanDecreasing()
        {
            ViewBag.Title = "Loan decreasing installments";

            return View();
        }
        public ActionResult About() {
            ViewBag.Title = "About";

            return View();
        }
    }
}
