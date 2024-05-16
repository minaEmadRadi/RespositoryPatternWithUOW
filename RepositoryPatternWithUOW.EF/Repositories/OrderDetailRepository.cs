using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {

        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<OrderDetail> SpecialMethod()
        {
            throw new NotImplementedException();
        }
    }

}
