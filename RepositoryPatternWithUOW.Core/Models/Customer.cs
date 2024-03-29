using Microsoft.AspNetCore.Identity;
using RepositoryPatternWithUOW.Core.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class Customer 
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } 

        public ICollection<Order> Orders { get; set; }
    }

}
