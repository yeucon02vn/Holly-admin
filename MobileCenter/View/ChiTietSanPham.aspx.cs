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
    public partial class ChiTietSanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Hienchitietsanpham();
            }
        }

        private void Hienchitietsanpham()
        {
            SanPhamDTO sanPham = new SanPhamDTO();
            sanPham.IdSanPham = int.Parse(Request.QueryString["IdSanPham"]);
            SanPhamBUS sanPhamBUS = new SanPhamBUS();
            sanPhamBUS._sanPham = sanPham;
            try
            {
                sanPhamBUS.SelectById();
            }
            catch
            {
                Response.Redirect("Trangloi.aspx");
            }
            dtlChiTietSanPham.DataSource = sanPhamBUS.KetQua;
            // dtlChiTietSanPham là ID của DataList
            dtlChiTietSanPham.DataBind();

        }
    }
}