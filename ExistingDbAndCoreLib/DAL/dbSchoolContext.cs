using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectCore.Entities;

namespace ExistingDbAndCoreLib.DAL
{
    public partial class dbSchoolContext : DbContext
    {
        public dbSchoolContext()
        {
        }

        public dbSchoolContext(DbContextOptions<dbSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.SchoolId);

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.SchoolId);

                entity.ToTable("dbo.Students");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.ToTable("dbo.Schools");
            });
        }
    }
}
