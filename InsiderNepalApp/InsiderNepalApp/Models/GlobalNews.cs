using System.ComponentModel.DataAnnotations;

namespace InsiderNepalApp.Models
{
    public class GlobalNews
    {
        // needed fields: Id, Title, Author, PublishData, Content, ImageUrl

        [Key]
        public int GlobalId { get; set; }

        public string? Title { get; set; }


        public string? Author { get; set; }



        public DateTime PublishDateTime { get; set; }


        public string? Content { get; set; }


        public string? ImageUrl { get; set; }

    }
}

