using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Core.Models;

namespace TimeSheet.Core.IServices
{
    public interface IClientService
    {
        Task<Client> GetByName(string name);
        Task<Client> UpdateClient(Client client);
        Task<List<Client>> GetAll();
        Task<Client> GetById(int id);
        Task<Client> AddClient(Client client);
        void DeleteClient(int id);
    }
}
