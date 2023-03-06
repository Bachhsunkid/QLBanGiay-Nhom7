using System;
using System.Collections.Generic;

namespace Nhom8.QuanlyBanGiay.Admin.Models;

public partial class GioHang
{
    public string MaGioHang { get; set; } = null!;

    public string MaKh { get; set; } = null!;

    public decimal? TongTien { get; set; }

    public virtual ICollection<ChiTietGioHang> ChiTietGioHangs { get; } = new List<ChiTietGioHang>();

    public virtual KhachHang MaKhNavigation { get; set; } = null!;
}
