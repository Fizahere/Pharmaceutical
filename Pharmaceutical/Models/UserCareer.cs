using System.ComponentModel.DataAnnotations;

namespace Pharmaceutical.Models
{
    public class UserCareer
    {
        public int UserCareerId { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        public string FatherName  { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        public string Education  { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        public string Specialization { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        public string School { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        public string CGPA { get; set; }

        [Required(ErrorMessage = "Please enter a value")]
        public string PassingYear { get; set; }


        [Required(ErrorMessage = "Please enter a value")]
        public string Resume { get; set; }

        public int  UserId { get; set; }
        public User User { get; set; }

    }
}
