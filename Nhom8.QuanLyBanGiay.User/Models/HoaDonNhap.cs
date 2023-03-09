using System;
using System.Collections.Generic;

namespace Nhom8.QuanLyBanGiay.User.Models;

public partial class HoaDonNhap
{
    public string MaHdn { get; set; } = null!;

    public string MaNv { get; set; } = null!;

    public string MaNcc { get; set; } = null!;

    public DateTime? NgayNhap { get; set; }

    public decimal? TongTien { get; set; }

    public virtual ChiTietHdn? ChiTietHdn { get; set; }

    public virtual NhaCungCap MaNccNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
