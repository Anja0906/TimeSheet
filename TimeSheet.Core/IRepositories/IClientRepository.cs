using TimeSheet.Core.Models;

namespace TimeSheet.Core.IRepositories
{
    public interface IClientRepository
    {
        Task<Client> GetByName(string name);
        Task<Client> UpdateClient(Client client);
        Task<List<Client>> GetAll();
        Task<Client> GetById(int id);
        Task<Client> AddClient(Client client);
        void DeleteClient(int id);
    }
}
