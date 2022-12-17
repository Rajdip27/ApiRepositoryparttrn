using System.ComponentModel.DataAnnotations;

namespace RepositoryPattenApi.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Enter Your Name")]

        public string Name { get; set; }
        [Required]
        [Display(Name = "Enter Your Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Enter Your Age")]

        public int Age { get; set; }
        [Required]
        [Display(Name ="Enter Your Email Address.")]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
       
    }
}
