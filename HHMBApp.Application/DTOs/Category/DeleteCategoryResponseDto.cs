namespace HHMBApp.Application.DTOs.Category;

public class DeleteCategoryResponseDto
{
    public string Name { get; set; } = null!;
    public DeleteCategoryResponseStatus Result { get; set; }
}

public enum DeleteCategoryResponseStatus
{
    OK = 0,
    DeleteCategoryError = 1
}