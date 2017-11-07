using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using exp1.Models;

namespace exp1.Controllers
{
    public class CartController : Controller
    {
        private RegContext db = new RegContext();

        //
        // GET: /Cart/

        public ActionResult Index()
        {
            string email = (string)Session["Email_Id"];
            List<Cart> list = db.Carts.Where(c => c.email_id == email).ToList();
            int total = (from s in list select s.price).Sum();
            ViewBag.sum = total;
            return View(list);
        }

        //
        // GET: /Cart/Details/5

        public ActionResult Details(int id = 0)
        {
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        //
        // GET: /Cart/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cart/Create

        [HttpPost]
        public ActionResult Create(Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cart);
        }

        //
        // GET: /Cart/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        //
        // POST: /Cart/Edit/5

        [HttpPost]
        public ActionResult Edit(Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cart);
        }

        //
        // GET: /Cart/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        //
        // POST: /Cart/Delete/5
        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult Checkout()
        {
            string emailid = (string)Session["Email_Id"];
            List<Cart> list = db.Carts.Where(c=>c.email_id==emailid).ToList();
            int total = (from s in list select s.price).Sum();
            ViewBag.Sum = total;
            foreach (Cart item in list)
            {
                Orderr o = new Orderr();
                o.email = item.email_id;
                o.pname = item.product_name;
                o.price = item.price;
                o.status = "Order Recieved";
                if (ModelState.IsValid)
                {
                    db.Orders.Add(o);
                    db.Carts.Remove(item);
                    db.SaveChanges();
                }
            }
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}