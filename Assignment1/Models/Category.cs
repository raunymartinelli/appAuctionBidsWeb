using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class Category
    {
        
        [Key]
        public int CategoryId { get; set; }
        public String? CategoryName { get; set; }
    
}
}
