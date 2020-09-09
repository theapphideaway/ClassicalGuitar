using ClassicalGuitar.Models;
using ClassicalGuitar.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ClassicalGuitar.ViewModels
{
    class GuitarsViewModel: BaseViewModel
    {
        private GuitarService guitarService = new GuitarService();
        public ObservableCollection<Guitar> Guitars { get; set; } = new ObservableCollection<Guitar>();

        public GuitarsViewModel()
        {
            GetGuitars();

        }

        public async void GetGuitars()
        {
            var response = await guitarService.GetAllGuitarsAsync();
            Console.WriteLine(response);
            foreach (var guitar in response.Guitars)
            {
                Guitars.Add(guitar);
            }
        }
    }
}
