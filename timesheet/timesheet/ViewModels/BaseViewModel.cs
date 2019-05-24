using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timesheet.Helpers;
using Xamarin.Forms;

namespace timesheet.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public INavigation _navigation;

        public event EventHandler IsBusyChanged;

        public event EventHandler IsValidChanged;

        readonly List<string> errors = new List<string>();
        bool isBusy = false;

        public BaseViewModel()
        {
            //Make sure validation is performed on startup
            Validate();
        }
        public bool IsValid
        {
            get { return errors.Count == 0; }
        }
        protected List<string> Errors
        {
            get { return errors; }
        }
        public virtual string Error
        {
            get
            {
                return errors.Aggregate(new StringBuilder(), (b, s) => b.AppendLine(s)).ToString().Trim();
            }
        }

        protected virtual void Validate()
        {
            NotifyPropertyChanged("IsValid");
            NotifyPropertyChanged("Errors");

            var method = IsValidChanged;
            if (method != null)
                method(this, EventArgs.Empty);
        }

        protected virtual void ValidateProperty(Func<bool> validate, string error)
        {
            if (validate())
            {
                if (!Errors.Contains(error))
                    Errors.Add(error);
            }
            else
            {
                Errors.Remove(error);
            }
        }
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;

                    NotifyPropertyChanged("IsBusy");
                    OnIsBusyChanged();
                }
            }
        }
        protected virtual void OnIsBusyChanged()
        {
            var ev = IsBusyChanged;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
        }

        public string Mail
        {
            get => UserSettings.Mail;
            set
            {
                UserSettings.Mail = value;
                NotifyPropertyChanged("Mail");
            }
        }
        public string Password
        {
            get => UserSettings.Password;
            set
            {
                UserSettings.Password = value;
                NotifyPropertyChanged("Password");
            }
        }

        #region INotifyPropertyChanged  
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        /*public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }*/
    }
}
