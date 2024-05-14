using DotAir.BLL.Interfaces;
using DotAir.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace DotAir.DAL.Repositories
{
    public class CountryRepository(HttpClient _httpClient) : ICountryRepository
    {
        public List<Country> FindAll()
        {
            return _httpClient.GetFromJsonAsync<List<Country>>("https://restcountries.com/v3.1/all").Result 
                ?? throw new HttpRequestException();
        }


    }
}
