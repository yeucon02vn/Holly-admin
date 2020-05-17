using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileCenter.Models.DTO
{
    [Table("DanhMucSanPham")]
    public class DanhMucSanPhamDTO
    {
        [Key]
        public int IdDanhMucSanPham { get; set; }
        public int TenDanhMucSanPham { get; set; }
    }
}