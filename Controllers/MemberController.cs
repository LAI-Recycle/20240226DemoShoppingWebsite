using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DemoShoppingWebsite.Models;

namespace DemoShoppingWebsite.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        dbShoppingCarEntities db = new dbShoppingCarEntities();

        public ActionResult Index()
        {
            var products = db.table_Product.OrderByDescending(m => m.Id).ToList();
            return View("../Home/Index", "_LayoutMember", products);

            // viewName�]�i�H�N������|�g�X�ӡA���W��g�k����²��
            //return View("~/Views/Home/Index.cshtml", "_LayoutMember", products);
        }

        public ActionResult Logout()
        {
            //using System.Web.Security;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult ShoppingCar()
        {
            string UserId = User.Identity.Name;

            var orderDetails = db.table_OrderDetail.Where(m => m.UserId == UserId && m.IsApproved == "�_").ToList();
            return View(orderDetails);
        }
    }
}