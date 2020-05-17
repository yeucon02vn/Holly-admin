using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MobileCenter.Models.DTO;

namespace MobileCenter.Models
{
    public class dbMobileCenterContext : DbContext
    {
        public dbMobileCenterContext() : base("name=dataMobileCenter")
        {

        }

        public DbSet<NguoiDungDTO> NguoiDung { get; set; }
        public DbSet<ThamSo> ThamSo { get; set; }
        public DbSet<TinhTrangDonHangDTO> TinhTrangDonHang { get; set; }
        public DbSet<SanPhamDTO> SanPham { get; set; }
        public DbSet<KieuNguoiDungDTO> KieuNguoiDung { get; set; }
        public DbSet<HinhSanPhamDTO> HinhSanPham { get; set; }
        public DbSet<GioHangDTO> GioHang { get; set; }
        public DbSet<DonHangDTO > DonHang { get; set; }
        public DbSet<DanhMucSanPhamDTO> DanhMucSanPham { get; set; }
        public DbSet<ChiTietDonHangDTO> ChiTietDonHang { get; set; }
    }
}