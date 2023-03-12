using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Nhom8.QuanlyBanGiay.Admin.Models;

public partial class QlbanGiayContext : DbContext
{
    public QlbanGiayContext()
    {
    }

    public QlbanGiayContext(DbContextOptions<QlbanGiayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Anh> Anhs { get; set; }

    public virtual DbSet<AutoId> AutoIds { get; set; }

    public virtual DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }

    public virtual DbSet<ChiTietHdb> ChiTietHdbs { get; set; }

    public virtual DbSet<ChiTietHdn> ChiTietHdns { get; set; }

    public virtual DbSet<DanhGia> DanhGia { get; set; }

    public virtual DbSet<Giay> Giays { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }

    public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-AISAFVG\\SQLEXPRESS;Initial Catalog=QLBanGiay;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.AdminId)
                .HasMaxLength(20)
                .HasColumnName("AdminID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.TaiKhoan).HasMaxLength(100);
        });

        modelBuilder.Entity<Anh>(entity =>
        {
            entity.HasKey(e => e.MaAnh);

            entity.ToTable("Anh");

            entity.Property(e => e.MaAnh).HasMaxLength(20);
            entity.Property(e => e.DuongDan).HasColumnType("text");
            entity.Property(e => e.MaGiay).HasMaxLength(20);

            entity.HasOne(d => d.MaGiayNavigation).WithMany(p => p.Anhs)
                .HasForeignKey(d => d.MaGiay)
                .HasConstraintName("FK_Anh_Giay");
        });

        modelBuilder.Entity<AutoId>(entity =>
        {
            entity.HasKey(e => e.IdName);

            entity.ToTable("AutoId");

            entity.Property(e => e.IdName).HasMaxLength(50);
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<ChiTietGioHang>(entity =>
        {
            entity.HasKey(e => new { e.MaGioHang, e.MaGiay });

            entity.ToTable("ChiTietGioHang");

            entity.Property(e => e.MaGioHang).HasMaxLength(20);
            entity.Property(e => e.MaGiay).HasMaxLength(20);

            entity.HasOne(d => d.MaGiayNavigation).WithMany(p => p.ChiTietGioHangs)
                .HasForeignKey(d => d.MaGiay)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietGioHang_Giay");

            entity.HasOne(d => d.MaGioHangNavigation).WithMany(p => p.ChiTietGioHangs)
                .HasForeignKey(d => d.MaGioHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietGioHang_GioHang");
        });

        modelBuilder.Entity<ChiTietHdb>(entity =>
        {
            entity.HasKey(e => e.MaHdb);

            entity.ToTable("ChiTietHDB");

            entity.Property(e => e.MaHdb)
                .HasMaxLength(20)
                .HasColumnName("MaHDB");
            entity.Property(e => e.KhuyenMai).HasColumnType("money");
            entity.Property(e => e.MaGiay).HasMaxLength(20);

            entity.HasOne(d => d.MaGiayNavigation).WithMany(p => p.ChiTietHdbs)
                .HasForeignKey(d => d.MaGiay)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHDB_Giay");

            entity.HasOne(d => d.MaHdbNavigation).WithOne(p => p.ChiTietHdb)
                .HasForeignKey<ChiTietHdb>(d => d.MaHdb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHDB_HoaDonBan");
        });

        modelBuilder.Entity<ChiTietHdn>(entity =>
        {
            entity.HasKey(e => e.MaHdn);

            entity.ToTable("ChiTietHDN");

            entity.Property(e => e.MaHdn)
                .HasMaxLength(20)
                .HasColumnName("MaHDN");
            entity.Property(e => e.KhuyenMai).HasColumnType("money");
            entity.Property(e => e.MaGiay).HasMaxLength(20);

            entity.HasOne(d => d.MaGiayNavigation).WithMany(p => p.ChiTietHdns)
                .HasForeignKey(d => d.MaGiay)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHDN_Giay");

            entity.HasOne(d => d.MaHdnNavigation).WithOne(p => p.ChiTietHdn)
                .HasForeignKey<ChiTietHdn>(d => d.MaHdn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ChiTietHDN_HoaDonNhap");
        });

        modelBuilder.Entity<DanhGia>(entity =>
        {
            entity.HasKey(e => e.MaDanhGia);

            entity.Property(e => e.MaDanhGia).HasMaxLength(20);
            entity.Property(e => e.MaGiay).HasMaxLength(20);
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.NoiDung).HasMaxLength(100);

            entity.HasOne(d => d.MaGiayNavigation).WithMany(p => p.DanhGiaNavigation)
                .HasForeignKey(d => d.MaGiay)
                .HasConstraintName("FK_DanhGia_Giay");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK_DanhGia_KhachHang");
        });

        modelBuilder.Entity<Giay>(entity =>
        {
            entity.HasKey(e => e.MaGiay);

            entity.ToTable("Giay");

            entity.Property(e => e.MaGiay).HasMaxLength(20);
            entity.Property(e => e.GiaBan).HasColumnType("money");
            entity.Property(e => e.GiaGoc).HasColumnType("money");
            entity.Property(e => e.GiaNhap).HasColumnType("money");
            entity.Property(e => e.KieuDang).HasMaxLength(100);
            entity.Property(e => e.Loai).HasMaxLength(50);
            entity.Property(e => e.MauSac).HasMaxLength(50);
            entity.Property(e => e.TenGiay).HasMaxLength(100);
            entity.Property(e => e.TinhTrang).HasMaxLength(25);
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => e.MaGioHang);

            entity.ToTable("GioHang");

            entity.Property(e => e.MaGioHang).HasMaxLength(20);
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.TongTien).HasColumnType("money");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GioHang_KhachHang");
        });

        modelBuilder.Entity<HoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHdb);

            entity.ToTable("HoaDonBan");

            entity.Property(e => e.MaHdb)
                .HasMaxLength(20)
                .HasColumnName("MaHDB");
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayBan).HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("money");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK_HoaDonBan_KhachHang");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK_HoaDonBan_NhanVien");
        });

        modelBuilder.Entity<HoaDonNhap>(entity =>
        {
            entity.HasKey(e => e.MaHdn).HasName("PK_MaHDN");

            entity.ToTable("HoaDonNhap");

            entity.Property(e => e.MaHdn)
                .HasMaxLength(20)
                .HasColumnName("MaHDN");
            entity.Property(e => e.MaNcc)
                .HasMaxLength(20)
                .HasColumnName("MaNCC");
            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayNhap).HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("money");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.HoaDonNhaps)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("FK_HoaDonNhap_NhaCungCap");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDonNhaps)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK_HoaDonNhap_NhanVien");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh);

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.DiaChi).HasColumnType("text");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TaiKhoan).HasMaxLength(100);
            entity.Property(e => e.TenKh)
                .HasMaxLength(100)
                .HasColumnName("TenKH");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc);

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.MaNcc)
                .HasMaxLength(20)
                .HasColumnName("MaNCC");
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenNcc)
                .HasMaxLength(255)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv);

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .HasColumnName("MaNV");
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.HoTenNv)
                .HasMaxLength(255)
                .HasColumnName("HoTenNV");
            entity.Property(e => e.Luong).HasColumnType("money");
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.NgaySinh).HasColumnType("date");
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TaiKhoan).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
