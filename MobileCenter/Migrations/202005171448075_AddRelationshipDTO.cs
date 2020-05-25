namespace MobileCenter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationshipDTO : DbMigration
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
                .PrimaryKey(t => t.IdChiTietDonHang)
                .ForeignKey("dbo.DonHang", t => t.IdDonHang, cascadeDelete: true)
                .ForeignKey("dbo.SanPham", t => t.IdSanPham, cascadeDelete: true)
                .Index(t => t.IdSanPham)
                .Index(t => t.IdDonHang);
            
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
                        MaGiaoDich = c.String(),
                })
                .PrimaryKey(t => t.IdDonHang)
                .ForeignKey("dbo.NguoiDung", t => t.IdNguoiDung, cascadeDelete: true)
                .ForeignKey("dbo.TinhTrangDonHang", t => t.IdTinhTrangDonHang, cascadeDelete: true)
                .Index(t => t.IdNguoiDung)
                .Index(t => t.IdTinhTrangDonHang);
            
            CreateTable(
                "dbo.NguoiDung",
                c => new
                    {
                        IdNguoiDung = c.Int(nullable: false, identity: true),
                        IdKieuNguoiDung = c.Int(nullable: false),
                        HoTen = c.String(),
                        TenDangNhap = c.String(),
                        DiaChi = c.String(),
                        MatKhau = c.String(),
                        SoDienThoai = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.IdNguoiDung)
                .ForeignKey("dbo.KieuNguoiDung", t => t.IdKieuNguoiDung, cascadeDelete: true)
                .Index(t => t.IdKieuNguoiDung);
            
            CreateTable(
                "dbo.KieuNguoiDung",
                c => new
                    {
                        IdKieuNguoiDung = c.Int(nullable: false, identity: true),
                        TenKieuNguoiDung = c.String(),
                    })
                .PrimaryKey(t => t.IdKieuNguoiDung);
            
            CreateTable(
                "dbo.TinhTrangDonHang",
                c => new
                    {
                        IdTinhTrangDonHang = c.Int(nullable: false, identity: true),
                        TenTinhTrangDonHang = c.String(),
                    })
                .PrimaryKey(t => t.IdTinhTrangDonHang);
            
            CreateTable(
                "dbo.DanhMucSanPham",
                c => new
                    {
                        IdDanhMucSanPham = c.Int(nullable: false, identity: true),
                        TenDanhMucSanPham = c.String(),
                    })
                .PrimaryKey(t => t.IdDanhMucSanPham);
            
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
                        SoLuong = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.IdSanPham)
                .ForeignKey("dbo.DanhMucSanPham", t => t.IdDanhMucSanPham, cascadeDelete: true)
                .ForeignKey("dbo.HinhSanPham", t => t.IdHinhSanPham, cascadeDelete: true)
                .Index(t => t.IdDanhMucSanPham)
                .Index(t => t.IdHinhSanPham);
            
            CreateTable(
                "dbo.GioHang",
                c => new
                    {
                        IdGioHang = c.Int(nullable: false, identity: true),
                        IdSanPham = c.Int(nullable: false),
                        CartGuid = c.String(),
                        SoLuong = c.Int(nullable: false),
                        NgayTaoGioHang = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdGioHang)
                .ForeignKey("dbo.SanPham", t => t.IdSanPham, cascadeDelete: true)
                .Index(t => t.IdSanPham);
            
            CreateTable(
                "dbo.HinhSanPham",
                c => new
                    {
                        IdHinhSanPham = c.Int(nullable: false, identity: true),
                        LinkSanPham = c.Binary(),
                    })
                .PrimaryKey(t => t.IdHinhSanPham);

            CreateTable(
                "dbo.ThamSo",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    SoLuongTruyCap = c.Int(nullable: true, identity: false),
                })
                .PrimaryKey(t => t.Id); ;            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPham", "IdHinhSanPham", "dbo.HinhSanPham");
            DropForeignKey("dbo.GioHang", "IdSanPham", "dbo.SanPham");
            DropForeignKey("dbo.SanPham", "IdDanhMucSanPham", "dbo.DanhMucSanPham");
            DropForeignKey("dbo.ChiTietDonHang", "IdSanPham", "dbo.SanPham");
            DropForeignKey("dbo.DonHang", "IdTinhTrangDonHang", "dbo.TinhTrangDonHang");
            DropForeignKey("dbo.NguoiDung", "IdKieuNguoiDung", "dbo.KieuNguoiDung");
            DropForeignKey("dbo.DonHang", "IdNguoiDung", "dbo.NguoiDung");
            DropForeignKey("dbo.ChiTietDonHang", "IdDonHang", "dbo.DonHang");
            DropIndex("dbo.GioHang", new[] { "IdSanPham" });
            DropIndex("dbo.SanPham", new[] { "IdHinhSanPham" });
            DropIndex("dbo.SanPham", new[] { "IdDanhMucSanPham" });
            DropIndex("dbo.NguoiDung", new[] { "IdKieuNguoiDung" });
            DropIndex("dbo.DonHang", new[] { "IdTinhTrangDonHang" });
            DropIndex("dbo.DonHang", new[] { "IdNguoiDung" });
            DropIndex("dbo.ChiTietDonHang", new[] { "IdDonHang" });
            DropIndex("dbo.ChiTietDonHang", new[] { "IdSanPham" });
            DropTable("dbo.ThamSo");
            DropTable("dbo.HinhSanPham");
            DropTable("dbo.GioHang");
            DropTable("dbo.SanPham");
            DropTable("dbo.DanhMucSanPham");
            DropTable("dbo.TinhTrangDonHang");
            DropTable("dbo.KieuNguoiDung");
            DropTable("dbo.NguoiDung");
            DropTable("dbo.DonHang");
            DropTable("dbo.ChiTietDonHang");
        }
    }
}
