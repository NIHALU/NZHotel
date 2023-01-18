using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Entities
{
    public class Shift:BaseEntity
    {
        public bool Morning { get; set; }
        public bool Noon { get; set; }
        public bool Evening { get; set; }
        public bool Regular { get; set; }
        public bool Overtime { get; set; }
    }
}
