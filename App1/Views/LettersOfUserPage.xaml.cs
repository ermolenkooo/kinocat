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
    public partial class LettersOfUserPage : ContentPage
    {
        public LettersOfUserPage()
        {
            InitializeComponent();
        }

        public LettersOfUserPage(User u)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new LettersOfUserViewModel(u) { Navigation = this.Navigation };
        }
    }
}