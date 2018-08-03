using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        public DateTime? Birthday { get; set; }
    }
}