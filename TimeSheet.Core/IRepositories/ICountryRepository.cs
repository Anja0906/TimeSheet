using TimeSheet.Core.Models;

namespace TimeSheet.Core.IRepositories
{
    public interface ICountryRepository
    {
        Task<Country> GetByName(string name);
        Task<Country> AddCountry(Country country);
        void DeleteCountry(int id);
        Task<Country> UpdateCountry(Country country);
        Task<List<Country>> GetAll();
        Task<Country> GetById(int id);
    }
}
