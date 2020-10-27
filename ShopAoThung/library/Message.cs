using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopAoThung
{
    public static class Message
    {
        public static bool has_flash()
        {
            if (System.Web.HttpContext.Current.Session["Message"].Equals("")) {
                return false;
            }
            return true;
        }
        public static void set_flash(String msg, String msg_css) {
            MessageModel ms = new MessageModel();
            ms.msg = msg;
            ms.msg_css = msg_css;
            System.Web.HttpContext.Current.Session["Message"]=ms;
        }
         public static MessageModel get_flash() {
            MessageModel ms = (MessageModel)System.Web.HttpContext.Current.Session["Message"];
            System.Web.HttpContext.Current.Session["Message"] = "";
            return ms;
        }
    }
}
//var listPost = db.Posts.ToList();
//var product = db.Books.ToList();
//var cate = db.Categorys.ToList();
//var topic = db.Topics.ToList();

//foreach (var item in listPost) {
//    link tt_link = new link();
//    tt_link.slug = item.slug+".aspx";
//    tt_link.tableId = 3;
//    tt_link.type = "PostDetail";
//    tt_link.parentId = item.ID;
//    db.Link.Add(tt_link);
//    db.SaveChanges();
//}
//foreach (var item in product)
//{
//    link tt_link = new link();
//    tt_link.slug = item.slug + ".aspx";
//    tt_link.tableId = 1;
//    tt_link.type = "ProductDetail";
//    tt_link.parentId = item.ID;
//    db.Link.Add(tt_link);
//    db.SaveChanges();
//}
//foreach (var item in cate)
//{
//    link tt_link = new link();
//    tt_link.slug = item.slug + ".aspx";
//    tt_link.tableId = 2;
//    tt_link.type = "category";
//    tt_link.parentId = item.ID;
//    db.Link.Add(tt_link);
//    db.SaveChanges();
//}
//foreach (var item in topic)
//{
//    link tt_link = new link();
//    tt_link.slug = item.slug + ".aspx";
//    tt_link.tableId = 4;
//    tt_link.type = "topic";
//    tt_link.parentId = item.ID;
//    db.Link.Add(tt_link);
//    db.SaveChanges();
//}