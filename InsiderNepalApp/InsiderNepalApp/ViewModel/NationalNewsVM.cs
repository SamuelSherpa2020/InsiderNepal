using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace InsiderNepalApp.ViewModel
{
    public class NationalNewsVM
    {
        // needed fields: Id, Title, Author, PublishData, Content, ImageUrl

       
        public int NationalNewsId { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "Title Cannot be longer than 100 characters")]
        public string? Title { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Author name Cannot be longer than 100 characters")]
        public string Author { get; set; } = string.Empty;


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Publised Date")]
        public DateTime PublishDateTime { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "Content cannot be more than 2000 characters")]
        public string Content { get; set; } = string.Empty;

      
        public string ImageUrl { get; set; } = string.Empty;


        public IFormFile? Avatar { get; set; }
    }
}
