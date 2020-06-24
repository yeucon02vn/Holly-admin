using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MobileCenter.Models.BUS;
using MobileCenter.Models.DTO;

namespace MobileCenter.Admins.View
{
    public partial class ThongKeDonHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienTatCaDonHang();
            }
        }
        private void HienTatCaDonHang()
        {
            DonHangBUS layTatCaDonHang = new DonHangBUS();
            try
            {
                layTatCaDonHang.SelectAll();
            }
            catch
            {
                Response.Redirect("../Trangloi.aspx");
            }
            gridTatCaDonHang.DataSource = layTatCaDonHang.KetQua;
            gridTatCaDonHang.DataBind();
        }
    }
}