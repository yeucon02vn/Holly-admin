using MobileCenter.App_User;
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
    public partial class ThemDonHang : NguoiDungHienTai
    {
        private DonHangDTO _donhang = new DonHangDTO();
        private decimal _tongtien = 0; // để tính tổng cột thành tiền

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblWelcome = (Label)Master.FindControl("lblChao");
                lblWelcome.Text = "Xin chào, " + base._NguoiDungHienTai.HoTen;
                HienThiGioHang();
            }
        }

        private void HienThiGioHang()
        {
            GioHangDTO gioHang = new GioHangDTO();
            gioHang.CartGuid = TaoCartGuid.LayCartGUID();
            GioHangBUS gioHangBUS = new GioHangBUS();
            gioHangBUS._gioHang = gioHang;
            try
            {
                gioHangBUS.Select();
                gridgiohang.DataSource = gioHangBUS.KetQua;
                gridgiohang.DataBind();
            }
            catch
            {
                Response.Redirect("Trangloi.aspx");
            }
        }
        //-------------------Tính tổng cộng của cột thành tiền trong Gridview-------------
        protected void gridgiohang_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                _tongtien += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ThanhTien"));
            }
            lblTotal.Text = _tongtien.ToString() + " VND";
        }
        //---------Tạo đơn hàng, dựa số liệu trên gridview giỏ hàng-------------------
        private void GuiDonHang()
        {
            DonHangBUS donHangBUS = new DonHangBUS();
            donHangBUS._donhang = _donhang;

            try
            {
                donHangBUS.Insert();
            }
            catch
            {
                Response.Redirect("Trangloi.aspx");
            }
            Response.Redirect("GioiThieuSanPham.aspx");
        }
        //---------------Sự kiện cho nút tiếp tục mua hàng----------------------------------
        protected void ImageButtonTieptucmuahang_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("GioiThieuSanPham.aspx");
        }
        //---------------Sự kiện cho nút tạo và gửi đơn hàng-----------------

        protected void ImageButtonTaovaguidonhang_Click(object sender, ImageClickEventArgs e)
        {
            DonHangDTO donHang = new DonHangDTO();
            SanPhamDTO[] dsSanPham = new SanPhamDTO[gridgiohang.Rows.Count];
            foreach (GridViewRow grow in gridgiohang.Rows)
            {
                if (grow.RowType == DataControlRowType.DataRow)
                {
                    SanPhamDTO sanPham = new SanPhamDTO();
                    DataKey data = gridgiohang.DataKeys[grow.DataItemIndex];
                    sanPham.IdSanPham = int.Parse(data.Values["IdSanPham"].ToString());
                    Label lblTenSanPham = (Label)grow.FindControl("lblTenSanPham");
                    sanPham.TenSanPham = lblTenSanPham.Text;
                    Label lblSoLuong = (Label)grow.FindControl("lblSoLuong");
                    sanPham.SoLuong = int.Parse(lblSoLuong.Text);
                    Label lblDonGia = (Label)grow.FindControl("lblDonGia");
                    sanPham.GiaSanPham = Convert.ToInt32(lblDonGia.Text.Replace("VND", ""));
                    dsSanPham.SetValue(sanPham, grow.DataItemIndex);
                }
            }
            _donhang.ChiTietDonHang.SanPham = dsSanPham;
            _donhang.IdNguoiDung = _NguoiDungHienTai.IdNguoiDung;
            //Giả lập tạo TransactionID
            _donhang.MaGiaoDich = Guid.NewGuid().ToString();
            GuiDonHang();
        }
    }
}