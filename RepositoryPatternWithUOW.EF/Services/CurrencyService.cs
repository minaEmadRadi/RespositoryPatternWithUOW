using Microsoft.Extensions.Configuration;
using RepositoryPatternWithUOW.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly string _basicCurrency;

        public CurrencyService(IConfiguration configuration)
        {
            _basicCurrency = configuration["ApplicationSettings:BasicCurrency"];
        }

        public void PerformCurrencyOperation()
        {
            Console.WriteLine($"Using basic currency: {_basicCurrency}");
        }
    }

}
