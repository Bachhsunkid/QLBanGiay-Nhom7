using System;
using System.Collections.Generic;

namespace Nhom8.QuanLyBanGiay.User.Models;

public partial class Admin
{
    public string AdminId { get; set; } = null!;

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public string? Email { get; set; }
}
