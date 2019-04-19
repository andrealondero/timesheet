using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using timesheet.Models;

namespace timesheet.Helpers
{
    public class DBHelper
    {
        readonly SQLiteAsyncConnection database;

        public DBHelper(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TsItems>().Wait();

            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Users>().Wait();
        }

        public Task<List<TsItems>> GetItemsAsync()
        {
            return database.Table<TsItems>().ToListAsync();
        }

        public Task<List<TsItems>> GetItemsConfirmedAsync()
        {
            return database.QueryAsync<TsItems>("SELECT * FROM [TSitems] WHERE [Status] = 0");
        }

        public Task<List<TsItems>> GetItemsRefusedAsync()
        {
            return database.QueryAsync<TsItems>("SELECT * FROM [TSitems] WHERE [Status] = 1");
        }

        public Task<List<TsItems>> GetItemsSuspendedAsync()
        {
            return database.QueryAsync<TsItems>("SELECT * FROM [TSitems] WHERE [Status] = 2");
        }

        public Task<TsItems> GetItemAsync(int id)
        {
            return database.Table<TsItems>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(TsItems item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> EditItemAsync(TsItems item)
        {
            return database.UpdateAsync(item);
        }

        public Task<int> DeleteItemAsync(TsItems item)
        {
            return database.DeleteAsync(item);
        }

        public Task<List<Users>> GetuserAsync()
        {
            return database.QueryAsync<Users>("SELECT * FROM [Users] WHERE [Type] = 0");
        }

        public Task<List<Users>> GetsuperuserAsync()
        {
            return database.QueryAsync<Users>("SELECT * FROM [Users] WHERE [Type] = 1");
        }
    }
}
