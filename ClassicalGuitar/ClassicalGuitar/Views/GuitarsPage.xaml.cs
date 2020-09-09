using ClassicalGuitar.Models;
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
    public partial class GuitarsPage : ContentPage
    {
        public GuitarsPage()
        {
            InitializeComponent();
            BindingContext = new GuitarsViewModel();

            //Remove Selected Item Background color but keep selected splash effect
            guitarLV.ItemTapped += (object sender, ItemTappedEventArgs e) => {
                if (e.Item == null) return;
                if (sender is ListView lv) lv.SelectedItem = null;
            };

               
        }
    }
}