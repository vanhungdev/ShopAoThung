namespace ShopAoThung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("menu")]
    public partial class Mmenu
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string link { get; set; }
        public int? tableid { get; set; }
        public int parentid { get; set; }
        public int orders { get; set; }
        public string position { get; set; }
        public DateTime created_at { get; set; }
        public int? created_by { get; set; }
        public DateTime updated_at { get; set; }
        public int? updated_by { get; set; }
        public int status { get; set; }
    }
}
