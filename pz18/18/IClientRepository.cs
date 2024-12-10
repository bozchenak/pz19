using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18
{
    public interface IClientRepository
    {
        Task<List<Clients>> GetCustomersAsync();
        //получать пользователя по id
        Task<Clients> GetCustomerByIdAsync(Guid customerId);
        //обновлять пользователя
        Task<Clients> UpdateCustomerAsync(Clients customer);
        //удалять пользователя
        Task DeleteCustomerAsync(Guid customerId);
        //создавать пользователя
        Task<Clients> AddCustomerAsync(Clients customer);
    }
}
