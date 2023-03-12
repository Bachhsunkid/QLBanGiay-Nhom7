using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nhom8.QuanlyBanGiay.Admin.Models;

public partial class HoaDonBan
{
    [Required(ErrorMessage = "Vui lòng nhập mã hoá đơn")]
    public string MaHdb { get; set; } = null!;

    public string? MaNv { get; set; }

    public string? MaKh { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập ngày bán")]
    public DateTime? NgayBan { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập trạng thái")]
    public byte? TrangThai { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập tổng tiền")]
    public decimal? TongTien { get; set; }

    public virtual ChiTietHdb? ChiTietHdb { get; set; }

    public virtual KhachHang? MaKhNavigation { get; set; }

    public virtual NhanVien? MaNvNavigation { get; set; }
}
