using System;
using System.Collections.Generic;

namespace webhoa.Entities;

public partial class DonHang
{
    public int MaDh { get; set; }

    public int? MaSp { get; set; }

    public int? SoLuong { get; set; }

    public decimal? ThanhTien { get; set; }

    public int? MaKh { get; set; }

    public virtual KhachHang? MaKhNavigation { get; set; }
}
