using System.Collections.Generic;
using System.Threading.Tasks;

using timesheet.Models;

namespace timesheet.Services
{
    public interface ITitemsRepository
    {
        //Get All items
        List<TsItems> GetAllItems();
        //Get all suspended
        List<TsItems> GetItemsSuspended();
        //Get all confimrmed
        List<TsItems> GetItemsConfirmed();
        //Get all refused
        List<TsItems> GetItemsRefused();
        //Get specific item
        TsItems GetItem(int id);
        //Create item
        void SaveItem(TsItems item);
        //Delete item
        void DeleteItem(int itemID);
    }
}
