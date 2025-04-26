using System;
using System.Collections.Generic;

namespace DoAnBds.Models;

public partial class ChiTietBatDongSanKh
{
    public string MaChiTietKh { get; set; } = null!;

    public string MaKh { get; set; } = null!;

    public string MaBds { get; set; } = null!;

    public virtual BatDongSan MaBdsNavigation { get; set; } = null!;

    public virtual KhachHang MaKhNavigation { get; set; } = null!;
}
