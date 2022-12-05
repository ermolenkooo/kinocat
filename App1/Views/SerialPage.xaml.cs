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
    public partial class SerialPage : ContentPage
    {
        public SerialPage()
        {
            InitializeComponent();
        }

        public SerialPage(Film f, User u)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new SerialViewModel(f, u) { Navigation = this.Navigation };
        }
    }
}