using SQLite;
using System;
using Xamarin.Forms;

namespace timesheet.Models
{
    public class TsItems : BindableObject
    {
        [PrimaryKey, Unique, AutoIncrement, NotNull]
        public int ID { get; set; }

        public string UserID { get; set; }

        public int Status
        {
            get
            {
                return Status;
            }
            set
            {
                if (value == Status)
                    return;
                Status = value;
                OnPropertyChanged();
            }
        }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int Hours { get; set; }

        public DateTime CR_date { get; set; }

        public DateTime MOD_date { get; set; }

        string CheckUserStatus(int status)
        {
            var statoTS = "";
            switch (status)
            {
                case 0: statoTS = "confirmed"; break;
                case 1: statoTS = "refused"; break;
                case 2: statoTS = "suspended"; break;
            }
            return statoTS;
        }
    }
}
