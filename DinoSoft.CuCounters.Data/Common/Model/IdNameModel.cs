using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.Data.Common.Model
{
    public abstract class IdNameModel : IIdentityModel<Guid>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
