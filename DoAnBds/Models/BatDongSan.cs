using System;
using System.Collections.Generic;

namespace DoAnBds.Models;

public partial class BatDongSan
{
    public string MaBds { get; set; } = null!;

    public double? GiaBds { get; set; }

    public string? TenBds { get; set; }

    public string? DiaChi { get; set; }

    public string? MaDm { get; set; }

    public string? HinhAnh { get; set; }

    public string? MoTa { get; set; }
    public string? MoTa1 { get; set; }
    public string? MoTa2 { get; set; }
    public string? MoTa3 { get; set; }
    public string? HinhAnh1 { get; set; }
    public string? HinhAnh2 { get; set; }
    public string? HinhAnh3 { get; set; }
    public virtual ICollection<ChiTietBatDongSanKh> ChiTietBatDongSanKhs { get; set; } = new List<ChiTietBatDongSanKh>();

    public virtual ICollection<ChiTietBatDongSanNt> ChiTietBatDongSanNts { get; set; } = new List<ChiTietBatDongSanNt>();

    public virtual DanhMucBatDongSan? MaDmNavigation { get; set; }
}
