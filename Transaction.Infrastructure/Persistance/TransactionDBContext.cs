

using Microsoft.EntityFrameworkCore;
using Transaction.Entities;

namespace Transaction.Infrastructure.Persistance
{
    public partial class TransactionDBContext : DbContext
    {


        public TransactionDBContext(DbContextOptions<TransactionDBContext> options)
            : base(options)
        {

        }


        public virtual DbSet<ShiftMaster> ShiftMaster { get; set; }

        public virtual DbSet<TransactionEntity> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ShiftMaster>(entity =>
            {
                entity.Property(e => e.ShiftGuid)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
                entity.Property(e => e.ShiftName).IsUnicode(false);
            });

            modelBuilder.Entity<TransactionEntity>(entity =>
            {
                entity.Property(e => e.Transaction_Id)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });




        }
    }
}
