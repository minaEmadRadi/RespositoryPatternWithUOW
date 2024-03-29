using RepositoryPatternWithUOW.Core.Interfaces;
using RepositoryPatternWithUOW.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class UOMRepository : BaseRepository<UOM>, IBaseRepository<UOM>
    {
        private readonly ApplicationDbContext _context;

        public UOMRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<UOM> SpecialMethod()
        {
            throw new NotImplementedException();
        }
    }

}
