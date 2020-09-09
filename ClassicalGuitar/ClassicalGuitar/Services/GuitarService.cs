using ClassicalGuitar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClassicalGuitar.Services
{
    class GuitarService: IGuitarService
    {

        public async Task<GuitarsResponse> GetAllGuitarsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync("http://apitest321.xyz/guitar");
                Console.WriteLine(response);
                GuitarsResponse responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<GuitarsResponse>(response);
                Console.WriteLine(responseObject);
            }
                return new GuitarsResponse();
        }
    }
}
