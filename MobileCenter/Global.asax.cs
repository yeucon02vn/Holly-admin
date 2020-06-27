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
            routes.MapPageRoute("Admin Page", "admin", "~/Admins/View/SanPham.aspx");
        }
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoute(RouteTable.Routes);
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}