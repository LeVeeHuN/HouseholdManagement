using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Todo
{
    public class CreateTodoResponseDto : UpdateTodoDto
    {
        public CreateTodoResponseStatus Result { get; set; }
    }

    public enum CreateTodoResponseStatus
    {
        OK,
        CreateTodoError,
        UpdateTodoError
    }
}
