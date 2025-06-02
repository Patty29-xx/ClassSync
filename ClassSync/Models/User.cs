using ClassSync.Models;

namespace ClassSync.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }  // For real app, hash this!
        public string Role { get; set; }      // "admin" or "user"
    }
}

