namespace Booking.Models
{
    public class PatientModel
    {
        public int Id { get; set; }
        public string PatientFirstName { get; set; } = string.Empty;
        public string PatientLastName { get; set;} = string.Empty;
        public string PatientEmail { get; set; } = string.Empty;
        public string PatientPhone { get; set; } = string.Empty;
        public string PatientAddress {  get; set; } = string.Empty;
        public string PatientCity { get; set;} = string.Empty;
        public string PatientZipCode { get; set;} = string.Empty;
    }
}
