using System;
using System.Collections.Generic;

namespace webhoa.Entities;

public partial class LoaiHoa
{
    public int MaLoai { get; set; }

    public string? TenLoai { get; set; }

    public virtual ICollection<Hoa> Hoas { get; set; } = new List<Hoa>();
}
