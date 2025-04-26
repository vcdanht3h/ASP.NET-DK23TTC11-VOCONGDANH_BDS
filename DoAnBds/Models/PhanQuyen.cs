using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoAnBds.Models;

public partial class PhanQuyen
{
    
    public int MaQuyen { get; set; }

    public string? TenQuyen { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }

    public string? ChucVu { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
