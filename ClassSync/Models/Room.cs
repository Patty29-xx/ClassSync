using ClassSync.Models;
namespace ClassSync.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public string Features { get; set; }  // e.g., "Projector, Whiteboard"
    }
}
