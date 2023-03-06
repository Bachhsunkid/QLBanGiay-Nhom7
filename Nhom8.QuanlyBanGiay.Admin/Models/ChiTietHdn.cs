using System;
using System.Collections.Generic;

namespace Nhom8.QuanlyBanGiay.Admin.Models;

public partial class ChiTietHdn
{
    public string MaHdn { get; set; } = null!;

    public string MaGiay { get; set; } = null!;

    public int? SoLuong { get; set; }

    public decimal? KhuyenMai { get; set; }

    public virtual Giay MaGiayNavigation { get; set; } = null!;

    public virtual HoaDonNhap MaHdnNavigation { get; set; } = null!;
}
