using SQLite;

namespace timesheet.Helpers
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
