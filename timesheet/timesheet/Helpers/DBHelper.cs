using SQLite;
using Xamarin.Forms;

using System.Collections.Generic;
using System.Threading.Tasks;

using timesheet.Models;

namespace timesheet.Helpers
{
    public class DBHelper
    {
        readonly SQLiteConnection database;
        public const string DbFileName = "ManagerDB.db3";
        public DBHelper()

        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            //database = new SQLiteConnection(dbPath);
            database.CreateTable<TsItems>();
            database.CreateTable<Users>();
        }

        public List<TsItems> GetAllItems()
        {
            return database.Query<TsItems>("SELECT * FROM [TsItems] ORDER BY Date DESC");
            //return database.Table<TsItems>().ToListAsync();
        }
        public List<TsItems> GetItemsSuspended()
        {
            return database.Query<TsItems>("SELECT * FROM [TsItems] WHERE [ConfirmedStatus] = 0 AND [RefusedStatus] = 0 ORDER BY Date DESC");
        }
        public List<TsItems> GetItemsConfirmed()
        {
            return database.Query<TsItems>("SELECT * FROM [TsItems] WHERE [ConfirmedStatus] = 1 ORDER BY Date DESC");
        }
        public List<TsItems> GetItemsRefused()
        {
            return database.Query<TsItems>("SELECT * FROM [TsItems] WHERE [RefusedStatus] = 1 ORDER BY Date DESC");
        }
        public TsItems GetItem(int id)
        {
            return database.Table<TsItems>().FirstOrDefault(i => i.ID == id);
        }
        public int SaveItem(TsItems item)
        {
            if (item.ID != 0)

            {
                return database.Update(item);
            }
            else
            {
                return database.Insert(item);
            }
        }
        public void DeleteItem(int itemID)
        {
            database.Delete(itemID);
        }

        public Users Getuser(int id)
        {
            return database.Table<Users>().Where(i => i.ID == id).FirstOrDefault();
        }
        public List<Users> GetuserAsync()

        {
            return database.Query<Users>("SELECT * FROM [Users] WHERE [Type] = 0");
        }
        public List<Users> GetsuperuserAsync()

        {
            return database.Query<Users>("SELECT * FROM [Users] WHERE [Type] = 1");
        }
    }
}
