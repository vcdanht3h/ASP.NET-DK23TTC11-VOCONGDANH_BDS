using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoAnBds.Models;

public partial class Form   
{
    [Required]
    public int MaForm { get; set; }

    public string? Ten { get; set; }

    public string? Gmail { get; set; }

    public string? ChuDe { get; set; }

    public string? NoiDung { get; set; }

    public string? DiaChi { get; set; }
    public bool Status { get; set; }

    public string? SoDienThoai { get; set; }

    public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();

    public virtual ICollection<NhaThau> NhaThaus { get; set; } = new List<NhaThau>();
}
