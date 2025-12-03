using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Domain.Entities
{
    public class Household
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string JoinCode { get; set; } = null!;
    }
}
