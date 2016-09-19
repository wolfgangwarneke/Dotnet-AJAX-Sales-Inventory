using System.ComponentModel.DataAnnotations;

namespace TimelinePleaseWork.ViewModels
{
    public class RoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }
    }
}