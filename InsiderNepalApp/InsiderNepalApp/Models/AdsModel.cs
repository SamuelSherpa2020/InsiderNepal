using System.ComponentModel.DataAnnotations;

namespace InsiderNepalApp.Models;

public class AdsModel
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public float Price { get; set; }
    public string? ContactInformation { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
