using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
using Domain;

//shortcuts
    //prop: creates standard class
    //ctor: creates constructor 
    

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        //use as table name inside sql light
        public DbSet<Value> Values { get; set; }
        //accessible to class itself;  ovveride b/c overriding DbContext method; void b/c not returning anything
        protected override void OnModelCreating(ModelBuilder builder)
        {
        builder.Entity<Value>()
            .HasData(
                new Value {Id = 1, Name = "Value 101"},
                new Value {Id = 2, Name = "Value 102"},
                new Value {Id = 3, Name = "Value 103"}
            );
        }
    }
}
