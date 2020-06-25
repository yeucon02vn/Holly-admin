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

    public partial class GioHang : System.Web.UI.Page
    {
        private decimal _tongtien;
        protected void Page_Load(object sender, EventArgs e)
        {
            gridgiohang.PageSize = 10;
            if (!IsPostBack)
            {
                HienThiGioHang();
            }
        }

        private void HienThiGioHang()
        {
            GioHangDTO gioHang = new GioHangDTO();
            gioHang.CartGuid = CartGUID;
            GioHangBUS gioHangBUS = new GioHangBUS();
            gioHangBUS._gioHang = gioHang;
            try
            {
                gioHangBUS.Select();
            }
            catch
            {
                Response.Redirect("Trangloi.aspx");
            }
            gridgiohang.DataSource = gioHangBUS.KetQua;
            gridgiohang.DataBind();
        }
        private string CartGUID
        {
            get { return TaoCartGuid.LayCartGUID(); }
        }
        protected void ImageButtontieptucmuahang_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("gioithieusanpham.aspx");
        }
        protected void ImageButtoncapnhatthaydoi_Click(object sender, ImageClickEventArgs e)
        {
            foreach (GridViewRow row in gridgiohang.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    DataKey data = gridgiohang.DataKeys[row.DataItemIndex];//lay du lieu cua cot lam khoa
                    CheckBox check = (CheckBox)row.FindControl("checkboxDelete");
                    if (check.Checked)
                    {
                        Delete(int.Parse(data.Values["IDgiohang"].ToString()));
                        //IDgiohang la gia tri cua thuoc tinh DataKeyNames="IDgiohang" trong gridview
                        // ma ta tao trong file giao dien giohang.aspx
                    }

                    //-------------------Cập nhật thay đổi số lượng sản phẩm trong TextBox--------------------
                    TextBox textmoi = (TextBox)row.FindControl("textQuantity");
                    int giatri_moi_trong_textbox = int.Parse(textmoi.Text);
                    int giatri_bandau_trong_textbox =
                    int.Parse(gridgiohang.DataKeys[row.DataItemIndex].Value.ToString());
                    if (giatri_moi_trong_textbox != giatri_bandau_trong_textbox)
                    {
                        Update(int.Parse(data.Values["IDgiohang"].ToString()),
                        giatri_moi_trong_textbox);
                    }
                }
            }
            HienThiGioHang();

            int Dem = gridgiohang.Rows.Count;
            if (Dem == 0)
            {
                lblTotal.Text = "0 VND";
                lblThongBao.Text = "Bạn chưa có sản phẩm nào trong giỏ hàng";
            }
        }
        //------------Thủ tục Update------------------
        private void Update(int id, int soluong)
        {
            GioHangBUS gioHangBUS = new GioHangBUS();
            GioHangDTO gioHang = new GioHangDTO();
            gioHang.SoLuong = soluong;
            gioHang.IdGioHang = id;
            gioHangBUS._gioHang = gioHang;
            try
            {
                gioHangBUS.Update();
            }
            catch
            {
                Response.Redirect("Trangloi.aspx");
            }

        }
        //--------------------Thủ tục Delete()------------------
        private void Delete(int id)
        {
            GioHangBUS gioHangBUS = new GioHangBUS();
            GioHangDTO gioHang = new GioHangDTO();
            gioHang.IdGioHang = id;
            gioHangBUS._gioHang = gioHang;
            try
            {
                gioHangBUS.Delete();
            }
            catch
            {
                Response.Redirect("Trangloi.aspx");
            }
        }
        protected void gridgiohang_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                _tongtien += Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ThanhTien"));
            }
            lblTotal.Text = string.Format(_tongtien.ToString()) + " VND";

        }
        protected void ImageButtonXacnhanthanhtoan_Click(object sender, ImageClickEventArgs e)
        {
            Response.Cookies["ReturnURL"].Value = "ThemDonHang.aspx";
            Response.Redirect("DangNhap.aspx");
        }
    }

}