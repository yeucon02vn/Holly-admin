using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileCenter.Models.DTO
{
    [Table("DonHang")]
    public class DonHangDTO
    {
        [Key]
        public int IdDonHang { get; set; }
        public int IdNguoiDung { get; set; }
        public int IdTinhTrangDonHang { get; set; }
        public DateTime NgayTaoDonHang { get; set; }
        public DateTime NgayXuLyDonHang { get; set; }
        public string TrackingNumber { get; set; }
    }
}