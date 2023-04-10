using System.ComponentModel.DataAnnotations;

namespace InsiderNepalApp.ViewModel;

public class AdsVM
{

    public int AdsId { get; set; }
    [Required]
    public string? Title { get; set; }
    
    [Required]
    public string? Description { get; set; }

   
    public string? ImageUrl { get; set; }

    [Required]
    public float? Price { get; set; }

    [Required]
    public string? ContactInformation { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }


    
    public IFormFile? AdsAvatar { get; set; } 

}   
