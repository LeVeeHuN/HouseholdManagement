using System.ComponentModel.DataAnnotations;

namespace HHMBApp.Domain.Entities;

public class Category
{
    [Key]
    public Guid Id { get; set; }
    public Guid HouseholdId { get; set; }
    public string CategoryName { get; set; } = null!;
}