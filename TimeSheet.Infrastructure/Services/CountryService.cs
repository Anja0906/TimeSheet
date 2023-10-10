
using TimeSheet.Core.IRepositories;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;

namespace TimeSheet.Infrastructure.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public void AddCountry(Country country)
        {
            _countryRepository.AddCountry(country);
        }

        public void DeleteCountry(int id)
        {
            _countryRepository.DeleteCountry(id);
        }

        public Task<List<Country>> GetAll()
        {
            return _countryRepository.GetAll();
        }

        public Task<Country> GetById(int id)
        {
            return _countryRepository.GetById(id);
        }

        public Task<Country> GetByName(string name)
        {
            return _countryRepository.GetByName(name);
        }

        public Country UpdateCountry(Country country)
        {
            return _countryRepository.UpdateCountry(country);
        }
    }
}
