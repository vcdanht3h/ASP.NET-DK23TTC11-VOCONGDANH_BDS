using System;
using System.Collections.Generic;

namespace DoAnBds.Models;

public partial class NhaThau
{
    public string? TenNt { get; set; }

    public string MaNt { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? Gmail { get; set; }

    public string? SoDienThoai { get; set; }

    public int? MaForm { get; set; }

    public virtual ICollection<ChiTietBatDongSanNt> ChiTietBatDongSanNts { get; set; } = new List<ChiTietBatDongSanNt>();

    public virtual Form? MaFormNavigation { get; set; }
}
