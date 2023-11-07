using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIDemo.Entities
{
    [Table("Product")]
    public class Product
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]

        public double Price { get; set; }
        [Required]

        //[Display(Name = "Cname")]

        
        [Display(Name = "Cname")]
        public string? Cname { get; set; }
        public int IsActive { get; set; }


    }
}