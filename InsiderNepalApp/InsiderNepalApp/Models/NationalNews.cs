using System.ComponentModel.DataAnnotations;

namespace InsiderNepalApp.Models
{
    public class NationalNews
    {
        // needed fields: Id, Title, Author, PublishData, Content, ImageUrl

        [Key]
        public int NationalNewsId { get; set; }


        [Required]
        [StringLength(100,ErrorMessage="Title Cannot be longer than 100 characters")]
        public string Title { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Author name Cannot be longer than 100 characters")]
        public string Author { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Publised Date")]
        public DateTime PublishDateTime { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "Content cannot be more than 1500 characters")]
        public string Content { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
