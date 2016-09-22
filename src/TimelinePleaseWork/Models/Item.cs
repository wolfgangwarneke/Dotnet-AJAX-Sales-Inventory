using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimelinePleaseWork.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int CostCents { get; set; }
        public string Description { get; set; }
        public InventoryItem InventoryItem { get; set; }
    }
}
