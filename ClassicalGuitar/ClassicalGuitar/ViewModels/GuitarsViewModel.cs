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
        private readonly IGuitarService _guitarService;
        public ObservableCollection<Guitar> Guitars { get; set; } = new ObservableCollection<Guitar>();

        public GuitarsViewModel(IGuitarService guitarService)
        {
            _guitarService = guitarService ?? throw new ArgumentNullException(nameof(guitarService));
            GetGuitars();
        }

        public async void GetGuitars()
        {
            var response = await _guitarService.GetAllGuitarsAsync();
            Console.WriteLine(response);
            foreach (var guitar in response.Guitars)
            {
                Guitars.Add(guitar);
            }
        }
    }
}
