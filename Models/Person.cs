using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlPanel.Models
{
    public class Person
    {
        [Key]
        [Required]
        [Column(TypeName = "varchar(30)")]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(1)")]
        [StringLength(1)]
        public string Gender { get; set; }  // 
        // [Required]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string IdentityCardNumber { get; set; }
        // __2nd__
        // [Required]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string Email { get; set; }
        // [Required]
        public DateTime UpdateTime { get; set; }  // program generated
        // [Required]
        public DateTime CreationTime { get; set; }  // program generated
        [Required]
        [Column(TypeName = "varchar(30)")]
        [StringLength(30)]
        public string Password { get; set; }
        // __3rd__ this part might change
        [Required]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        [StringLength(20)]
        public string HealthStatus { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        [StringLength(10)]
        public string HealthCode { get; set; }
        // [Required]
        [Column(TypeName = "char(20)")]
        [StringLength(20)]
        public string Visitedplaces { get; set; }
        // [Required]
        [Column(TypeName = "varchar(30)")]
        [StringLength(30)]
        public string PaymentInformation { get; set; }
        // [Required]
        [Column(TypeName = "varchar(50)")]
        [StringLength(50)]
        public string PersonalCenterLink { get; set; }
    }
}
