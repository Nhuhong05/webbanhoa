using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webhoa.Migrations
{
    /// <inheritdoc />
    public partial class Flower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<int>(type: "int", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "LoaiHoa",
                columns: table => new
                {
                    MaLoai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiHoa", x => x.MaLoai);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    MaTK = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.MaTK);
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    MaDH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSP = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    MaKH = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.MaDH);
                    table.ForeignKey(
                        name: "FK_DonHang_KhachHang",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH");
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    MaGH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSP = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    MaKH = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.MaGH);
                    table.ForeignKey(
                        name: "FK_GioHang_KhachHang",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH");
                });

            migrationBuilder.CreateTable(
                name: "Hoa",
                columns: table => new
                {
                    MaSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hinhanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    Xuatxu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mausac = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaLoai = table.Column<int>(type: "int", nullable: true),
                    NgayNhap = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoa", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_Hoa_LoaiHoa",
                        column: x => x.MaLoai,
                        principalTable: "LoaiHoa",
                        principalColumn: "MaLoai");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_MaKH",
                table: "DonHang",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_GioHang_MaKH",
                table: "GioHang",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_Hoa_MaLoai",
                table: "Hoa",
                column: "MaLoai");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "Hoa");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "LoaiHoa");
        }
    }
}
