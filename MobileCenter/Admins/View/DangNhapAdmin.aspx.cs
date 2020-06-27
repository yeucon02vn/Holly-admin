using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MobileCenter.Models.BUS;
using MobileCenter.Models.DTO;

namespace MobileCenter.Admins.View
{
    public partial class DangNhapAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            textUsername.Focus();
        }
        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                NguoiDungDTO nguoidung = new NguoiDungDTO();
                NguoiDungBUS xulydangnhapadmin = new NguoiDungBUS();
                nguoidung.TenDangNhap = textUsername.Text;
                nguoidung.MatKhau = textMatKhau.Text;
                xulydangnhapadmin._nguoiDung = nguoidung;
                /*try
                {*/
                    xulydangnhapadmin.LoginWithAdmin();
                    if (xulydangnhapadmin.IsAuthenticated)
                    {
                        FormsAuthentication.RedirectFromLoginPage(textUsername.Text, false);
                        Response.Redirect("~/admin/sanpham");
                    }
                    else
                    {
                        labelMessage.Text = "Đăng nhập không thành công!";
                    }
                /*}
                catch
                {
                    Response.Redirect("../Trangloi.aspx");
                }*/
            }
        }
    }
}