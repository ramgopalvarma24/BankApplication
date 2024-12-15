using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BankApp_DAL.Models
{
    public partial class BankApplication_DBContext : DbContext
    {
        public BankApplication_DBContext()
        {
        }

        public BankApplication_DBContext(DbContextOptions<BankApplication_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source =.;Initial Catalog=BankApplication_DB;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountNumber)
                    .HasName("pk_accountNumber");

                //entity.Property(e => e.AccountNumber).ValueGeneratedNever();
                entity.Property(e => e.AccountNumber).ValueGeneratedOnAdd();


                entity.Property(e => e.AccountName).HasMaxLength(100);

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                //entity.HasNoKey();
              
                entity.HasKey(e => e.Id);  // Explicitly setting primary key


                entity.Property(e => e.AmountDebited)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Amount_Debited");

                entity.Property(e => e.DetailsLink)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Details_Link");

                entity.Property(e => e.FromAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("From_Account");

                entity.Property(e => e.FromAccountBalance)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("From_Account_Balance");

                entity.Property(e => e.ToAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("To_Account");

                entity.Property(e => e.ToAccountBalance)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("To_Account_Balance");

                entity.Property(e => e.TransactionTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Transaction_Time");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
