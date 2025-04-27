using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DoAnBds.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaiViet> BaiViets { get; set; }

    public virtual DbSet<BatDongSan> BatDongSans { get; set; }

    public virtual DbSet<BoPhan> BoPhans { get; set; }

    public virtual DbSet<ChiTietBatDongSanKh> ChiTietBatDongSanKhs { get; set; }

    public virtual DbSet<ChiTietBatDongSanNt> ChiTietBatDongSanNts { get; set; }

    public virtual DbSet<DanhMucBatDongSan> DanhMucBatDongSans { get; set; }

    public virtual DbSet<Form> Forms { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhaThau> NhaThaus { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BatDongSan;User Id=sa;Password=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaiViet>(entity =>
        {
            entity.HasKey(e => e.MaBv).HasName("PK__BaiViet__27247595500B0A22");

            entity.ToTable("BaiViet");

            entity.Property(e => e.MaBv)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaBV");
            entity.Property(e => e.AnhBv)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("AnhBV");
            entity.Property(e => e.MaNv)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.NoiDungBv)
                .HasMaxLength(10000000)
                .HasColumnName("NoiDungBV");
            entity.Property(e => e.TenBv)
                .HasMaxLength(200)
                .HasColumnName("TenBV");
            entity.Property(e => e.ThoiGian)
                   .HasMaxLength(100)
                   .HasColumnName("ThoiGian");
            entity.Property(e => e.NoiDungBv)
              .HasMaxLength(10000)
              .HasColumnName("NoiDungBv");
            entity.Property(e => e.NoiDungBV2)
            .HasMaxLength(10000)
            .HasColumnName("NoiDungBV2");
            entity.Property(e => e.NoiDungBV3)
            .HasMaxLength(10000)
            .HasColumnName("NoiDungBv3");
            entity.Property(e => e.NoiDungBV4)
           .HasMaxLength(10000)
           .HasColumnName("NoiDungBv4");
            entity.Property(e => e.NoiDungBV5)
         .HasMaxLength(10000)
         .HasColumnName("NoiDungBv5");
            entity.Property(e => e.AnhBV1)
       .HasMaxLength(10000)
       .HasColumnName("AnhBV1");
            entity.Property(e => e.AnhBV2)
.HasMaxLength(10000)
.HasColumnName("AnhBV2");
            entity.Property(e => e.AnhBV3)
.HasMaxLength(10000)
.HasColumnName("AnhBV3");
            entity.Property(e => e.AnhBV4)
.HasMaxLength(10000)
.HasColumnName("AnhBV4");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.BaiViets)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK__BaiViet__MaNV__5FB337D6");
        });

        modelBuilder.Entity<BatDongSan>(entity =>
        {
            entity.HasKey(e => e.MaBds).HasName("PK__BatDongS__352177DB650865A9");

            entity.ToTable("BatDongSan");

            entity.Property(e => e.MaBds)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaBDS");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.MoTa1).HasMaxLength(100000);
            entity.Property(e => e.MoTa2).HasMaxLength(100000);
            entity.Property(e => e.MoTa3).HasMaxLength(100000);
            entity.Property(e => e.HinhAnh1).HasMaxLength(50);
            entity.Property(e => e.HinhAnh2).HasMaxLength(50);
            entity.Property(e => e.HinhAnh3).HasMaxLength(50);
            entity.Property(e => e.GiaBds).HasColumnName("GiaBDS");
            entity.Property(e => e.HinhAnh)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MaDm)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaDM");
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenBds)
                .HasMaxLength(50)
                .HasColumnName("TenBDS");

            entity.HasOne(d => d.MaDmNavigation).WithMany(p => p.BatDongSans)
                .HasForeignKey(d => d.MaDm)
                .HasConstraintName("FK__BatDongSan__MaDM__44FF419A");
        });

        modelBuilder.Entity<BoPhan>(entity =>
        {
            entity.HasKey(e => e.MaBp).HasName("PK__BoPhan__272475AB390E3991");

            entity.ToTable("BoPhan");

            entity.Property(e => e.MaBp)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaBP");
            entity.Property(e => e.TenBp)
                .HasMaxLength(100)
                .HasColumnName("TenBP");
        });

        modelBuilder.Entity<ChiTietBatDongSanKh>(entity =>
        {
            entity.HasKey(e => e.MaChiTietKh).HasName("PK__ChiTietB__651DD3553EA149A2");

            entity.ToTable("ChiTietBatDongSanKH");

            entity.Property(e => e.MaChiTietKh)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaChiTietKH");
            entity.Property(e => e.MaBds)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaBDS");
            entity.Property(e => e.MaKh)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaKH");

            entity.HasOne(d => d.MaBdsNavigation).WithMany(p => p.ChiTietBatDongSanKhs)
                .HasForeignKey(d => d.MaBds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietBa__MaBDS__4F7CD00D");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.ChiTietBatDongSanKhs)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietBat__MaKH__4E88ABD4");
        });

        modelBuilder.Entity<ChiTietBatDongSanNt>(entity =>
        {
            entity.HasKey(e => e.MaChiTietNt).HasName("PK__ChiTietB__651DDBBAE3295ECB");

            entity.ToTable("ChiTietBatDongSanNT");

            entity.Property(e => e.MaChiTietNt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaChiTietNT");
            entity.Property(e => e.MaBds)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaBDS");
            entity.Property(e => e.MaNt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaNT");

            entity.HasOne(d => d.MaBdsNavigation).WithMany(p => p.ChiTietBatDongSanNts)
                .HasForeignKey(d => d.MaBds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietBa__MaBDS__4BAC3F29");

            entity.HasOne(d => d.MaNtNavigation).WithMany(p => p.ChiTietBatDongSanNts)
                .HasForeignKey(d => d.MaNt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietBat__MaNT__4AB81AF0");
        });

        modelBuilder.Entity<DanhMucBatDongSan>(entity =>
        {
            entity.HasKey(e => e.MaDm).HasName("PK__DanhMucB__2725866E36C4760F");

            entity.ToTable("DanhMucBatDongSan");

            entity.Property(e => e.MaDm)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaDM");
            entity.Property(e => e.HinhAnh).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(200);
            entity.Property(e => e.TenDm)
                .HasMaxLength(50)
                .HasColumnName("TenDM");
        });

        modelBuilder.Entity<Form>(entity =>
        {
            entity.HasKey(e => e.MaForm).HasName("PK__Form__E3C18CD1FE47D00D");

            entity.ToTable("Form");

            entity.Property(e => e.ChuDe).HasMaxLength(255);
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.Gmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NoiDung).HasMaxLength(1000);
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ten).HasMaxLength(50);
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1E06ADBE3F");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaKH");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.TenKh)
                .HasMaxLength(50)
                .HasColumnName("TenKH");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(50)
                .HasColumnName("SoDienThoai");

            entity.HasOne(d => d.MaFormNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.MaForm)
                .HasConstraintName("FK__KhachHang__MaFor__47DBAE45");
        });

        modelBuilder.Entity<NhaThau>(entity =>
        {
            entity.HasKey(e => e.MaNt).HasName("PK__NhaThau__2725D734AFAC89DB");

            entity.ToTable("NhaThau");

            entity.Property(e => e.MaNt)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaNT");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.Gmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenNt)
                .HasMaxLength(50)
                .HasColumnName("TenNT");
            entity.Property(e => e.SoDienThoai)
              .HasMaxLength(50)
              .HasColumnName("SoDienThoai");

            entity.HasOne(d => d.MaFormNavigation).WithMany(p => p.NhaThaus)
                .HasForeignKey(d => d.MaForm)
                .HasConstraintName("FK__NhaThau__MaForm__3C69FB99");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70AAA2B8BC6");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.CaLamViec).HasMaxLength(50);
            entity.Property(e => e.GioiTinh).HasMaxLength(4);
            entity.Property(e => e.MaBp)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("MaBP");
            entity.Property(e => e.TenNv)
                .HasMaxLength(50)
                .HasColumnName("TenNV");

            entity.HasOne(d => d.MaBpNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaBp)
                .HasConstraintName("FK__NhanVien__MaBP__412EB0B6");

            entity.HasOne(d => d.MaQuyenNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaQuyen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NhanVien__MaQuye__4222D4EF");
        });

        modelBuilder.Entity<PhanQuyen>(entity =>
        {
            entity.HasKey(e => e.MaQuyen).HasName("PK__PhanQuye__1D4B7ED46A6FAB95");

            entity.ToTable("PhanQuyen");

            entity.Property(e => e.MaQuyen).ValueGeneratedNever();
            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TenQuyen).HasMaxLength(50);
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
