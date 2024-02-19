﻿namespace Calendar.Models
{
    public class CalendarModel
    {
        public int Id { get; set; }
        public int ConsultantId { get; set; }
        public DateTime AppointmentDate { get; set; }

        public ConsultantModel Consultant { get; set; }
    }
}
