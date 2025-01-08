using ManageInventryShipmentAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ManageInventryShipmentAPI.DAL
{
    /// <summary>
    /// ProductRepository class handles database interactions,
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        
        private readonly AppDbContext dbContext;
        private readonly ILogger<ProductRepository> loggerInstance;

        /// <summary>
        /// Constructor Injection: Constructor where dependencies are injected
        /// In the constructor of ProductRepository, AppDbContext and ILogger<ProductRepository> 
        /// are injected via DI. This ensures that the repository has access to the database context(dbContext).
        /// It can log messages related to the repository class (loggerInstance).
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public ProductRepository(AppDbContext context, ILogger<ProductRepository> logger)
        {
            dbContext = context;
            loggerInstance= logger;
        }

        /// <summary>
        /// An asynchronous method used to retrieve a list of Product entities from the database
        /// using Entity Framework Core.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            try
            {
                return await dbContext.Product.ToListAsync();
            }
            catch (Exception ex)
            {
                loggerInstance.LogError(ex, "Error fetching all products.");
                throw;
            }
        }

        /// <summary>
        /// An asynchronous method used to retrieve a Product entiti from the database using Entity Framework Core.
        /// </summary>
        /// <param name="id">Product ID</param>
        /// <returns></returns>
        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await dbContext.Product.FindAsync(id);
            }
            catch (Exception ex)
            {
                loggerInstance.LogError(ex, $"Error fetching product with ID {id}.");
                throw;
            }
        }

        /// <summary>
        /// An asynchronous method used to add a entity of product type into the  database using Entity Framework Core.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task AddProductAsync(Product product)
        {
            try
            {
                await dbContext.Product.AddAsync(product);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                loggerInstance.LogError(ex, "Error adding new product.");
                throw;
            }
        }

        /// <summary>
        /// An asynchronous method used to update an existing entity of product type into the  database using Entity Framework Core.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                dbContext.Product.Update(product);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                loggerInstance.LogError(ex, "Error updating product.");
                throw;
            }
        }

        /// <summary>
        /// An asynchronous method used to delete a entity of product type from the  database using Entity Framework Core.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteProductAsync(int id)
        {
            try
            {
                var product = await dbContext.Product.FindAsync(id);
                if (product != null)
                {
                    dbContext.Product.Remove(product);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                loggerInstance.LogError(ex, "Error deleting product.");
                throw;
            }
        }
    
    }
}
