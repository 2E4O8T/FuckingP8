namespace Booking.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int ConsultantId { get; set;}
        public DateTime AppointmentDate { get; set; }

        public PatientModel Patient { get; set; }
        public ConsultantModel Consultant { get; set; }
    }
}
