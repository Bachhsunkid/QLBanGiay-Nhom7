using System;
using System.Collections.Generic;

namespace Nhom8.QuanLyBanGiay.User.Models;

public partial class NhaCungCap
{
    public string MaNcc { get; set; } = null!;

    public string? TenNcc { get; set; }

    public string? SoDienThoai { get; set; }

    public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; } = new List<HoaDonNhap>();
}
