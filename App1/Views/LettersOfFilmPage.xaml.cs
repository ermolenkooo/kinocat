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
    public partial class LettersOfFilmPage : ContentPage
    {
        public LettersOfFilmPage()
        {
            InitializeComponent();
        }

        public LettersOfFilmPage(User u, Film f)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new LettersOfFilmViewModel(u, f) { Navigation = this.Navigation };
        }
    }
}