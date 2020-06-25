using MobileCenter.App_User;
using MobileCenter.Models.BUS;
using MobileCenter.Models.DTO;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileCenter.View
{
    public partial class DangNhap : NguoiDungHienTai
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            textUsername.Focus();
        }

        protected void btnDangNhap_Click(object sender, ImageClickEventArgs e)
        {
            if (IsValid)
            {
                NguoiDungDTO nguoiDung = new NguoiDungDTO();
                NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
                nguoiDung.TenDangNhap = textUsername.Text;
                nguoiDung.MatKhau = textMatKhau.Text;
                nguoiDungBUS._nguoiDung = nguoiDung;
                nguoiDungBUS.LoginWithUser();
                try
                {

                    labelMessage.Text = "Đăng nhập thành công!";
                }
                catch
                {
                    Response.Redirect("TrangLoi.aspx");
                }
                if (nguoiDungBUS.IsInvalid)
                {
                    base._NguoiDungHienTai = nguoiDungBUS._nguoiDung;
                    Label lblWelcome = (Label)Master.FindControl("lblchao");
                    lblWelcome.Text = "Xin chào, " + base._NguoiDungHienTai.HoTen;
                    if (Request.Cookies["ReturnURL"] != null)
                    {
                        Response.Redirect(Request.Cookies["ReturnURL"].Value);
                    }
                    else
                    {
                        Response.Redirect("DonHangKhachHang.aspx");
                    }
                }
                else
                {
                    labelMessage.Text = "Đăng nhập không thành công!";
                }   
            }
        }
    }
}