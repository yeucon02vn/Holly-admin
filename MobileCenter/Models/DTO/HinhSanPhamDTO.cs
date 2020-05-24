using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileCenter.Models.DTO
{
    [Table("HinhSanPham")]
    public class HinhSanPhamDTO
    {
        [Key]
        public int IdHinhSanPham { get; set; }
        public Byte[] LinkSanPham { get; set; }

        public ICollection<SanPhamDTO> SanPham { get; set; }
    }
}