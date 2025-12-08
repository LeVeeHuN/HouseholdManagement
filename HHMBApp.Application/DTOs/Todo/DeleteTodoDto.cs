using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Todo
{
    public class DeleteTodoDto
    {
        public Guid TodoId { get; set; }
        public Guid HouseholdId { get; set; }
    }
}
