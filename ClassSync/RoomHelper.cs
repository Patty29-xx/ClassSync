using System.Data;
using System.Data.SQLite;

namespace ClassSync.Helpers
{
    public static class RoomHelper
    {
        public static DataTable LoadRooms()
        {
            using (var conn = DBHelper.GetConnection())
            {
                string query = "SELECT RoomID, RoomName, Capacity, Features FROM Rooms";
                SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
