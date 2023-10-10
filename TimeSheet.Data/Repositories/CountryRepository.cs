

using AutoMapper;
using TimeSheet.Core.IRepositories;
using TimeSheet.Core.Models;

namespace TimeSheet.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IMapper _mapper;
        private DataContext _dataContext;
        public CountryRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public void AddCountry(Country country)
        {
            var countryEntity = _mapper.Map<Entities.Country>(country);
            _dataContext.Countries.Add(countryEntity);
            _dataContext.SaveChanges();
        }

        public void DeleteCountry(int id)
        {
            var existingCountry = _dataContext.Countries.Where(x => x.Id == id).FirstOrDefault();
            _dataContext.Countries.Remove(existingCountry);
            _dataContext.SaveChanges();
        }

        public Task<List<Country>> GetAll()
        {
            var countries = _dataContext.Countries.OrderBy(p => p.Id).ToList();
            List<Country> result = new List<Country>();
            foreach (var country in countries)
            {
                var countryModel = _mapper.Map<Country>(country);
                result.Add(countryModel);
            }
            return Task.FromResult(result);
        }

        public Task<Country> GetById(int id)
        {
            var countryEntity = _dataContext.Countries.Where(p => p.Id == id).FirstOrDefault();
            var countryModel = _mapper.Map<Country>(countryEntity);
            return Task.FromResult(countryModel);
        }

        public Task<Country> GetByName(string name)
        {
            var countryEntity = _dataContext.Countries.Where(p => p.Name == name).FirstOrDefault();
            var countryModel = _mapper.Map<Country>(countryEntity);
            return Task.FromResult(countryModel);
        }

        public Country UpdateCountry(Country country)
        {
            var existingcountry = _dataContext.Countries.Where(p => p.Id == country.Id).FirstOrDefault();
            if (existingcountry != null)
            {
                _dataContext.Attach(existingcountry);
                _dataContext.Entry(existingcountry).CurrentValues.SetValues(country);
                _dataContext.SaveChanges();
            }
            var updatedcountry = _dataContext.Countries.Where(p => p.Id == country.Id).FirstOrDefault();
            if (updatedcountry != null)
            {
                return _mapper.Map<Country>(updatedcountry);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
