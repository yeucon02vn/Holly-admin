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
    public partial class SanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienSanPham();
            }
        }
        private void HienSanPham()
        {
            SanPhamBUS xuLySanPham = new SanPhamBUS();
            try
            {
                xuLySanPham.SelectAll();
            }
            catch
            {
                Response.Redirect("../Trangloi.aspx");
            }
            dtlSanpham.DataSource = xuLySanPham.KetQua;
            dtlSanpham.DataBind();
        }
        protected void bntThemSanPham_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/admin/themsanpham");
        }
    }
}