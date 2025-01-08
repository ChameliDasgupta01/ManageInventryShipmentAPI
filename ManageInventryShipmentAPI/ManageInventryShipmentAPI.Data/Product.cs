using System.ComponentModel.DataAnnotations;

namespace ManageInventryShipmentAPI.Data
{
    /// <summary>
    /// This is the Entity Framework (EF) model class represents the structure of the data 
    /// in terms of entities (tables in the database). These model classes are typically used in conjunction with Entity Framework Core (EF Core), an Object-Relational Mapper (ORM) that allows you to interact with a database using C# objects rather than SQL queries.
    /// </summary>
    public class Product
    {
        [Key]
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "The ProductId must be a positive integer.")]
        public int ProductId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(350, MinimumLength = 5)]
        public string ProductDescription {  get; set; }

        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "The Quantityinstock must be a positive integer.")]
        public int Quantityinstock { get; set; }

        [Required]
        [Range(0, 100000)]
        public Decimal Price { get; set; }

    }
}
