namespace HHMBApp.Application.DTOs.Category;

public class CreateCategoryDto
{
    public string Name { get; set; } = null!;
    public Guid HouseholdId { get; set; }
}