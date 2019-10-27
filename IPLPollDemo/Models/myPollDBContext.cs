using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IPLPollDemo.Models
{
    public partial class myPollDBContext : DbContext
    {
        public myPollDBContext()
        {
        }

        public myPollDBContext(DbContextOptions<myPollDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IplTeams> IplTeams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=myPollDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IplTeams>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
