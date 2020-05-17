using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileCenter.Models.DTO
{
    [Table("KieuNguoiDung")]
    public class KieuNguoiDungDTO
    {
        [Key]
        public int IdKieuNguoiDung { get; set; }
        public string TenKieuNguoiDung { get; set; }
        public ICollection<NguoiDungDTO> NguoiDung { get; set; }
    }
}