using System;

namespace ClassSync.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int UserID { get; set; }
        public int RoomID { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string Purpose { get; set; }
        public int Attendees { get; set; }
        public string Status { get; set; }    // e.g., "Pending", "Approved", "Cancelled"
    }
}
