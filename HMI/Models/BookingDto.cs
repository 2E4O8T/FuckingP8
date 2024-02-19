﻿namespace HMI.Models
{
    public class BookingDto
    {
        public string PatientName { get; set; }
        public string ConsultantName { get; set; }
        public string ConsultantSpeciality { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
