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
    public partial class SanPhamTheoDanhMuc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiSanPham();
            }
        }

        private void HienThiSanPham()
        {
            SanPhamDTO sanPham = new SanPhamDTO();
            sanPham.IdDanhMucSanPham = int.Parse(Request.QueryString["IdDanhMucSanPham"]);
            SanPhamBUS sanPhamBUS = new SanPhamBUS();
            sanPhamBUS._sanPham = sanPham;
            try
            {
                sanPhamBUS.SelectByDanhMuc();
            }
            catch
            {
                Response.Redirect("Trangloi.aspx");
            }
            dtlSanPhamDM.DataSource = sanPhamBUS.KetQua;
            dtlSanPhamDM.DataBind();
        }
    }
}