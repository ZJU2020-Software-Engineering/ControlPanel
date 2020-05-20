using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControlPanel.Models
{
    public class Merchant
    {
        [Key]
        [Required]
        [Column(TypeName = "varchar(20)")]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        [StringLength(20)]
        public string Address { get; set; }
        [Column(TypeName = "varchar(20)")]
        [StringLength(20)]
        public string BusinessLicense { get; set; }
        // [Required]
        [Column(TypeName = "varchar(20)")]
        [StringLength(20)]
        public string CorporateIdentity { get; set; }
        // [Required]
        [Column(TypeName = "varchar(20)")]
        [StringLength(20)]
        public string Category { get; set; }
        // [Required]
        [Column(TypeName = "varchar(20)")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar(40)")]
        [StringLength(40)]
        public string Email { get; set; }
        // [Required]
        [Column(TypeName = "varchar(40)")]
        [StringLength(40)]
        public string CollectionInformation { get; set; }
    }
}
