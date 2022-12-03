using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Models;
using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WatchlistPage : ContentPage
    {
        public WatchlistPage()
        {
            InitializeComponent();
        }

        public WatchlistPage(User u, User selectedUser, bool isSerial)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new WatchlistViewModel(u, selectedUser, isSerial) { Navigation = this.Navigation };
        }
    }
}