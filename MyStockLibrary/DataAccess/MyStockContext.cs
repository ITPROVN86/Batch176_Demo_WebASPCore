using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyStockLibrary.DataAccess
{
    public partial class MyStockContext : DbContext
    {
        public MyStockContext()
        {
        }

        public MyStockContext(DbContextOptions<MyStockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=QuangLe;Database=MyStock;User Id=testuser;Password=abc123!@#;TrustServerCertificate=true;Trusted_Connection=SSPI;Encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.CarName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.HasKey(e => new { e.MaHoaDon, e.MaHangHoa });

                entity.ToTable("ChiTietHoaDon");

                entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.GiamGia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaHangHoaNavigation)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.MaHangHoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDon_HangHoa");

                entity.HasOne(d => d.MaHoaDonNavigation)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.MaHoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDon_HoaDon");
            });

            modelBuilder.Entity<HangHoa>(entity =>
            {
                entity.HasKey(e => e.MaHangHoa);

                entity.ToTable("HangHoa");

                entity.Property(e => e.Anh)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DonGiaBan).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DonGiaNhap).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.GhiChu).HasMaxLength(500);

                entity.Property(e => e.TenHangHoa).HasMaxLength(200);
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon);

                entity.ToTable("HoaDon");

                entity.Property(e => e.NgayBan).HasColumnType("datetime");

                entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaKhachHangNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaKhachHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDon_KhachHang");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDon_NhanVien");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKhachHang);

                entity.ToTable("KhachHang");

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenKhachHang).HasMaxLength(200);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.TenDangNhap);

                entity.ToTable("NguoiDung");

                entity.Property(e => e.TenDangNhap)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoaiNguoiDung).HasDefaultValueSql("((1))");

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien);

                entity.ToTable("NhanVien");

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NgaySinh).HasColumnType("datetime");

                entity.Property(e => e.TenNhanVien).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
