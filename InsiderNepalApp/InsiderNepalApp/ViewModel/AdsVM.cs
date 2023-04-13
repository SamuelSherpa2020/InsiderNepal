using System.ComponentModel.DataAnnotations;

namespace InsiderNepalApp.ViewModel;

public class AdsVM
{

    public int AdsId { get; set; }
    
    [Required]
    [StringLength(200, ErrorMessage = "Title Cannot be longer than 100 characters")]
    public string? Title { get; set; }
    
    [Required]
    [StringLength(10000, ErrorMessage = "Description Cannot be longer than 100 characters")]
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
