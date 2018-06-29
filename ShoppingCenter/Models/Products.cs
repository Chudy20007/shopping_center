using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace ShoppingCenter.Models
{
    public class Products
    {
       
        [Key]
        [Required(ErrorMessage = "Wypełnij pola")]
        public int productID { get; set; }
        public string productName { get; set; }
        public double productPrice { get; set; }
        public string productType { get; set; }
        public int productAmount { get; set; }


    }

    public class ProductsDBC : DbContext
    {
        public ProductsDBC() : base("ProductsConnectionString")
        {
        }
        public DbSet<Products> productsList { get; set; }
    }
}