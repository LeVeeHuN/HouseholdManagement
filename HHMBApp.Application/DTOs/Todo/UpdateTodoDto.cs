using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Todo
{
    public class UpdateTodoDto : CreateTodoDto
    {
        public Guid Id { get; set; }
    }
}
