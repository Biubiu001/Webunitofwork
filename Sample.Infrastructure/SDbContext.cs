using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Sample.Infrastructure.Interfaces
{
    public class SDbContext : DbContext
    {
        public SDbContext(DbContextOptions<SDbContext> options) : base(options) => Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder builder)
        {


            var Types = Assembly.Load("Sample.Domain").GetTypes().Where(t => typeof(BaseEntity).IsAssignableFrom(t) && !t.IsAbstract);
            foreach (var type in Types)
            {
                builder.Entity(type);
                var properties = type.GetProperties().ToList();

                foreach (var prop in properties)
                {
                    var des = prop.GetCustomAttribute<DescriptionAttribute>();                    
                    builder.Entity(type).Property(prop.Name).HasComment(des?.Description??" ");
                }


            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.EnableDetailedErrors();
            base.OnConfiguring(builder);
        }
    }
}
