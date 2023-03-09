using System;
using System.Collections.Generic;

namespace Nhom8.QuanLyBanGiay.User.Models;

public partial class HoaDonBan
{
    public string MaHdb { get; set; } = null!;

    public string MaNv { get; set; } = null!;

    public string MaKh { get; set; } = null!;

    public DateTime? NgayBan { get; set; }

    public byte? TrangThai { get; set; }

    public decimal? TongTien { get; set; }

    public virtual ChiTietHdb? ChiTietHdb { get; set; }

    public virtual KhachHang MaKhNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
