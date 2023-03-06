using System;
using System.Collections.Generic;

namespace Nhom8.QuanlyBanGiay.Admin.Models;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    public string TaiKhoan { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public byte GioiTinh { get; set; }

    public string? HoTenNv { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? SoDienThoai { get; set; }

    public string? ChucVu { get; set; }

    public decimal? Luong { get; set; }

    public byte? TinhTrangCongViec { get; set; }

    public virtual ICollection<HoaDonBan> HoaDonBans { get; } = new List<HoaDonBan>();

    public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; } = new List<HoaDonNhap>();
}
