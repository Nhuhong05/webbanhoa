using webhoa.Entities;
using System.ComponentModel.DataAnnotations;
namespace webhoa.Model
{
    public class HoaVM
    {

        public int MaSp { get; set; }

        public string? TenSp { get; set; }

        public string? Hinhanh { get; set; }

        public decimal? Gia { get; set; }

        public int? SoLuong { get; set; }

        public string? Xuatxu { get; set; }

        public string? Mota { get; set; }

     

        public string? Mausac { get; set; }

        public int? MaLoai { get; set; }

        public DateTime? NgayNhap { get; set; }

      
    }
}
