namespace ShopAoThung.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("role")]
    public partial class role
    {
        [Key]
        public int ID { get; set; }
        public int parentId { get; set; }
        public string accessName { get; set; }
        public string description { get; set; }
        public string GropID { get; set; }
    }
}
