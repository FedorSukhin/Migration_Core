using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration_Core.Models
{
    public class DbContextApp : DbContext
    {
        //создаем таблицу сущностей
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Присваиваем PrimeryKey к ID принудительно
            modelBuilder.Entity<Dish>().HasKey(x => x.Id);
            // Задается имя таблицы принудительно
            modelBuilder.Entity<Dish>().ToTable("NewDishName");
            // Делаем столбец nullable
            modelBuilder.Entity<Dish>().Property(x => x.Price).IsRequired(false);
            base.OnModelCreating(modelBuilder);
        }
        //конструктор DbContext
        public DbContextApp(DbContextOptions options) : base(options)
        {

        }

    }
}
