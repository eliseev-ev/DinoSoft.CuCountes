using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.Data.Common.Model
{
    /// <summary>Модель с идентификатором.</summary>
    /// <typeparam name="T">Тип идентификатора.</typeparam>
    public interface IIdentityModel<T>
    {
        /// <summary>Идентификатор.</summary>
        T Id { get; set; }
    }
}
