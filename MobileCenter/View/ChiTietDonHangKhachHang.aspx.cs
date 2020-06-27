using MobileCenter.App_User;
using MobileCenter.Models.BUS;
using MobileCenter.Models.DTO;
using MOONLY.Common;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileCenter.View
{
    public partial class ChiTietDonHangKhachHang : NguoiDungHienTai
    {
        private decimal _tongtien;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblWelcome = (Label)Master.FindControl("lblchao");
                lblWelcome.Text = "Xin chào, " + base._NguoiDungHienTai.HoTen;
                HienChiTietDonHang();
            }
        }
        protected void gridChiTietDonHang_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                _tongtien += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "GiaSanPham"));
            }
            lblTongTien.Text = string.Format(_tongtien.ToString()) + " VNĐ";
        }
        private void HienChiTietDonHang()
        {
            ChiTietDonHangBUS chiTietDonHangBUS = new ChiTietDonHangBUS();
            ChiTietDonHangDTO chitietdonhang = new ChiTietDonHangDTO();
            chitietdonhang.IdDonHang = int.Parse(Request.QueryString["IdDonHang"]);
            chiTietDonHangBUS._chiTietDonHang = chitietdonhang;
            try
            {
                chiTietDonHangBUS.Select();
            }
            catch
            {
                Response.Redirect("Trangloi.aspx");
            }
            gridChiTietDonHang.DataSource = chiTietDonHangBUS.KetQua;
            gridChiTietDonHang.DataBind();
            lblIDGiaoDich.Text = Request.QueryString["IdGiaoDich"];
            DonHang donhang = new DonHang();
            donhang.Idgiaodich = Request.QueryString["IdGiaoDich"];
        }
    }
}