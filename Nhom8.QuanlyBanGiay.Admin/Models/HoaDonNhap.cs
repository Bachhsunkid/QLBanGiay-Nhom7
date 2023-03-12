using System;
using System.Collections.Generic;

namespace Nhom8.QuanlyBanGiay.Admin.Models;

public partial class HoaDonNhap
{
    public string MaHdn { get; set; } = null!;

    public string? MaNv { get; set; }

    public string? MaNcc { get; set; }

    public DateTime? NgayNhap { get; set; }

    public decimal? TongTien { get; set; }

    public virtual ChiTietHdn? ChiTietHdn { get; set; }

    public virtual NhaCungCap? MaNccNavigation { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }
}
