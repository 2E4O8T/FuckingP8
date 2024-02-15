namespace Booking.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int PraticienId { get; set;}
        public DateTime AppointmentDate { get; set; }
    }
}
