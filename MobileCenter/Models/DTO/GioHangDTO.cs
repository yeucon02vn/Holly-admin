using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileCenter.Models.DTO
{
    [Table("GioHang")]
    public class GioHangDTO
    {
        [Key]
        public int IdGioHang { get; set; }
        public int IdSanPham { get; set; }
        public SanPhamDTO SanPham { get; set; }
        public string CartGuid { get; set; }
        public int SoLuong { get; set; }
        public DateTime NgayTaoGioHang {get; set; }
        public GioHangDTO()
        {
            SanPham = new SanPhamDTO();
        }
    }
}