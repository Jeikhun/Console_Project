using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberDelivery.Core.Enums;
using UberDelivery.Core.Models;

namespace UberDelivery.Services.Interfaces
{
    public interface IProductService
    {
        public Task<string> CreateAsync(string name, int id, double price, ProductCategory productCategory);
        public Task<string> UpdateAsync(int id, string name, double price);
        public Task<string> RemoveAsync(int id);
        public Task<Product> GetAsync(int id);
        public Task<List<Product>> GetAllAsync();
    }
}
