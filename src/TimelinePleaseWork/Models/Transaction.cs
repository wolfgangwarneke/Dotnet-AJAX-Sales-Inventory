using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimelinePleaseWork.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public int Quantity { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public string Note { get; set; }
        public int SaleId { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
