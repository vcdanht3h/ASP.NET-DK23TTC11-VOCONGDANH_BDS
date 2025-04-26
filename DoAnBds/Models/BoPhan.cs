using System;
using System.Collections.Generic;

namespace DoAnBds.Models;

public partial class BoPhan
{
    public string MaBp { get; set; } = null!;

    public string? TenBp { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
