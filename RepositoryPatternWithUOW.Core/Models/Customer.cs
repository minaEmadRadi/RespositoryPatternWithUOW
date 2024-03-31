using Microsoft.AspNetCore.Identity;
using RepositoryPatternWithUOW.Core.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class Customer : IdentityUser
    {

        public string CustomerName { get; set; }


        public ICollection<Order> Orders { get; set; }
    }

}
