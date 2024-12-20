using Microsoft.EntityFrameworkCore;

namespace MiniKpayWithRepositoryDesignPattern.Database.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    #region DbSet

    public virtual DbSet<TblDeposit> TblDeposits { get; set; }

    public virtual DbSet<TblTransaction> TblTransactions { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblWithdraw> TblWithdraws { get; set; }

    #endregion

    #region Connection String

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=MiniKpay;User Id=sa;Password=sasa@123;TrustServerCertificate=True;");

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblDeposit>(entity =>
        {
            entity.HasKey(e => e.DepositId).HasName("PK__Tbl_Depo__7C0DCEED2A3BC8DC");

            entity.ToTable("Tbl_Deposit");

            entity.Property(e => e.DepositId).HasColumnName("Deposit_Id");
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<TblTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Tbl_Tran__9A8D5605C85BA4DC");

            entity.ToTable("Tbl_Transaction");

            entity.Property(e => e.TransactionId).HasColumnName("Transaction_Id");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FromPhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Pin)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ToPhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Tbl_User__3214EC079E5C4291");

            entity.ToTable("Tbl_User");

            entity.HasIndex(e => e.PhoneNumber, "UQ__Tbl_User__85FB4E382A8244E1").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("User_Id");
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Pin)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<TblWithdraw>(entity =>
        {
            entity.HasKey(e => e.WithdrawId).HasName("PK__Tbl_With__206211CA1AF92F06");

            entity.ToTable("Tbl_Withdraw");

            entity.Property(e => e.WithdrawId).HasColumnName("Withdraw_Id");
            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
