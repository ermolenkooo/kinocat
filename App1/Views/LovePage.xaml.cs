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
    public partial class LovePage : ContentPage
    {
        public LovePage()
        {
            InitializeComponent();
        }

        public LovePage(User u, User selectedUser, bool isSerial)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new LoveViewModel(u, selectedUser, isSerial) { Navigation = this.Navigation };
        }
    }
}