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
    public partial class FollowerPage : ContentPage
    {
        public FollowerPage()
        {
            InitializeComponent();
        }

        public FollowerPage(User u, User myuser)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new FollowerViewModel(u, myuser) { Navigation = this.Navigation };
        }
    }
}