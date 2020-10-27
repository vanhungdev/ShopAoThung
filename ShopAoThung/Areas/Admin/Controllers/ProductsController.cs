using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;

using System.Web;
using System.Web.Mvc;
using ShopAoThung.Common;
using ShopAoThung.Models;

namespace ShopAoThung.Areas.Admin.Controllers
{
    [CustomAuthorizeAttribute(RoleID = "SALESMAN")]
    public class ProductsController : BaseController
    {
        private BookstoreDbContext db = new BookstoreDbContext();       
        // GET: Admin/Products
        public ActionResult Index()
        {
           
            var list = db.Products.Where(m => m.status != 0).OrderByDescending(m=>m.ID).ToList(); 
            return View(list);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            
            ViewBag.listCate = db.Categorys.Where(m => m.status != 0).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(Product mbook , HttpPostedFileBase file)
        {
            ViewBag.listCate = db.Categorys.Where(m => m.status != 0 && m.ID > 2).ToList();
            if (ModelState.IsValid)
            {
                string slug = Mystring.ToSlug(mbook.name.ToString());
                if (db.Categorys.Where(m => m.slug == slug).Count() > 0)
                {
                    Message.set_flash("Sản phẩm đã tồn tại trong bảng Category", "danger");
                    return View(mbook);
                }
               
                if (db.Products.Where(m => m.slug == slug).Count() > 0)
                {
                    Message.set_flash(" Sản phẩm đã tồn tại trong bảng book", "danger");
                    return View(mbook);
                }
                // lấy tên loại sản phẩm
                var namecateDb = db.Categorys.Where(m => m.ID == mbook.catid).First();
                string namecate = Mystring.ToStringNospace(namecateDb.name);
                // lấy tên ảnh
                file = Request.Files["img"];
                string filename =  file.FileName.ToString();
                //lấy đuôi ảnh
                string ExtensionFile = Mystring.GetFileExtension(filename);
                // lấy tên sản phẩm làm slug
               
                //lấy tên mới của ảnh slug + [đuôi ảnh lấy đc]
                string namefilenew = namecate+"/"+slug + "." + ExtensionFile;
                //lưu ảnh vào đường đẫn
                var path = Path.Combine(Server.MapPath("~/public/images/product"), namefilenew);
                //nếu thư mục k tồn tại thì tạo thư mục
                var folder = Server.MapPath("~/public/images/product/"+ namecate);
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                file.SaveAs(path);
                mbook.img = namefilenew;
                mbook.slug = slug;
             
                mbook.created_at = DateTime.Now;
                mbook.sold = 0;
                mbook.created_by = int.Parse(Session["Admin_id"].ToString());
                db.Products.Add(mbook);
                db.SaveChanges();
                //create Link
                link tt_link = new link();
                tt_link.slug = slug;
                tt_link.tableId = 1;
                tt_link.type = "ProductDetail";                
                tt_link.parentId  = mbook.ID;
                db.Link.Add(tt_link);
                db.SaveChanges();

                Message.set_flash("Thêm thành công", "success");
                return RedirectToAction("index");
            }
            Message.set_flash("Thêm Thất Bại", "danger");
            return View(mbook);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product mbook = db.Products.Find(id);
            if (mbook == null)
            {
                return HttpNotFound();
            }
            ViewBag.listCate = db.Categorys.Where(m => m.status != 0).ToList();
            return View(mbook);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit( Product mbook, HttpPostedFileBase file)
        {
           
            if (ModelState.IsValid)
            {

                string slug = Mystring.ToSlug(mbook.name.ToString());
                file = Request.Files["img"];
                string filename = file.FileName.ToString();
                if (filename.Equals("") == false)
                {
                    var namecateDb = db.Categorys.Where(m => m.ID == mbook.catid).First();
                    string namecate = Mystring.ToStringNospace(namecateDb.name);
                    string ExtensionFile = Mystring.GetFileExtension(filename);
                    string namefilenew = namecate + "/" + slug + "." + ExtensionFile;
                    var path = Path.Combine(Server.MapPath("~/public/images/product"), namefilenew);
                    var folder = Server.MapPath("~/public/images/product/" + namecate);
                    if (!Directory.Exists(folder))
                    {
                        Directory.CreateDirectory(folder);
                    }
                    file.SaveAs(path);
                    mbook.img = namefilenew;
                }
                mbook.slug = slug;
                try
                {
                    var thisLink = db.Link.Where(m => m.tableId == 1 && m.parentId == mbook.ID).First();
                    link tt_link = db.Link.Find(thisLink.ID);
                    tt_link.slug = slug;
                    tt_link.tableId = 1;
                    tt_link.parentId = mbook.ID;
                    db.Entry(tt_link).State = EntityState.Modified;
                }
                catch (Exception)
                {
                    //no runing
                }

                db.Entry(mbook).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.listCate = db.Categorys.Where(m => m.status != 0 && m.ID > 2).ToList();
                Message.set_flash("Sửa thành công", "success");
                return RedirectToAction("Index");
            }
            Message.set_flash("Sửa thất bại", "danger");
            ViewBag.listCate = db.Categorys.Where(m => m.status != 0 && m.ID > 2).ToList();
            return View(mbook);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product mbook = db.Products.Find(id);
            if (mbook == null)
            {
                return HttpNotFound();
            }
            return View(mbook);
        }
        public ActionResult Status(int id)
        {
            Product mbook = db.Products.Find(id);
            mbook.status = (mbook.status == 1) ? 2 : 1;
            db.Entry(mbook).State = EntityState.Modified;
            db.SaveChanges();
            Message.set_flash("Thay đổi trang thái thành công", "success");
            return RedirectToAction("Index");
        }
        public ActionResult trash()
        {
            var list = db.Products.Where(m => m.status == 0).ToList();
            return View("Trash", list);
        }
        public ActionResult Deltrash(int id)
        {
            Product mbook = db.Products.Find(id);
            mbook.status = 0;
            db.Entry(mbook).State = EntityState.Modified;
            db.SaveChanges();
            Message.set_flash("Xóa thành công", "success");
            return RedirectToAction("Index");
        }
        public ActionResult Retrash(int id)
        {
            Product mbook = db.Products.Find(id);
            mbook.status = 2;
            db.Entry(mbook).State = EntityState.Modified;
            db.SaveChanges();
            Message.set_flash("khôi phục thành công", "success");
            return RedirectToAction("trash");
        }
        public ActionResult deleteTrash(int id)
        {
            Product mbook = db.Products.Find(id);
            try
            {
                var thisLink = db.Link.Where(m => m.tableId == 1 && m.parentId == mbook.ID).First();
                link tt_link1 = db.Link.Find(thisLink.ID);
                db.Link.Remove(tt_link1);
            }
            catch (Exception)
            {
                //no runing
            }
            db.Products.Remove(mbook);
            db.SaveChanges();
            Message.set_flash("Đã xóa vĩnh viễn 1 sản phẩm", "success");
            return RedirectToAction("trash");
        }

    }
}
