using MobileCenter.Models.BUS;
using MobileCenter.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileCenter
{
    public partial class ThemSanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTenSanPham.Focus(); // txtTenSanPham là ID của TextBox
            }
        }
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                SanPhamBUS themsanpham = new SanPhamBUS();
                SanPhamDTO Spham = new SanPhamDTO();
                Spham.IdDanhMucSanPham = 1;
                Spham.IdHinhSanPham = 1;
                Spham.TenSanPham = txtTenSanPham.Text; // txtTenSanPham là ID của TextBox
                Spham.MoTaSanPham = CKEditorControlMoTa.Text;//txtTenSanPham là ID của TextBox      
                Spham.HinhSanPham.LinkSanPham = fileuploadHinhSanPham.FileBytes;
                // fileuploadHinhSanPham là ID của điều khiển FileUpLoad
                Spham.GiaSanPham = int.Parse(txtGia.Text); // txtGia là ID của TextBox
                themsanpham._sanPham = Spham;
                try
                {
                    themsanpham.Insert();
                }
                catch
                {
                    Response.Redirect("../Trangloi.aspx");
                }
                Response.Redirect("SanPham.aspx");
            }
        }
        protected void BtnBoQua_Click(object sender, EventArgs e)
        {
            Response.Redirect("SanPham.aspx");
        }
    }
}