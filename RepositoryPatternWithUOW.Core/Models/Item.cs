using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class Item
    {
        public Item()
        {
            OrderDetails=new HashSet<OrderDetail>();
        }
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int UomId { get; set; } 
        public decimal Price { get; set; }
        public int QTY { get; set; }

       
        public virtual UOM UOM { get; set; } 
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

}
