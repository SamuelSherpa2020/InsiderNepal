using System.ComponentModel.DataAnnotations;

namespace InsiderNepalApp.Models
{
    public class BussinessNews
    {
        [Key]
        public int BussinessNewsId { get; set; }

        public string? Title { get; set; }


        public string? Author { get; set; }



        public DateTime PublishDateTime { get; set; }


        public string? Content { get; set; }


        public string? ImageUrl { get; set; }

    }
}
