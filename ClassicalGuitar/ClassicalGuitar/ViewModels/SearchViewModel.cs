using ClassicalGuitar.Models;
using ClassicalGuitar.Services;
using ClassicalGuitar.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ClassicalGuitar.ViewModels
{
    public class SearchViewModel
    {
        public ICommand SearchCommand { get; set; }
        public ICommand SelectedGuitarCommand { get; set; }

        private readonly IGuitarService _guitarService;
        private IPageService _pageService;
        private Guitar _selectedGuitar;
        public ObservableCollection<Guitar> Guitars { get; set; } = new ObservableCollection<Guitar>();
        public SearchViewModel(IPageService pageService, IGuitarService guitarService)
        {
            _guitarService = guitarService ?? throw new ArgumentNullException(nameof(guitarService));
            _pageService = pageService;
            SearchCommand = new Command<string>((string queryText) => SearchGuitars(queryText));

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
        private void SearchGuitars(string text)
        {
            Console.WriteLine(text);
            foreach (var guitar in Guitars)
            {
            }
        }

        private async Task SelectGuitar()
        {
            var guitar = SelectedGuitar;
            if (guitar != null)
            {
                var viewModel = new GuitarDetailsViewModel(guitar);
                await _pageService.PushAsync(new GuitarDetailsPage(viewModel));
            }
        }

        public Guitar SelectedGuitar
        {
            get => _selectedGuitar;
            set
            {
                _selectedGuitar = value;
                SelectedGuitarCommand.Execute(_selectedGuitar);
            }
        }
    }
}
