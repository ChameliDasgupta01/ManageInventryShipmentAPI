using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Security.Cryptography.X509Certificates;

namespace ManageInventryShipmentAPI.Data
{
    /// <summary>
    /// The AppDbContext is our custom class that derives from the DbContext class provided by 
    /// Entity Framework Core. It acts as the bridge between your application and the database. 
    /// In this class, we define DbSet properties for each of our model classes (entities) 
    /// that you want to represent as database tables.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// DbContextOptions<AppDbContext> is a parameter passed to the constructor, and it contains the configuration for the DbContext. 
        /// It allows us to specify things like the database provider (e.g., SQL Server, SQLite) and connection strings (or other connection details).
        /// The DbContextOptions object is used by EF Core to configure the context, including how it connects to the database and how it behaves.
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// We define DbSet properties for each of our model classes (entities) that you want to represent as database tables.
        /// </summary>
        public DbSet<Product> Product { get; set; }

    }
}
