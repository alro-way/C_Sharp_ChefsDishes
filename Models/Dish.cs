using System.ComponentModel.DataAnnotations;
using System;


namespace C_Sharp_ChefsDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}
        [Required]
        public string DishName {get;set;}
        [Required]
        [Range(1,1000000, ErrorMessage="Calories must be more than 0.")]
        public int Calories {get;set;}
        [Required]
        [Range(1,5, ErrorMessage="Tastiness must be between 1-5.")]
        public int Tastiness {get;set;}
        [Required]
        public string Desc {get;set;}
        // [Required]
        public int ChefId {get;set;}
        public Chef Creator {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }

}