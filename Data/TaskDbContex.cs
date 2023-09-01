using Data.Mapping;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Data
{
    public class TaskDbContex : IdentityDbContext
    {
        public TaskDbContex(DbContextOptions<TaskDbContex> options) : base(options) { }
        //estamos criando nossa tables
        public DbSet<ModelUser> ModelUser { get; set; }
        public DbSet<ModelTask> ModelTask { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());


        }
    }
}

