using System;
using System.ComponentModel.DataAnnotations;

namespace ControlPanel.Models
{
    public class Person
    {
        [Key]
        [Required]
        public string Username { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string IdentityCardNumber { get; set; }
        // __2nd__
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime UpdateTime { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }


    }
}
