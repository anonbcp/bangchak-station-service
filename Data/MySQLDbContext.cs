﻿using DotnetAPIApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetAPIApp.Data;

public partial class MySQLDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public MySQLDbContext(DbContextOptions<MySQLDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySQL(_configuration.GetConnectionString("MySQLConnectionString")!);


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
