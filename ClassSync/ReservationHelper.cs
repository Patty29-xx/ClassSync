using System.Data;
using System.Data.SQLite;

namespace ClassSync.Helpers
{
    public static class ReservationHelper
    {
        public static DataTable LoadReservationsByStatuses()
        {
            using (var conn = DBHelper.GetConnection())
            {
                string query = @"
                SELECT 
                    r.ReservationID,
                    u.Username, 
                    rm.RoomName,
                    r.Date,
                    r.StartTime,
                    r.EndTime,
                    r.Purpose,
                    r.Attendees,
                    r.Status
                FROM Reservations r
                INNER JOIN Users u ON r.UserID = u.UserID
                INNER JOIN Rooms rm ON r.RoomID = rm.RoomID
                WHERE r.Status IN ('Pending', 'Approved', 'Rejected')
                ORDER BY r.Date, r.StartTime";

                SQLiteDataAdapter da = new SQLiteDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }


    }
}
