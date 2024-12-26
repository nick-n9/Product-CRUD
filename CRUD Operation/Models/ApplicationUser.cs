using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace CRUD_Operation.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender UserGender { get; set; }
        public enum Gender
        {
            Male,
            Female
        }


    }
}
