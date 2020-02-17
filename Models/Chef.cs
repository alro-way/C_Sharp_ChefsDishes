using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace C_Sharp_ChefsDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}
        [Required]
        public string FirstName {get;set;}
        [Required]
        public string LastName {get;set;}
        [Required]
        [OnlyDateInPast(ErrorMessage="Birthday must be in Past")]
        [MinAge(18, ErrorMessage="Chef must be more than 18 years old")]
        public DateTime BirthdayDate {get; set;}
        public int Age {get;set;}
        public List<Dish> DishesCreated {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

    }

    public class OnlyDateInPastAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if((DateTime)value > DateTime.Now)
                return new ValidationResult("Date must be in the Past");
            return ValidationResult.Success;
        }
        
    }


    public class MinAgeAttribute: ValidationAttribute
    {
        private int _Limit;
        public MinAgeAttribute (int limit)
        {
            this._Limit = limit;
        }
        public override bool IsValid(object value)
        {
            DateTime date;
            if(DateTime.TryParse(value.ToString(),out date))
            {
                return date.AddYears(_Limit) < DateTime.Now;
            }
            return false;
        }
        
    }

}

//     public class MinAgeAttribute: ValidationAttribute
//     {
//         private int _Limit;
//         public MinAgeAttribute (int limit)
//         {
//             this._Limit = limit;
//         }
//         protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//         {
//             DateTime today = DateTime.Now;
//             DateTime birthdayDay = DateTime.Parse(value.ToString());
//             int age = today.Year - birthdayDay.Year;
//             if(birthdayDay>today.AddYears(-age))
//             {
//                 age--;
//             }

//             if(age<_Limit)
//             {
//                 return new ValidationResult("Date must be in the Past");
//             }
                
//             return ValidationResult.Success;
//         }
        
//     }

// }