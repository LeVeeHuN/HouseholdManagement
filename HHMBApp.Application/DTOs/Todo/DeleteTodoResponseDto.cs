using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHMBApp.Application.DTOs.Todo
{
    public class DeleteTodoResponseDto
    {
        public Guid Id { get; set; }
        public DeleteTodoResponseStatus Result { get; set; }
    }

    public enum DeleteTodoResponseStatus
    {
        OK,
        DeleteTodoError
    }
}
