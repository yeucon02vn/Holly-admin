using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileCenter.Models.DTO
{
    [Table("SanPham")]
    public class SanPhamDTO
    {
        [Key]
        public int IdSanPham { get; set; }
        public int IdDanhMucSanPham { get; set; }
        public DanhMucSanPhamDTO DanhMucSanPham { get; set; }
        public int IdHinhSanPham { get; set; }
        public HinhSanPhamDTO HinhSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string MoTaSanPham { get; set; }
        public int GiaSanPham { get; set; }
        public int SoLuong { get; set; }
        public SanPhamDTO() {
            DanhMucSanPham = new DanhMucSanPhamDTO();
            HinhSanPham = new HinhSanPhamDTO();
        }
        public ICollection<ChiTietDonHangDTO> ChiTietDonHang { get; set; }
        public ICollection<GioHangDTO> GioHang{ get; set; }
    }
}
