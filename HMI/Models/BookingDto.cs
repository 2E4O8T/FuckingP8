namespace HMI.Models
{
    public class BookingDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int ConsultantId { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
