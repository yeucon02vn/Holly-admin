using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MobileCenter.Models.BUS;
using MobileCenter.Models.DTO;

namespace MobileCenter.Admins.View
{
    public partial class ChiTietDonHang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiTinhTrangDonHang();
                HienThiChiTietDonHang();
            }
        }
        private void HienThiChiTietDonHang()
        {
            ChiTietDonHangBUS xuLyChiTietDonHang = new ChiTietDonHangBUS();
            DonHangBUS xuLyDonHangId = new DonHangBUS();
            ChiTietDonHangDTO chiTietDonHang = new ChiTietDonHangDTO();
            chiTietDonHang.IdDonHang = int.Parse(Request.QueryString["IdDonHang"]);
            xuLyChiTietDonHang._chiTietDonHang = chiTietDonHang;
            DonHangDTO donHang = new DonHangDTO();
            donHang.IdDonHang = int.Parse(Request.QueryString["IdDonHang"]);
            xuLyDonHangId._donhang = donHang;
            try
            {
                xuLyChiTietDonHang.Select();
                xuLyDonHangId.SelectById();
            }
            catch
            {
                Response.Redirect("../Trangloi.aspx");
            }
            gridviewOrderDetailsProducts.DataSource = xuLyChiTietDonHang.KetQua;
            gridviewOrderDetailsProducts.DataBind();
            //------Hiển thị ID giao dịch trong label------------------
            labelTransactionID.Text = Request.QueryString["MaGiaoDich"];
            //------Hiển thị ngày xử lý đơn hàng---------------------
            if (donHang.NgayXuLyDonHang != DateTime.MinValue)
            {
                textShippedDate.Text = donHang.NgayXuLyDonHang.ToShortDateString();
            }
            //--------Hiển thị giá trị Trackingnumber trong textbox---------
            textTrackingNumber.Text = donHang.TrackingNumber;
            //-------Lấy dữ liệu tình trạng đơn hàng trong dropdowlist-------
            dropdownlistOrderStatus.SelectedIndex =
            dropdownlistOrderStatus.Items.IndexOf(dropdownlistOrderStatus.Items.FindByValue(donHang.IdTinhTrangDonHang.ToString()));
        }
        // Hiển thị tình trạng đơn hàng trong dropdownlist-------
        private void HienThiTinhTrangDonHang()
        {
            TinhTrangDonHangBUS xuLyLayTinhTrangDonHang = new TinhTrangDonHangBUS();
            try
            {
                xuLyLayTinhTrangDonHang.Select();
            }
            catch
            {
                Response.Redirect("../Trangloi.aspx");
            }
            dropdownlistOrderStatus.DataTextField = "TenTinhTrangDonHang";
            dropdownlistOrderStatus.DataValueField = "IdTinhTrangDonHang";
            dropdownlistOrderStatus.DataSource = xuLyLayTinhTrangDonHang.KetQua;
            dropdownlistOrderStatus.DataBind();
        }
        //---------Xự kiện nút trở về--------------------
        protected void btnTroVe_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~admin/thongkedonhang");
        }
        // ---------sự kiện kích image button--------------

        protected void imagebuttonDatePicker_Click(object sender, ImageClickEventArgs e)
        {
            if (calendarDatePicker.Visible)
            {
                calendarDatePicker.Visible = false;
            }
            else
            {
                calendarDatePicker.Visible = true;
            }
        }
        //----------Sự kiện chọn giá trị trên điều khiển Calenda------
        protected void calendarDatePicker_SelectionChanged(object sender, EventArgs e)
        {
            textShippedDate.Text = calendarDatePicker.SelectedDate.ToShortDateString();
            calendarDatePicker.Visible = false;
        }
        // --Xử lý nút cập nhật để cập nhật thay đổi đơn hàng sau khi xử lý-------

        protected void btnCapNhat_Click(object sender, ImageClickEventArgs e)
        {
            DonHangDTO donHang = new DonHangDTO();
            DonHangBUS xulycapnhatdonhang = new DonHangBUS();
            donHang.IdDonHang = int.Parse(Request.QueryString["IdDonHang"]);
            donHang.IdTinhTrangDonHang =
            int.Parse(dropdownlistOrderStatus.SelectedItem.Value);
            donHang.NgayXuLyDonHang = Convert.ToDateTime(textShippedDate.Text);
            donHang.TrackingNumber = textTrackingNumber.Text;
            xulycapnhatdonhang._donhang = donHang;         
            try
            {
                xulycapnhatdonhang.Update();
            }
            catch
            {
                Response.Redirect("../Trangloi.aspx");
            }
            Response.Redirect("~admin/thongkedonhang");
        }
    }
}