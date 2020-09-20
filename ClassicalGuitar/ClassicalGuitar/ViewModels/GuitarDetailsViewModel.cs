using ClassicalGuitar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassicalGuitar.ViewModels
{
    public class GuitarDetailsViewModel : BaseViewModel
    {
        private Guitar _guitar;
        public GuitarDetailsViewModel(Guitar guitar)
        {
            Guitar = guitar;
        }

        public Guitar Guitar
        {
            get => _guitar;
            set { _guitar = value; }
        }
    }
}
