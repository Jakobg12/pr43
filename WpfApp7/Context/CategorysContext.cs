using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp7.Context
{
    public class CategorysContext : DbContext
    {
        public DbSet<Models.Categorys> Categorys { get; set; }

        public CategorysContext()
        {
            Database.EnsureCreated();
            Categorys.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(Classes.Database.Config.connection, Classes.Database.Config.version);
    }
}
