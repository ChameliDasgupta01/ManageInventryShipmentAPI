using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using ManageInventryShipmentAPI.Data;
using ManageInventryShipmentAPI.DAL;
using ManageInventryShipmentAPI.BAL;
using System.Xml;

namespace ManageInventryShipmentAPI.NUnitTests
{
    /// <summary>
    /// This assumes we want to test the ProductService class which might contain methods like GetProduct, AddProduct, UpdateProduct, or DeleteProduct.
    /// </summary>
    [TestFixture]
    public class ProductServiceTests
    {        
        private IProductService _productService;
        private Mock<IProductRepository> _mockRepository;  //Mocks: We're using Moq to mock the IProductRepository (assuming this is an interface that your ProductService relies on). This avoids calling real database operations during tests.

        /// <summary>
        /// SetUp(): Initializes the ProductService and the mocked repository before each test
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            // Arrange
            _mockRepository = new Mock<IProductRepository>();
            _productService = new ProductService(_mockRepository.Object);
        }


        
        [Test]
        public async Task AddProductAsync_ShouldCallAddProductAsync_OnRepository()
        {
            // Arrange
            var product = new Product { ProductId = 1, ProductName = "Test Product", ProductDescription="Test product desc", Quantityinstock=20, Price = 99 };

            // Act
            await _productService.AddProductAsync(product);

            // Assert
            _mockRepository.Verify(repo => repo.AddProductAsync(product), Times.Once);
           
        }

        [Test]
        public void AddProductAsync_ShouldThrowArgumentException_WhenProductNameIsNullOrEmpty()
        {
            // Arrange
            var invalidProduct = new Product { ProductId = 1, ProductName = "", ProductDescription = "Test product desc", Quantityinstock = 20, Price = 99 }; // Invalid Name

            // Act & Assert
            var exception = Assert.ThrowsAsync<ArgumentException>(async () => await _productService.AddProductAsync(invalidProduct));
            Assert.That(exception.Message, Is.EqualTo("Product name cannot be null or empty."));
        }

        [Test]
        public void AddProductAsync_ShouldThrowArgumentException_WhenProductPriceIsZeroOrNegative()
        {
            // Arrange
            var invalidProduct = new Product { ProductId = 1, ProductName = "Test Product", ProductDescription = "Test product desc", Quantityinstock = 20, Price = -99 }; // Invalid Price (0)

            // Act & Assert
            var exception = Assert.ThrowsAsync<ArgumentException>(async () => await _productService.AddProductAsync(invalidProduct));
            Assert.That(exception.Message, Is.EqualTo("Product price must be greater than zero."));

            // Test negative price
            invalidProduct.Price = -10;
            exception = Assert.ThrowsAsync<ArgumentException>(async () => await _productService.AddProductAsync(invalidProduct));
            Assert.That(exception.Message, Is.EqualTo("Product price must be greater than zero."));
        }

        [Test]
        public void AddProductAsync_ShouldThrowArgumentException_WhenProductIsNull()
        {
            // Arrange & Act & Assert
            var exception = Assert.ThrowsAsync<ArgumentException>(async () => await _productService.AddProductAsync(null));
            Assert.That(exception.Message, Is.EqualTo("Product name cannot be null or empty."));
        }

        [Test]
        public async Task GetAllProductsAsync_ShouldReturnListOfProducts_WhenProductsExist()
        {
            // Arrange: Create a list of products
            var products = new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Product 1", ProductDescription="Prod dec1", Quantityinstock=20, Price = 10.0m },
                new Product {  ProductId = 2, ProductName = "Product 2", ProductDescription="Prod dec2", Quantityinstock=30, Price = 200 }
            };

            // Set up the mock to return the list of products
            _mockRepository.Setup(repo => repo.GetAllProductsAsync())
                .ReturnsAsync(products);

            // Act: Call the method
            var result = await _productService.GetAllProductsAsync();

            // Assert: Verify that the result is the same list of products
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("Product 1", result.First().ProductName);
            Assert.AreEqual("Product 2", result.Last().ProductName);
        }

        [Test]
        public async Task GetAllProductsAsync_ShouldReturnEmptyList_WhenNoProductsExist()
        {
            // Arrange: Set up the mock to return an empty list
            _mockRepository.Setup(repo => repo.GetAllProductsAsync())
                .ReturnsAsync(new List<Product>());

            // Act: Call the method
            var result = await _productService.GetAllProductsAsync();

            // Assert: Verify that the result is an empty list
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public async Task UpdateProductAsync_ShouldCallUpdateProductAsync_OnRepository_WhenProductIsValid()
        {
            // Arrange: Create a valid product to update
            var product = new Product { ProductId = 1, ProductName = "Product 1", ProductDescription = "Prod dec1", Quantityinstock = 20, Price = 10.0m };

            // Set up the mock repository to pretend the update was successful
            _mockRepository.Setup(repo => repo.UpdateProductAsync(product))
                .Returns(Task.CompletedTask); // Simulate a successful update

            // Act: Call the UpdateProductAsync method
            await _productService.UpdateProductAsync(product);

            // Assert: Verify that the UpdateProductAsync method was called once with the correct product
            _mockRepository.Verify(repo => repo.UpdateProductAsync(product), Times.Once);
        }

        [Test]
        public void UpdateProductAsync_ShouldThrowArgumentNullException_WhenProductIsNull()
        {
            // Act & Assert: Verify that an ArgumentNullException is thrown if product is null
            var exception = Assert.ThrowsAsync<ArgumentNullException>(async () => await _productService.UpdateProductAsync(null));
            Assert.That(exception.ParamName, Is.EqualTo("product"));
        }

        [Test]
        public async Task UpdateProductAsync_ShouldHandleRepositoryFailure_WhenUpdateFails()
        {
            // Arrange: Create a valid product to update
            var product = new Product { ProductId = 1, ProductName = "Product 1", ProductDescription = "Prod dec1", Quantityinstock = 20, Price = 10.0m };

            // Set up the mock to simulate a failure in the repository (e.g., an exception)
            _mockRepository.Setup(repo => repo.UpdateProductAsync(product))
                .ThrowsAsync(new Exception("Database update failed"));

            // Act & Assert: Verify that the exception is thrown
            var exception = Assert.ThrowsAsync<Exception>(async () => await _productService.UpdateProductAsync(product));
            Assert.That(exception.Message, Is.EqualTo("Database update failed"));
        }

    }

}

