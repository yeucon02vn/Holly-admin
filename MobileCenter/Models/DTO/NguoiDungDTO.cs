using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileCenter.Models.DTO
{
    [Table("NguoiDung")]
    public class NguoiDungDTO
    {
        [Key]
        public int IdNguoiDung { get; set; }
        public int IdKieuNguoiDung { get; set; }
        public KieuNguoiDungDTO KieuNguoiDung { get; set; }
        public string HoTen { get; set; }
        public string TenDangNhap { get; set; }
        public string DiaChi { get; set; }
        public string MatKhau { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }

        public ICollection<DonHangDTO> DonHang { get; set; }
    }
}