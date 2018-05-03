using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Patient
    {
        public int Id { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage ="Please enter first name")]        
        public string FirstName { get; set; }
        
        [StringLength(20)]
        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage ="Please select an option")]
        public string Sex { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Please enter name of your Mother/Father/Husband/Wife")]
        public string Parent_Spouse_Name { get; set; }

        [Required(ErrorMessage = "Please select relation with the above person")]
        public string Relation { get; set; }

        [Range(0,100)]
        public int Age { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(10)]
        [MinLength(10)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Enter valid mobile number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Please select a group")]
        public string BloodGroup { get; set; }

        [Required(ErrorMessage = "Please select an option")]
        public string MaritalStatus { get; set; }

        [Required]
        public DateTime DateOfReporting { get; set; }
        
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
    }
}
