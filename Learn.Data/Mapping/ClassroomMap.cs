using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;

namespace Learn.Data.Mapping
{
    public class ClassroomMap : EntityTypeConfiguration<Classroom>
    {
        public ClassroomMap()
        {
            this.HasKey(c => c.ClassId);
        }
    }
}
