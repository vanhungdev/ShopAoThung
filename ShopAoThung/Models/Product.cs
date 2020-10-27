namespace ShopAoThung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int ID { get; set; }
        public int catid { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public string img { get; set; }
        public string detail { get; set; }
        public double price { get; set; }
        public double pricesale { get; set; }
        public int number { get; set; }
        public int sold { get; set; }
        public DateTime created_at { get; set; }
        public int created_by { get; set; }  
        public int status { get; set; }
    }
}
