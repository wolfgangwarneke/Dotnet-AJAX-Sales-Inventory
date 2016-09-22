using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimelinePleaseWork.Models
{
    [Table("Sales")]
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        public int UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Comment { get; set; }
        public DateTime Timestamp { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
