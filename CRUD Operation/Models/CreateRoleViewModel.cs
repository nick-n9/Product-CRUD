using System.ComponentModel.DataAnnotations;

namespace CRUD_Operation.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }
    }
}
