using System;
using System.Collections.Generic;

namespace Nhom8.QuanLyBanGiay.User.Models;

public partial class Anh
{
    public string MaAnh { get; set; } = null!;

    public string? MaGiay { get; set; }

    public string? DuongDan { get; set; }

    public virtual Giay? MaGiayNavigation { get; set; }
}
