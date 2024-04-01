using Microsoft.Extensions.Configuration;
using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Services
{
    public class OrderService : IOrderService
    {
        private readonly string _promoCode;
        private readonly decimal _discountValue;

        public OrderService(IConfiguration configuration)
        {
            _promoCode = configuration["DiscountSettings:PromoCode"];
            _discountValue = decimal.Parse(configuration["DiscountSettings:DiscountValue"]);
        }

        public decimal ApplyDiscountIfApplicable(Order order)
        {
            if (!string.IsNullOrWhiteSpace(order.DiscountPromoCode) && order.DiscountPromoCode.Equals(_promoCode, StringComparison.OrdinalIgnoreCase))
            {
                
                order.TotalPrice -= _discountValue;


                return _discountValue; 
            }

            return 0; 
        }
    }

}
