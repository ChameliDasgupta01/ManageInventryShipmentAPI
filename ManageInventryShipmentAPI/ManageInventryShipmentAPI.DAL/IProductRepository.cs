﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ManageInventryShipmentAPI.Data;

namespace ManageInventryShipmentAPI.DAL
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
