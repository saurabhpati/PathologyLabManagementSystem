using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PathologyLabManagementSystem.Areas.User.ViewModels
{
    public class AddPatientViewModel
    {
        public AddPatientViewModel()
        {
           
        }

        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Last name")]
        [StringLength(20)]
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

        public List<SelectListItem> LstSex { get; set; }

        [StringLength(20)]
        public string Parent_Spouse_Name { get; set; }

        [StringLength(20)]
        public string Relation { get; set; }

        public string Maritalstatus { get; set; }

        public List<SelectListItem> LstMaritalStatus { get; set; }

        public string Email { get; set; }

        public string BloodGroup { get; set; }

        public List<SelectListItem> LstBloodGroup { get; set; }
    }

    public class Sex
    {
        public int Id { get; set; }

        public string Text { get; set; }
    }
    

}