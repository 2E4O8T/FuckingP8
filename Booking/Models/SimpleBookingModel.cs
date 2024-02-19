namespace Booking.Models
{
    public class SimpleBookingModel
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string ConsultantName { get; set; }
        public string ConsultantSpeciality { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
