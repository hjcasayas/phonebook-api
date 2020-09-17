using System.ComponentModel.DataAnnotations;

namespace Phonebook.Data.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{LastName} {FirstName}";
            }
        }
        [Required]
        [MaxLength(11)]
        public string PhoneNumber { get; set; }
    }
}
