using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Core.Exceptions;
using TimeSheet.Core.IRepositories;
using TimeSheet.Core.Models;

namespace TimeSheet.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IMapper _mapper;
        private DataContext _dataContext;
        public ClientRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public Task<Client> AddClient(Client client)
        {
            var clientEntity = _mapper.Map<Entities.Client>(client);
            _dataContext.Clients.Add(clientEntity);
            _dataContext.SaveChanges();
            var createdModel = _mapper.Map<Client>(clientEntity);
            return Task.FromResult(createdModel);
        }

        public void DeleteClient(int id)
        {
            var existingClient = _dataContext.Clients.Where(x => x.Id == id).FirstOrDefault();
            if (existingClient == null)
            {
                throw new ResourceNotFoundException("Client with that id does not exist!");
            }
            _dataContext.Clients.Remove(existingClient);
            _dataContext.SaveChanges();
        }

        public Task<Client> GetById(int id)
        {
            var clientEntity = _dataContext.Clients.Where(p => p.Id == id).FirstOrDefault();
            if (clientEntity == null)
            {
                throw new ResourceNotFoundException("Client with that id does not exist!");

            }
            var clientModel = _mapper.Map<Client>(clientEntity);
            return Task.FromResult(clientModel);

        }

        public Task<Client> GetByName(string name)
        {
            var clientEntity = _dataContext.Clients.Where(p => p.Name == name).FirstOrDefault();
            if (clientEntity == null)
            {
                throw new ResourceNotFoundException("Client with that name does not exist!");
            }
            var clientModel = _mapper.Map<Client>(clientEntity);
            return Task.FromResult(clientModel);
        }

        public Task<Client> UpdateClient(Client client)
        {
            var existingClient = _dataContext.Clients.Where(p => p.Id == client.Id).FirstOrDefault();
            if (existingClient == null)
            {
                throw new ResourceNotFoundException("Client with that id does not exist!");
            }
            _dataContext.Attach(existingClient);
            _dataContext.Entry(existingClient).CurrentValues.SetValues(client);
            _dataContext.SaveChanges();
            var updatedClient = _dataContext.Clients.Where(p => p.Id == client.Id).FirstOrDefault();
            if (updatedClient == null)
            {
                throw new ArgumentException();
            }
            var mappedClient = _mapper.Map<Client>(updatedClient);
            return Task.FromResult(mappedClient);
        }

        public async Task<List<Client>> GetAll()
        {
            var categories = await _dataContext.Clients.OrderBy(p => p.Id).ToListAsync();
            List<Client> result = _mapper.Map<List<Client>>(categories);
            return result;
        }
    }
}
