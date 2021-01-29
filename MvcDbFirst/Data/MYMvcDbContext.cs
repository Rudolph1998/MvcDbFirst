using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MvcDbFirst.Models;

#nullable disable

namespace MvcDbFirst.Data
{
    public partial class MYMvcDbContext : DbContext
    {
        public MYMvcDbContext()
        {
        }

        public MYMvcDbContext(DbContextOptions<MYMvcDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeeTb> EmployeeTbs { get; set; }
        public virtual DbSet<EmployeesDb> EmployeesDbs { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<TblCity> TblCities { get; set; }
        public virtual DbSet<TblProduct> TblProducts { get; set; }
        public virtual DbSet<Tblcategory> Tblcategories { get; set; }
        public virtual DbSet<Tblcountry> Tblcountries { get; set; }
        public virtual DbSet<Tbldept> Tbldepts { get; set; }
        public virtual DbSet<Tblsize> Tblsizes { get; set; }
        public virtual DbSet<Tblstate> Tblstates { get; set; }
        public virtual DbSet<UsersDetail> UsersDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(local);Database=MYMvcDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EmployeeTb>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.EmpFirstName).IsUnicode(false);

                entity.Property(e => e.EmpId).ValueGeneratedOnAdd();

                entity.Property(e => e.EmpLastName).IsUnicode(false);

                entity.Property(e => e.MobNo).IsUnicode(false);

                entity.Property(e => e.Pincode).IsUnicode(false);
            });

            modelBuilder.Entity<EmployeesDb>(entity =>
            {
                entity.Property(e => e.Addresses).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.EmpFirstName).IsUnicode(false);

                entity.Property(e => e.EmpLastName).IsUnicode(false);

                entity.Property(e => e.Mobno).IsUnicode(false);

                entity.Property(e => e.Pincode).IsUnicode(false);

                entity.HasOne(d => d.DidNavigation)
                    .WithMany(p => p.EmployeesDbs)
                    .HasForeignKey(d => d.Did)
                    .HasConstraintName("FK__EmployeesDB__Did__239E4DCF");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.ProductColor).IsUnicode(false);

                entity.Property(e => e.ProductName).IsUnicode(false);

                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.Property(e => e.Size).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ProductColour).IsUnicode(false);

                entity.Property(e => e.ProductName).IsUnicode(false);

                entity.Property(e => e.Status).HasDefaultValueSql("('false')");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_catagoryid");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_Products_SizeId");
            });

            modelBuilder.Entity<TblCity>(entity =>
            {
                entity.Property(e => e.Cityname).IsUnicode(false);
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.ProductColour).IsUnicode(false);

                entity.Property(e => e.ProductName).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblProducts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_tblProducts_tblcategory");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.TblProducts)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_tblProducts_tblsize");
            });

            modelBuilder.Entity<Tblcategory>(entity =>
            {
                entity.Property(e => e.CategoryName).IsUnicode(false);
            });

            modelBuilder.Entity<Tblcountry>(entity =>
            {
                entity.Property(e => e.Cname).IsUnicode(false);
            });

            modelBuilder.Entity<Tbldept>(entity =>
            {
                entity.Property(e => e.Did).ValueGeneratedNever();

                entity.Property(e => e.Dname).IsUnicode(false);
            });

            modelBuilder.Entity<Tblsize>(entity =>
            {
                entity.Property(e => e.SizeName).IsUnicode(false);
            });

            modelBuilder.Entity<Tblstate>(entity =>
            {
                entity.Property(e => e.Sname).IsUnicode(false);
            });

            modelBuilder.Entity<UsersDetail>(entity =>
            {
                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Emailid).IsUnicode(false);

                entity.Property(e => e.Gender).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Phone).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.UsersDetails)
                    .HasForeignKey(d => d.Cid)
                    .HasConstraintName("FK__UsersDetail__Cid__412EB0B6");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.UsersDetails)
                    .HasForeignKey(d => d.Cityid)
                    .HasConstraintName("FK__UsersDeta__Cityi__4316F928");

                entity.HasOne(d => d.SidNavigation)
                    .WithMany(p => p.UsersDetails)
                    .HasForeignKey(d => d.Sid)
                    .HasConstraintName("FK__UsersDetail__Sid__4222D4EF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
