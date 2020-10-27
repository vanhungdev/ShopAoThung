namespace ShopAoThung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("category")]
    public partial class Mcategory
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public int parentid { get; set; }
        public int orders { get; set; }
        public string metakey { get; set; }
        public string metadesc { get; set; }
        public DateTime? created_at { get; set; }
        public int? created_by { get; set; }
        public DateTime? updated_at { get; set; }
        public int? updated_by { get; set; }
        public int status { get; set; }
    }
}
