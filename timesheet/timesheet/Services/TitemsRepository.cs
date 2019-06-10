using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using timesheet.Helpers;
using timesheet.Models;

namespace timesheet.Services
{
    public class TitemsRepository : ITitemsRepository
    {
        DBHelper _dbHelper;
        public TitemsRepository()
        {
            _dbHelper = new DBHelper();
        }

        public List<TsItems> GetAllItems()
        {
            return _dbHelper.GetAllItems();
        }
        public List<TsItems> GetItemsSuspended()
        {
            return _dbHelper.GetItemsSuspended();
        }
        public List<TsItems> GetItemsConfirmed()
        {
            return _dbHelper.GetItemsConfirmed();
        }
        public List<TsItems> GetItemsRefused()
        {
            return _dbHelper.GetItemsRefused();
        }
        public TsItems GetItem(int itemID)
        {
            return _dbHelper.GetItem(itemID);
        }
        public void SaveItem(TsItems item)
        {
            _dbHelper.SaveItem(item);
        }
        public void DeleteItem(int itemID)
        {
            _dbHelper.DeleteItem(itemID);
        }
    }
}
