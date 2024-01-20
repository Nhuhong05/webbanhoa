using System;
using System.Collections.Generic;

namespace webhoa.Entities;

public partial class Hoa
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

    public virtual LoaiHoa? MaLoaiNavigation { get; set; }
}
