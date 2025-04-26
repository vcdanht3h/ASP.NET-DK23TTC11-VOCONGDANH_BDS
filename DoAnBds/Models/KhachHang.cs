using System;
using System.Collections.Generic;

namespace DoAnBds.Models;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string? TenKh { get; set; }

    public string? DiaChi { get; set; }
    public string? Gmail { get; set; }
    public string? SoDienThoai { get; set; }

    public int? MaForm { get; set; }

    public virtual ICollection<ChiTietBatDongSanKh> ChiTietBatDongSanKhs { get; set; } = new List<ChiTietBatDongSanKh>();

    public virtual Form? MaFormNavigation { get; set; }
}
