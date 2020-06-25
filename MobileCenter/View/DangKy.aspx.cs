using MobileCenter.App_User;
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
    public partial class DangKy : NguoiDungHienTai
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            textHoTen.Focus();
        }

        protected void btnDangKy_Click(object sender, ImageClickEventArgs e)
        {
            NguoiDungDTO nguoiDung = new NguoiDungDTO();
            NguoiDungBUS nguoiDungBUS = new NguoiDungBUS();
            if (IsValid)
            {
                nguoiDung.IdKieuNguoiDung = 1;
                nguoiDung.HoTen = textHoTen.Text;
                nguoiDung.TenDangNhap = textTenDangNhap.Text;
                nguoiDung.DiaChi = textTenDuongPho.Text + ", " + textThanhPho.Text + ", " + textQuanHuyen.Text  ;
                nguoiDung.MatKhau = textMatKhau.Text;
                nguoiDung.Email = textEmail.Text;
                nguoiDung.SoDienThoai = textSoDienThoai.Text;

                nguoiDungBUS._nguoiDung = nguoiDung;
                nguoiDungBUS.Register();
                //try
                //{
                   
                //}
                //catch
                //{
                //    Response.Redirect("TrangLoi.aspx");
                //}
                _NguoiDungHienTai = nguoiDungBUS._nguoiDung;
                Response.Redirect("DangNhap.aspx");
            }
        }
    }
}