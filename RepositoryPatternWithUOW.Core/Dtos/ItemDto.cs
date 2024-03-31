using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Dtos
{
    public class ItemDto
    {
        public int? Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int UomId { get; set; } 
        public decimal Price { get; set; }
        public int Qty { get; set; } 
    }

}
