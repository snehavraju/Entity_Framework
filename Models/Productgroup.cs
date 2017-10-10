using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;



namespace TodoApi.Models
{
    [Table("Product_Group")]
    public class ProductGroup
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        
        
    }
}