﻿using Microsoft.EntityFrameworkCore;

namespace OnlineBookstore.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Order> Orders { get; set; }
}