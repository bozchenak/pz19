using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18
{
    public class ClientRepository : IClientRepository
    {
        private readonly b1kolychevaDemEntities _context = new b1kolychevaDemEntities();
        public Task<Clients> AddCustomerAsync(Clients customer)
        {
            _context.Clients.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public Task DeleteCustomerAsync(Guid customerId)
        {
            var customer = _context.Clients
                .FirstOrDefault(x => x.Id == customerId);
            if (customer != null)
            {
                _context.Clients.Remove(customer);
            }
            await _context.SaveChangesAsync();
        }

        public Task<Clients> GetCustomerByIdAsync(Guid customerId)
        {
            return _context.Clients.FirstOrDefaultAsync(x => x.Id == customerId);
        }
        }

        public Task<List<Clients>> GetCustomersAsync()
        {
            return _context.Clients .ToListAsync();
        }

        public Task<Clients> UpdateCustomerAsync(Clients customer)
        {
            if (!_context.Clients.Local.Any(x => x.Id == customer.Id))
            {
                _context.Clients.Attach(customer);
            }
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
