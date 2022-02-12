using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {
            
        }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options){}
        public DbSet<User> Users {get; set;}
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string sConnection = "Server=localhost;Port=3306;Database=news;Uid=root;Pwd=root";
            
            optionsBuilder.UseMySql(sConnection
                , ServerVersion.AutoDetect(sConnection), null );
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);     

            //não sei se é necessário.
            modelBuilder.ApplyConfiguration(new UserMap());



        }
    }
}