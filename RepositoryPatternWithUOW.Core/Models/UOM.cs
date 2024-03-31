using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.Core.Models
{
    public class UOM
    {
        public UOM()
        {
            Items =new HashSet<Item>();
        }
        public int Id { get; set; }
        [Column("UOM")]
        public string UOMName { get; set; } 
        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }

}
