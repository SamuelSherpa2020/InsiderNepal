using System.ComponentModel.DataAnnotations;

namespace InsiderNepalApp.ViewModel;

public class AdsVM
{

    public int AdsId { get; set; }
    [Required]
    public string? Title { get; set; }
    
    [Required]
    public string? Description { get; set; }

    [Required]
    public string? ImageUrl { get; set; }

    [Required]
    public decimal? Price { get; set; }

    [Required]
    public string? ContactInformation { get; set; }

    [Required]
    public DateTime? StartDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime? EndDate { get; set; }


    [Required]
    [DataType(DataType.Date)]

    public IFormFile? AdsImage { get; set; } 

}   
