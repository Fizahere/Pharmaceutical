using System.ComponentModel.DataAnnotations;

namespace Pharmaceutical.Models
{
    public class Quote
    {
        [Key]
        public int QuoteID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }    
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Comments { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
