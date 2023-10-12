

using AutoMapper;
using TimeSheet.Core.Exceptions;
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
        public Task<Country> AddCountry(Country country)
        {
            var countryEntity = _mapper.Map<Entities.Country>(country);
            _dataContext.Countries.Add(countryEntity);
            _dataContext.SaveChanges();
            var createdModel = _mapper.Map<Country>(countryEntity);
            return Task.FromResult(createdModel);
        }

        public void DeleteCountry(int id)
        {
            var existingCountry = _dataContext.Countries.Where(x => x.Id == id).FirstOrDefault();
            if (existingCountry == null) 
            {
                throw new ResourceNotFoundException("Country with that id does not exist!");
            }
            _dataContext.Countries.Remove(existingCountry);
            _dataContext.SaveChanges();
        }

        public Task<List<Country>> GetAll()
        {
            var countries = _dataContext.Countries.OrderBy(p => p.Id).ToList();
            List<Country> result = _mapper.Map<List<Country>>(countries);
            return Task.FromResult(result);
        }

        public Task<Country> GetById(int id)
        {
            var countryEntity = _dataContext.Countries.Where(p => p.Id == id).FirstOrDefault();
            if (countryEntity == null)
            {
                throw new ResourceNotFoundException("Country with that id does not exist!");
            }
            var countryModel = _mapper.Map<Country>(countryEntity);
            return Task.FromResult(countryModel);
        }

        public Task<Country> GetByName(string name)
        {
            var countryEntity = _dataContext.Countries.Where(p => p.Name == name).FirstOrDefault();
            if (countryEntity == null)
            {
                throw new ResourceNotFoundException("Country with that name does not exist!");
            }
            var countryModel = _mapper.Map<Country>(countryEntity);
            return Task.FromResult(countryModel);
        }

        public Task<Country> UpdateCountry(Country country)
        {
            var existingcountry = _dataContext.Countries.Where(p => p.Id == country.Id).FirstOrDefault();
            if (existingcountry == null)
            {
                throw new ResourceNotFoundException("Country with that id does not exist!");
            }
            _dataContext.Attach(existingcountry);
            _dataContext.Entry(existingcountry).CurrentValues.SetValues(country);
            _dataContext.SaveChanges();
            var updatedcountry = _dataContext.Countries.Where(p => p.Id == country.Id).FirstOrDefault();
            if (updatedcountry == null)
            {
                throw new ArgumentException("Unsuccessful operation!");
            }
            return Task.FromResult(_mapper.Map<Country>(updatedcountry));
        }
    }
}
