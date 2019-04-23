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
            database.CreateTableAsync<Users>().Wait();
        }

        public Task<List<TsItems>> GetAllItemsAsync()

        {
            return database.Table<TsItems>().ToListAsync();
        }
        public Task<List<TsItems>> GetItemsSuspendedAsync()

        {
            return database.QueryAsync<TsItems>("SELECT * FROM [TsItems] WHERE [ConfirmedStatus] = 0 AND [RefusedStatus] = 0");
        }
        public Task<List<TsItems>> GetItemsConfirmedAsync()

        {
            return database.QueryAsync<TsItems>("SELECT * FROM [TsItems] WHERE [ConfirmedStatus] = 1");
        }
        public Task<List<TsItems>> GetItemsRefusedAsync()

        {
            return database.QueryAsync<TsItems>("SELECT * FROM [TsItems] WHERE [RefusedStatus] = 1");
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
