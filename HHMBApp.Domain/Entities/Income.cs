using System.ComponentModel.DataAnnotations;

namespace HHMBApp.Domain.Entities;

public class Income
{
    [Key]
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid HouseholdId { get; set; }
    public int Amount { get; set; }
    public DateTime Date { get; set; }
    public Category Category { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
}