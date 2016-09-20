using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Core.Domain
{
    public class Classroom
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassNumber { get; set; }
        public virtual Student Student { get; set; }
    }
}
