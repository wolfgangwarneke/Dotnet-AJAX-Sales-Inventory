using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimelinePleaseWork.Models
{
    [Table("InventoryItems")]
    public class InventoryItem
    {
        [Key]
        public int InventoryItemId { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }
}
