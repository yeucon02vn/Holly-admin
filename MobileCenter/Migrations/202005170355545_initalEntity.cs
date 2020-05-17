namespace MobileCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initalEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietDonHang",
                c => new
                    {
                        IdChiTietDonHang = c.Int(nullable: false, identity: true),
                        IdSanPham = c.Int(nullable: false),
                        IdDonHang = c.Int(nullable: false),
                        SoLuongSanPham = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdChiTietDonHang);
            
            CreateTable(
                "dbo.DanhMucSanPham",
                c => new
                    {
                        IdDanhMucSanPham = c.Int(nullable: false, identity: true),
                        TenDanhMucSanPham = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDanhMucSanPham);
            
            CreateTable(
                "dbo.DonHang",
                c => new
                    {
                        IdDonHang = c.Int(nullable: false, identity: true),
                        IdNguoiDung = c.Int(nullable: false),
                        IdTinhTrangDonHang = c.Int(nullable: false),
                        NgayTaoDonHang = c.DateTime(nullable: false),
                        NgayXuLyDonHang = c.DateTime(nullable: false),
                        TrackingNumber = c.String(),
                    })
                .PrimaryKey(t => t.IdDonHang);
            
            CreateTable(
                "dbo.GioHang",
                c => new
                    {
                        IdGioHang = c.Int(nullable: false, identity: true),
                        IdSanPham = c.Int(nullable: false),
                        CartGuild = c.String(),
                        SoLuong = c.Int(nullable: false),
                        NgayTaoGioHang = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdGioHang);
            
            CreateTable(
                "dbo.HinhSanPham",
                c => new
                    {
                        IdHinhSanPham = c.Int(nullable: false, identity: true),
                        LinkSanPham = c.Binary(),
                    })
                .PrimaryKey(t => t.IdHinhSanPham);
            
            CreateTable(
                "dbo.KieuNguoiDung",
                c => new
                    {
                        IdKieuNguoiDung = c.Int(nullable: false, identity: true),
                        TenKieuNguoiDung = c.String(),
                    })
                .PrimaryKey(t => t.IdKieuNguoiDung);
            
            CreateTable(
                "dbo.NguoiDung",
                c => new
                    {
                        IdNguoiDung = c.Int(nullable: false, identity: true),
                        IdKieuNguoiDung = c.String(),
                    })
                .PrimaryKey(t => t.IdNguoiDung);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        IdSanPham = c.Int(nullable: false, identity: true),
                        IdDanhMucSanPham = c.Int(nullable: false),
                        IdHinhSanPham = c.Int(nullable: false),
                        TenSanPham = c.String(),
                        MoTaSanPham = c.String(),
                        GiaSanPham = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdSanPham);
            
            CreateTable(
                "dbo.ThamSo",
                c => new
                    {
                        SoLuongTruyCap = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.SoLuongTruyCap);
            
            CreateTable(
                "dbo.TinhTrangDonHang",
                c => new
                    {
                        IdTinhTrangDonHang = c.Int(nullable: false, identity: true),
                        TenTinhTrangDonHang = c.String(),
                    })
                .PrimaryKey(t => t.IdTinhTrangDonHang);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TinhTrangDonHang");
            DropTable("dbo.ThamSo");
            DropTable("dbo.SanPham");
            DropTable("dbo.NguoiDung");
            DropTable("dbo.KieuNguoiDung");
            DropTable("dbo.HinhSanPham");
            DropTable("dbo.GioHang");
            DropTable("dbo.DonHang");
            DropTable("dbo.DanhMucSanPham");
            DropTable("dbo.ChiTietDonHang");
        }
    }
}
