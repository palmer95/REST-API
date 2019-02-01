using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SCD_Web_API.Models
{
    public partial class TEST_SCDAPIContext : DbContext
    {
        public TEST_SCDAPIContext()
        {
        }

        public TEST_SCDAPIContext(DbContextOptions<TEST_SCDAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<UserLogins> UserLogins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=ENC-SQL-02;Database=TEST_SCD-API;User=Test_API_Read;Password=Encore03;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLogins>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.ToTable("User_Logins");

                entity.Property(e => e.Username)
                    .HasMaxLength(32)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64);
            });
        }
    }
}
