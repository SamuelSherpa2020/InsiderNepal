
using System.ComponentModel.DataAnnotations;

namespace InsiderNepalApp.ViewModel
{
    public class NationalNewsVM
    {
        // needed fields: Id, Title, Author, PublishData, Content, ImageUrl

       
        public int NationalNewsId { get; set; }


        [Required]
        [StringLength(300, ErrorMessage = "Title Cannot be longer than 100 characters")]
        public string? Title { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Author name Cannot be longer than 100 characters")]
        public string Author { get; set; } = string.Empty;


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Publised Date")]
        public DateTime PublishDateTime { get; set; }

        [Required]
        [StringLength(10000, ErrorMessage = "Content cannot be more than 2000 characters")]
        public string Content { get; set; } = string.Empty;

      
        public string ImageUrl { get; set; } = string.Empty;


        public IFormFile? Avatar { get; set; }
    }
}
