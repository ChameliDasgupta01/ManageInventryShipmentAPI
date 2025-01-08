using ManageInventryShipmentAPI.Data;
using ManageInventryShipmentAPI.DAL;

namespace ManageInventryShipmentAPI.BAL
{
    /// <summary>
    /// ProductService is typically a service layer that encapsulates the business logic 
    /// related to products in an application. The ProductService is a business logic layer that interacts with domain models (such as a Product entity). 
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productRepository"></param>
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task AddProductAsync(Product product)
        {
            await _productRepository.AddProductAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteProductAsync(id);
        }
    
    }
}
