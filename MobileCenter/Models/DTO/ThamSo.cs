using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileCenter.Models.DTO
{
    [Table("ThamSo")]
    public class ThamSo
    {
        [Key]
        public int Id { get; set; }
        public int? SoLuongTruyCap { get; set; }
    }
}