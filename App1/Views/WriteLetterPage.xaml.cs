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
    public partial class WriteLetterPage : ContentPage
    {
        public WriteLetterPage()
        {
            InitializeComponent();
        }

        public WriteLetterPage(User u, Film f)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new WriteLetterViewModel(u, f) { Navigation = this.Navigation };
        }
    }
}