using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace webhoa.Entities;

public partial class WebbanhoaContext : IdentityDbContext<IdentityUser>
{
    

    public WebbanhoaContext(DbContextOptions<WebbanhoaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<Hoa> Hoas { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiHoa> LoaiHoas { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-9TDF5CQ\\S;Initial Catalog=webbanhoa;TrustServerCertificate=True;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.MaDh);

            entity.ToTable("DonHang");

            entity.Property(e => e.MaDh).HasColumnName("MaDH");
            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK_DonHang_KhachHang");
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => e.MaGh);

            entity.ToTable("GioHang");

            entity.Property(e => e.MaGh).HasColumnName("MaGH");
            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK_GioHang_KhachHang");
        });

        modelBuilder.Entity<Hoa>(entity =>
        {
            entity.HasKey(e => e.MaSp);

            entity.ToTable("Hoa");

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.Gia).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.NgayNhap).HasColumnType("datetime");
            entity.Property(e => e.TenSp).HasColumnName("TenSP");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.Hoas)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK_Hoa_LoaiHoa");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh);

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.Sdt).HasColumnName("SDT");
            entity.Property(e => e.TenKh).HasColumnName("TenKH");
            entity.Property(e => e.TenTk).HasColumnName("TenTK");
        });

        modelBuilder.Entity<LoaiHoa>(entity =>
        {
            entity.HasKey(e => e.MaLoai);

            entity.ToTable("LoaiHoa");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTk);

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.MaTk).HasColumnName("MaTK");
            entity.Property(e => e.TenTk).HasColumnName("TenTK");
        });

        base.OnModelCreating(modelBuilder);
    }

    //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
