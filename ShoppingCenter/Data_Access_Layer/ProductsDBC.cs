using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ShoppingCenter.Models;

namespace ShoppingCenter.Data_Access_Layer
{
    public class ProductsDBC : DbContext 
    {
        public ProductsDBC() : base("name=ProductsDBC ")
        {
        }
        public DbSet<Products> productsList { get; set; }
    }
}