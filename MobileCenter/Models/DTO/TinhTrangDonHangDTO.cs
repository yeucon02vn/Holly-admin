using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileCenter.Models.DTO
{
    [Table("TinhTrangDonHang")]
    public class TinhTrangDonHangDTO
    {
        [Key]
        public int IdTinhTrangDonHang { get; set; }
        public string TenTinhTrangDonHang { get; set; }
        public ICollection<DonHangDTO> DonHang { get; set; }
    }
}