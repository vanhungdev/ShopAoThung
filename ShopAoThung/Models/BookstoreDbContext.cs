using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ShopAoThung.Models;
using System.Web.UI.WebControls;

namespace ShopAoThung.Models
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext() : base("name=ChuoiKN")
        { }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Mcategory> Categorys { get; set; }
        public virtual DbSet<Morder> Orders { get; set; }
        public virtual DbSet<Mordersdetail> Ordersdetails { get; set; }
        public virtual DbSet<role> Roles { get; set; }
        public virtual DbSet<Mmenu> Menus { get; set; }
       
        public virtual DbSet<Muser> Users { get; set; }
        public virtual DbSet<Mslider> Sliders { get; set; }
        public virtual DbSet<link> Link { get; set; }
        internal int ExecuteScalar()
        {
            throw new NotImplementedException();
        }
    }
}
