using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Dtos
{
    public class CurrencyExchangeRateDto
    {
        public string CurrencyCode { get; set; }
        public decimal ExchangeRate { get; set; }
    }

}
