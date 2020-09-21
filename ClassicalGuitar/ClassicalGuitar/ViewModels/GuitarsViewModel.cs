using ClassicalGuitar.Models;
using ClassicalGuitar.Services;
using ClassicalGuitar.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ClassicalGuitar.ViewModels
{
    public class GuitarsViewModel: BaseViewModel
    {
        public ICommand SelectedGuitarCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand TextChangedCommand { get; set; }

        private readonly IGuitarService _guitarService;
        private IPageService _pageService;
        private Guitar _selectedGuitar;
        private string _searchText;
        public ObservableCollection<Guitar> _guitars;

        public GuitarsViewModel(IPageService pageService, IGuitarService guitarService)
        {
            _guitarService = guitarService ?? throw new ArgumentNullException(nameof(guitarService));
            _pageService = pageService;
            Guitars = new ObservableCollection<Guitar>();

            SelectedGuitarCommand = new Command(async () => await SelectGuitar());
            SearchCommand = new Command<string>( (string queryText) =>  SearchGuitars(queryText));
            TextChangedCommand = new Command( () =>  TextChanged());

            GetGuitars();
        }

        public async void GetGuitars()
        {
            Guitars = new ObservableCollection<Guitar>();
            var response = await _guitarService.GetAllGuitarsAsync();
            Console.WriteLine(response);
            foreach (var guitar in response.Guitars)
            {
                Guitars.Add(guitar);
            }
        }

        private void TextChanged()
        {
            Console.WriteLine("Hello");
        }

        private void SearchGuitars(string text)
        {
            var newGuitars = new ObservableCollection<Guitar>();
            Console.WriteLine(text);
            foreach(var guitar in Guitars)
            {
                var name = guitar.GuitarName.ToLower();
                if (name.Contains(text))
                {
                    newGuitars.Add(guitar);
                }
            }
            Guitars = newGuitars;
        }

        private async Task SelectGuitar()
        {
            var guitar = SelectedGuitar;
            if(guitar != null)
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

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                if(_searchText == "")
                {
                    GetGuitars();
                }
            }
        }

        public ObservableCollection<Guitar> Guitars
        {
            get => _guitars;
            set
            {
                _guitars = value;
                OnPropertyChanged("Guitars");
            }
        }
    }
}
