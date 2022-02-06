using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.Data.Infrastructure.Model
{
    public abstract class IdNameModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
