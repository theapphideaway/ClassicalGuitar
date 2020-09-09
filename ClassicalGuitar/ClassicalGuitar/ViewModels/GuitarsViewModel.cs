using ClassicalGuitar.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ClassicalGuitar.ViewModels
{
    class GuitarsViewModel
    {
        private GuitarService guitarService = new GuitarService();
        public ObservableCollection<string> Items { get; set; } = new ObservableCollection<string>();

        public GuitarsViewModel()
        {
            GetGuitars();

            Items.Add("One");
            Items.Add("Two");
            Items.Add("Three");
        }

        public async void GetGuitars()
        {
            await guitarService.GetAllGuitarsAsync();
        }
    }
}
