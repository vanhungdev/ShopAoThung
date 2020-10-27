namespace ShopAoThung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ordersdetail")]
    public partial class Mordersdetail
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }
        public int orderid { get; set; }
        public int productid { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public int priceSale { get; set; }
        public double amount { get; set; }
    }
}
