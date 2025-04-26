using System;
using System.Collections.Generic;

namespace DoAnBds.Models;

public partial class ChiTietBatDongSanNt
{
    public string MaChiTietNt { get; set; } = null!;

    public string MaNt { get; set; } = null!;

    public string MaBds { get; set; } = null!;

    public virtual BatDongSan MaBdsNavigation { get; set; } = null!;

    public virtual NhaThau MaNtNavigation { get; set; } = null!;
}
