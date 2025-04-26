using System;
using System.Collections.Generic;

namespace DoAnBds.Models;

public partial class DanhMucBatDongSan
{
    public string MaDm { get; set; } = null!;

    public string? TenDm { get; set; }

    public int? SoLuong { get; set; }

    public string? HinhAnh { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<BatDongSan> BatDongSans { get; set; } = new List<BatDongSan>();
}
