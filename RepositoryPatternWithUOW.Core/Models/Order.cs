using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime? CloseDate { get; set; } 
        public string Status { get; set; }
        public int CustomerId { get; set; } 
        public string DiscountPromoCode { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal TotalPrice { get; set; }
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal ForignPrice { get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }

}
