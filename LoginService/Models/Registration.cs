namespace LoginService.Models
{
    public class Registration
    {
        public int Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; } 
        public int IsActive {  get; set; }

    }
}
