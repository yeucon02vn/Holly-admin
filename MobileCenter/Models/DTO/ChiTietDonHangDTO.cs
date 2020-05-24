using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileCenter.Models.DTO
{
    [Table("ChiTietDonHang")]
    public class ChiTietDonHangDTO
    {
        [Key]
        public int IdChiTietDonHang { get; set; }
        public int IdSanPham { get; set; }
        public SanPhamDTO[] SanPham { get; set; }
        public int IdDonHang { get; set; }
        public int SoLuongSanPham { get; set; }
        public ChiTietDonHangDTO()
        {
        }
        
    }
}