using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;


namespace MobileCenter
{
    public class Global : HttpApplication
    {
        void RegisterRoute(RouteCollection routes)
        {
            routes.MapPageRoute("Home Page","", "~/View/GioiThieuSanPham.aspx");
            routes.MapPageRoute("Admin Page", "admin", "~/Admins/View/DangNhapAdmin.aspx");
            routes.MapPageRoute("Admin SanPham Page", "admin/sanpham", "~/Admins/View/SanPham.aspx");
            routes.MapPageRoute("Admin ChiTietDonHang Page", "admin/chitietdonhang", "~/Admins/View/ChiTietDonHang.aspx");
            routes.MapPageRoute("Admin SuaSanPham Page", "admin/suasanpham", "~/Admins/View/SuaSanPham.aspx");
            routes.MapPageRoute("Admin ThemSanPham Page", "admin/themsanpham", "~/Admins/View/ThemSanPham.aspx");
            routes.MapPageRoute("Admin ThongKeDonHang Page", "admin/thongkedonhang", "~/Admins/View/ThongKeDonHang.aspx");
        }
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoute(RouteTable.Routes);
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}