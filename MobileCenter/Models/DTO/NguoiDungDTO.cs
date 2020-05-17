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
        public string IdKieuNguoiDung { get; set; }
    }
}