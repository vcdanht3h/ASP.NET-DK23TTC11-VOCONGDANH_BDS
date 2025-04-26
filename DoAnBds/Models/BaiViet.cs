using System;
using System.Collections.Generic;

namespace DoAnBds.Models;

public partial class BaiViet
{
    public string MaBv { get; set; } = null!;

    public string? TenBv { get; set; }

    public string? AnhBv { get; set; }

    public string? NoiDungBv { get; set; }

    public string? ThoiGian { get; set; }

    public string? MaNv { get; set; }
    public string? NoiDungBV2 { get; set; }
    public string? AnhBV1 { get; set; }
    public string? AnhBV2 { get; set; }
    public string? AnhBV3 { get; set; }
    public string? AnhBV4 { get; set; }
    public string? NoiDungBV3 { get; set; }
    public string? NoiDungBV4 { get; set; }
    public string? NoiDungBV5 { get; set; }
    public virtual NhanVien? MaNvNavigation { get; set; }
}
