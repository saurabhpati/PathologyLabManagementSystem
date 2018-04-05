using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PathologyLabManagementSystem.Areas.User.ViewModels
{
    public class AddPatientViewModel
    {
        public AddPatientViewModel()
        {
            LstSex = new List<Sex>()
            {
                new Sex{ Id=1, Text="Male" },
                new Sex{Id=2,Text="Female"},
                new Sex{ Id=3, Text="Other"}
            };

        }
        [StringLength(20)]
        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Please enter Last name")]
        public string LastName { get; set; }

        [Required]
        [Range(0, 100,ErrorMessage ="Please Enter Age between 0-100")]
        public int Age { get; set; }
        
        [StringLength(150,ErrorMessage ="Please enter upto 150 characters only")]
        public string Address { get; set; }

        [Required]
        public string Sex { get; set; }

        [StringLength(10)]
        [MinLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Enter valid mobile number")]
        public string PhoneNumber { get; set; }

        public List<Sex> LstSex { get; set; }
        public 
    }
    public class Sex
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
    
}