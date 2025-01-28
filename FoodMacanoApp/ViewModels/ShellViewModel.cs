using FoodMacanoApp.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMacanoApp.ViewModels
{
    public class ShellViewModel : NotificationObject
    {
        private bool userIsLogout = true;

        public bool UserIsLogout
        {
            get { return userIsLogout; }
            set
            {
                userIsLogout = value;
                OnPropertyChanged();
            }
        }

        public Command LogoutCommand { get; }

        public ShellViewModel()
        {
            LogoutCommand = new Command(OnLogout);
        }

        private void OnLogout(object obj)
        {
            UserIsLogout = true;
            var institutoShell = (AppShell)App.Current.MainPage;
            institutoShell.DisableAppAfterLogin();
        }
    }
}
