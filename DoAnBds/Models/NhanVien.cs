using System;
using System.Collections.Generic;

namespace DoAnBds.Models;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    public string? TenNv { get; set; }

    public string? GioiTinh { get; set; }

    public int MaQuyen { get; set; }

    public string? CaLamViec { get; set; }

    public string? MaBp { get; set; }

    public virtual ICollection<BaiViet> BaiViets { get; set; } = new List<BaiViet>();

    public virtual BoPhan? MaBpNavigation { get; set; }

    public virtual PhanQuyen MaQuyenNavigation { get; set; } = null!;
}
