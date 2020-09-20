using ClassicalGuitar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClassicalGuitar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GuitarDetailsPage : ContentPage
    {
        public GuitarDetailsPage(GuitarDetailsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}