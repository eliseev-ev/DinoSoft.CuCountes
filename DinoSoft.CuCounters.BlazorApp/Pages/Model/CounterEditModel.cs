using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoSoft.CuCounters.BlazorApp.Pages.Model
{
    internal class CounterEditModel
    {
        [Required]
        [StringLength(30, ErrorMessage = "Name is too long.")]
        public string Name { get; set; }

        [Required]
        [Range(-999999, 999999, ErrorMessage = "Accommodation invalid (-999999-999999).")]
        public int Value { get; set; }
    }
}
