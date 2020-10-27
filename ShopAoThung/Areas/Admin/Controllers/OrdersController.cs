using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopAoThung.Common;
using ShopAoThung.Models;

namespace ShopAoThung.Areas.Admin.Controllers
{
    [CustomAuthorizeAttribute(RoleID = "ADMIN")]
    public class OrdersController : BaseController
    {
        private BookstoreDbContext db = new BookstoreDbContext();

        // GET: Admin/Orders
        public ActionResult Index()
        {
            var list = db.Orders.Where(m => m.status != 0).OrderByDescending(m => m.ID).ToList();
            return View(list);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.customer = db.Orders.Where(m => m.ID == id).First();
            var lisst = db.Ordersdetails.Where(m => m.orderid == id).ToList();
            return View("Orderdetail", lisst);
        }
        //status
        public ActionResult Status(int id)
        {
            Morder morder = db.Orders.Find(id);
            morder.status = (morder.status == 1) ? 2 : 1;
            morder.updated_at = DateTime.Now;
            morder.updated_by = int.Parse(Session["Admin_id"].ToString());
            db.Entry(morder).State = EntityState.Modified;
            db.SaveChanges();
            Message.set_flash("Thay đổi trang thái thành công", "success");
            return RedirectToAction("Index");
        }
        //trash
        public ActionResult trash()
        {
            var list = db.Orders.Where(m => m.status == 0).ToList();
            return View("Trash", list);
        }
        public ActionResult Deltrash(int id)
        {
            Morder morder = db.Orders.Find(id);
            morder.status = 0;
            morder.updated_at = DateTime.Now;
            morder.updated_by = int.Parse(Session["Admin_id"].ToString());
            db.Entry(morder).State = EntityState.Modified;
            db.SaveChanges();
            Message.set_flash("Xóa thành công", "success");
            return RedirectToAction("Index");
        }

        public ActionResult Retrash(int id)
        {
            Morder morder = db.Orders.Find(id);
            morder.status = 2;
            morder.updated_at = DateTime.Now;
            morder.updated_by = int.Parse(Session["Admin_id"].ToString());
            db.Entry(morder).State = EntityState.Modified;
            db.SaveChanges();
            Message.set_flash("Khôi phục thành công", "success");
            return RedirectToAction("trash");
        }
        public ActionResult deleteTrash(int id)
        {
            Morder morder = db.Orders.Find(id);
            db.Orders.Remove(morder);
            db.SaveChanges();
            Message.set_flash("Đã xóa vĩnh viễn 1 Đơn hàng", "success");
            return RedirectToAction("trash");
        }
    }
}
