using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, IBaseRepository<Customer>
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Customer> SpecialMethod()
        {
            throw new NotImplementedException();
        }
    }

}
