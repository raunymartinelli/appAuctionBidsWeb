using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment1.Models
{
    public class Bid
    {

        [Key]
        public int BidId { get; set; }

      
        public string? ItemName { get; set; }
        [Required(ErrorMessage = "Invalid Product Item Description")]
        public string? ItemDescription { get; set; }
        [Required(ErrorMessage = "Invalid Product Cost")]
        public String? MinimumCost { get; set; }
        [Required(ErrorMessage = "Invalid Assest_Condition ")]
        public string? AssetCondition { get; set; }
        [Required(ErrorMessage = "Select Bid Date")]
        public DateTime AuctionDatesStart { get; set; }
        [Required(ErrorMessage = "Select Bid Date")]
        public DateTime AuctionDates { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]

        public IFormFile ImageUpload { get; set; }
        [Range(1, 6, ErrorMessage = "Select Correct Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public string? user { get; set; }
}
}
