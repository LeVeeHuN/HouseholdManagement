namespace HHMBApp.Application.DTOs.Category;

public class CreateCategoryResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public CreateCategoryResponseStatus Result {get; set;}
}

public enum CreateCategoryResponseStatus
{
    OK = 0,
    CreateCategoryError = 1
}