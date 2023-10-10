using TimeSheet.Core.Models;

namespace TimeSheet.Core.IRepositories
{
    public interface ICountryRepository
    {
        Task<Country> GetByName(string name);
        void AddCountry(Country country);
        void DeleteCountry(int id);
        Country UpdateCountry(Country country);
        Task<List<Country>> GetAll();
        Task<Country> GetById(int id);
    }
}
