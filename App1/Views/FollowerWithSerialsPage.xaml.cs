using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Models;

namespace App1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FollowerWithSerialsPage : ContentPage
    {
        public FollowerWithSerialsPage()
        {
            InitializeComponent();
        }

        public FollowerWithSerialsPage(User u, User myuser)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new FollowerWithSerialsViewModel(u, myuser) { Navigation = this.Navigation };
        }
    }
}


