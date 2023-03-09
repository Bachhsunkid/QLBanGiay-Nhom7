using System;
using System.Collections.Generic;

namespace Nhom8.QuanLyBanGiay.User.Models;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public string? TenKh { get; set; }

    public string? DiaChi { get; set; }

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<DanhGia> DanhGia { get; } = new List<DanhGia>();

    public virtual ICollection<GioHang> GioHangs { get; } = new List<GioHang>();

    public virtual ICollection<HoaDonBan> HoaDonBans { get; } = new List<HoaDonBan>();
}
