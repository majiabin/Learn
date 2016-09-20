using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learn.Core.Domain;

namespace Learn.Data.Mapping
{
   public class UserInfoMap:EntityTypeConfiguration<UserInfo>
    {
       public UserInfoMap()
       {
           this.HasKey(c => c.Id);
       }
    }
}
