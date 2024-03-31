using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; } 
        public int ItemId { get; set; } 
        public decimal ItemPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Order Order { get; set; }
        public virtual Item Item { get; set; }
    }

}
