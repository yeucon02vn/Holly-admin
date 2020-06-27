using MobileCenter.Models;
using MobileCenter.Models.BUS;
using MobileCenter.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileCenter.View
{
    public partial class ThemGioHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GioHangBUS gioHangBUS = new GioHangBUS();
            GioHangDTO gioHang = new GioHangDTO();
            gioHang.IdSanPham = int.Parse(Request.QueryString["IdSanPham"]);
            gioHang.CartGuid = CartGUID;
            gioHang.SoLuong = 1;
            gioHangBUS._gioHang = gioHang;

            try
            {
                gioHangBUS.Insert();
            }
            catch
            {
                Response.Redirect("Trangloi.aspx");
            }
            Response.Redirect("GioHang.aspx");
        }
        private string CartGUID
        {
            get { return TaoCartGuid.LayCartGUID(); }
        }
    }
}