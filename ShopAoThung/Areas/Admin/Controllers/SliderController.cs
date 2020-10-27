using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Web.Mvc;
using ShopAoThung.Models;
using ShopAoThung.Common;

namespace ShopAoThung.Areas.Admin.Controllers
{
    [CustomAuthorizeAttribute(RoleID = "ADMIN")]
    public class SliderController : BaseController
    {
        private BookstoreDbContext db = new BookstoreDbContext();

        // GET: Admin/Slider
        public ActionResult Index()
        {
            var list = db.Sliders.Where(m => m.status != 0).OrderByDescending(m => m.ID).ToList();
            return View(list);
        }

        // GET: Admin/Slider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mslider mslider = db.Sliders.Find(id);
            if (mslider == null)
            {
                return HttpNotFound();
            }
            return View(mslider);
        }

        // GET: Admin/Slider/Create
        public ActionResult Create()
        {
            ViewBag.listCate = db.Sliders.Where(m => m.status != 0 ).ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mslider mslider, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                file = Request.Files["img"];
                string filename = file.FileName.ToString();
                string slug = Mystring.ToSlug(mslider.name.ToString());
                string ExtensionFile = Mystring.GetFileExtension(filename);
                string namefilenew = slug + "." + ExtensionFile;
                var path = Path.Combine(Server.MapPath("~/public/images/bg-images"), namefilenew);

                file.SaveAs(path);
                mslider.url = slug;
                mslider.img = namefilenew;
                mslider.created_at = DateTime.Now;
                mslider.updated_at = DateTime.Now;
                mslider.created_by = int.Parse(Session["Admin_id"].ToString());
                mslider.updated_by = int.Parse(Session["Admin_id"].ToString());
                db.Sliders.Add(mslider);
                db.SaveChanges();
                Message.set_flash("Thêm thành công", "success");
                return RedirectToAction("Index");
            }
            Message.set_flash("Thêm thất bại", "danger");
            return View(mslider);
        }
        public ActionResult Edit(int? id)
        {
            ViewBag.listCate = db.Sliders.Where(m => m.status != 0).ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mslider mslider = db.Sliders.Find(id);
            if (mslider == null)
            {
                return HttpNotFound();
            }
           
            return View(mslider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Mslider mslider)
        {
           
            if (ModelState.IsValid)
            {
                string slug = Mystring.ToSlug(mslider.name.ToString());
                HttpPostedFileBase file = Request.Files["img"];
                string filename = file.FileName.ToString();
                if (filename.Equals("") == false)
                {
                    string ExtensionFile = Mystring.GetFileExtension(filename);
                    string namefilenew = slug + "." + ExtensionFile;
                    var path = Path.Combine(Server.MapPath("~/public/images/bg-images"), namefilenew);
                    file.SaveAs(path);
                    mslider.img = namefilenew;
                }
                mslider.url = slug;
                mslider.updated_at = DateTime.Now;
                mslider.updated_by = int.Parse(Session["Admin_id"].ToString());
                db.Entry(mslider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.listCate = db.Sliders.Where(m => m.status != 0).ToList();
            return View(mslider);
        }
        public ActionResult Status(int id)
        {
            Mslider mslider = db.Sliders.Find(id);
            mslider.status = (mslider.status == 1) ? 2 : 1;
            mslider.updated_at = DateTime.Now;
            mslider.updated_by = int.Parse(Session["Admin_id"].ToString());
            db.Entry(mslider).State = EntityState.Modified;
            db.SaveChanges();
            Message.set_flash("Thay đổi trang thái thành công", "success");
            return RedirectToAction("Index");
        }
        public ActionResult trash()
        {
            var list = db.Sliders.Where(m => m.status == 0).ToList();
            return View("Trash", list);
        }
        public ActionResult Deltrash(int id)
        {
            Mslider mslider = db.Sliders.Find(id);
            mslider.status = 0;
            mslider.updated_at = DateTime.Now;
            mslider.updated_by = int.Parse(Session["Admin_id"].ToString());
            db.Entry(mslider).State = EntityState.Modified;
            db.SaveChanges();
            Message.set_flash("Xóa thành côngss", "success");
            return RedirectToAction("Index");
        }
        public ActionResult Retrash(int id)
        {
            Mslider mslider = db.Sliders.Find(id);
            mslider.status = 2;
            mslider.updated_at = DateTime.Now;
            mslider.updated_by = int.Parse(Session["Admin_id"].ToString());
            db.Entry(mslider).State = EntityState.Modified;
            db.SaveChanges();
            Message.set_flash("khôi phục thành công", "success");
            return RedirectToAction("trash");
        }
        public ActionResult deleteTrash(int id)
        {
            Mslider mslider = db.Sliders.Find(id);
            db.Sliders.Remove(mslider);
            db.SaveChanges();
            Message.set_flash("Đã xóa vĩnh viễn 1 Ảnh bìa", "success");
            return RedirectToAction("trash");
        }

    }
}
