using ClassicalGuitar.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassicalGuitar.Services
{
    public interface IGuitarService
    {
        Task<GuitarsResponse> GetAllGuitarsAsync();
    }
}
