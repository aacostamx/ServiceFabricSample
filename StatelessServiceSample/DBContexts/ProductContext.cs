﻿using Microsoft.EntityFrameworkCore;
using StatelessServiceSample.Models;

namespace StatelessServiceSample.DBContexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
