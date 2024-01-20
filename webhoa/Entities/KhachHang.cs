using System;
using System.Collections.Generic;

namespace webhoa.Entities;

public partial class KhachHang
{
    public int MaKh { get; set; }

    public string? TenKh { get; set; }

    public string? TenTk { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public int? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();

    public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();
}
