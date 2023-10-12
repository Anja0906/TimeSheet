using TimeSheet.Core.IRepositories;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;

namespace TimeSheet.Service.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public Task<Client> AddClient(Client client)
        {
            return _clientRepository.AddClient(client);
        }

        public void DeleteClient(int id)
        {
            _clientRepository.DeleteClient(id);
        }

        public Task<List<Client>> GetAll()
        {
            return _clientRepository.GetAll();
        }

        public Task<Client> UpdateClient(Client client)
        {
            return _clientRepository.UpdateClient(client);
        }

        public Task<Client> GetByName(string name)
        {
            return _clientRepository.GetByName(name);
        }

        public Task<Client> GetById(int id)
        {
            return _clientRepository.GetById(id);
        }
    }
}
