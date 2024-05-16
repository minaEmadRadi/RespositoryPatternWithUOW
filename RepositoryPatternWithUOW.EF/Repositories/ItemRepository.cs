using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {

        public ItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Item> SpecialMethod()
        {
          return  _context.Items.ToList();
        }
    }

}
