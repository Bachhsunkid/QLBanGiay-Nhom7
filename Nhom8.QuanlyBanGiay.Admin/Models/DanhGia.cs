using System;
using System.Collections.Generic;

namespace Nhom8.QuanlyBanGiay.Admin.Models;

public partial class DanhGia
{
    public string MaDanhGia { get; set; } = null!;

    public string? MaKh { get; set; }

    public string? MaGiay { get; set; }

    public string? NoiDung { get; set; }

    public double? SoSao { get; set; }

    public virtual Giay? MaGiayNavigation { get; set; }

    public virtual KhachHang? MaKhNavigation { get; set; }
}
