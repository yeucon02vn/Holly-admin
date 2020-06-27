using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MobileCenter.Models.BUS;
using MobileCenter.Models.DTO;
using System.Collections.Generic;

namespace MobileCenter.Admins.View
{
    public partial class SuaSanPham : System.Web.UI.Page
    {
        private const string IdHinh = " ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTenSanPham.Focus();
                HienDanhMucSanPham();
                HienSanPham();
            }
        }
        private void HienDanhMucSanPham()
        {
            DanhMucSanPhamBUS xuLyDanhMucSanPham = new DanhMucSanPhamBUS();
            try
            {
                xuLyDanhMucSanPham.Select();
            }
            catch
            {
                Response.Redirect("../Trangloi.aspx");
            }
            dropDanhMucSanPham.DataTextField = "TenDanhMucSanPham";
            dropDanhMucSanPham.DataValueField = "IdDanhMucSanPham";
            dropDanhMucSanPham.DataSource = xuLyDanhMucSanPham.KetQua;
            dropDanhMucSanPham.DataBind();
        }
        //----------Hiện sản phẩm theo id sản phẩm--------------
        private void HienSanPham()
        {
            SanPhamDTO Spham = new SanPhamDTO();
            Spham.IdSanPham = int.Parse(Request.QueryString[("IdSanPham")]);
            SanPhamBUS laySanPhamByID = new SanPhamBUS();
            laySanPhamByID._sanPham = Spham;
            try
            {
                laySanPhamByID.SelectById();
                txtTenSanPham.Text = laySanPhamByID._sanPham.TenSanPham;
                CKEditorControlMoTa.Text = laySanPhamByID._sanPham.MoTaSanPham;
                textGia.Text = laySanPhamByID._sanPham.GiaSanPham.ToString();
                imgHinhSanPham.ImageUrl = "~/View/HienThiHinhSanPham.ashx?IdHinhSanPham=" +
                laySanPhamByID._sanPham.IdHinhSanPham.ToString();
                dropDanhMucSanPham.SelectedIndex =
                dropDanhMucSanPham.Items.IndexOf(dropDanhMucSanPham.Items.FindByText(
                laySanPhamByID._sanPham.DanhMucSanPham.TenDanhMucSanPham));
                LuuTamIdHinhSanPham = laySanPhamByID._sanPham.IdHinhSanPham;
            }
            catch
            {
                Response.Redirect("../Trangloi.aspx");
            }
            
        }
        //---------------Cập nhật thay đổi sản phẩm--------------------
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                SanPhamDTO Spham = new SanPhamDTO();
                Spham.IdSanPham = Convert.ToInt32(Request.QueryString["IdSanPham"]);
                Spham.TenSanPham = txtTenSanPham.Text;
                Spham.MoTaSanPham = CKEditorControlMoTa.Text;
                Spham.GiaSanPham = Convert.ToInt32(textGia.Text);
                Spham.IdDanhMucSanPham = int.Parse(
                dropDanhMucSanPham.SelectedItem.Value);
                Spham.IdHinhSanPham = LuuTamIdHinhSanPham;
                if (fileuploadHinhSanPham.HasFile)
                {
                    Spham.HinhSanPham.LinkSanPham = fileuploadHinhSanPham.FileBytes;
                }
                else
                {
                    SanPhamBUS xuLyLayHinh = new SanPhamBUS();
                    xuLyLayHinh._sanPham = Spham;
                    try
                    {
                        xuLyLayHinh.SelectHinhSanPhamById();
                    }
                    catch
                    {
                        Response.Redirect("../Trangloi.aspx");
                    }
                    SqlDataSource src = new SqlDataSource();
                    src = xuLyLayHinh.KetQua;
                    DataView view = (DataView)src.Select(DataSourceSelectArguments.Empty);
                    Spham.HinhSanPham.LinkSanPham = (byte[])view[0]["LinkSanPham"];
                }
                SanPhamBUS capNhatSanPham = new SanPhamBUS();
                capNhatSanPham._sanPham = Spham;
                try
                {
                    capNhatSanPham.Update();
                }
                catch
                {
                    Response.Redirect("../Trangloi.aspx");
                }
                Response.Redirect("SanPham.aspx");
            }
        }
        //---------sự kiện nút bỏ qua----------------------
        protected void btnBoQua_Click(object sender, EventArgs e)
        {
            Response.Redirect("SanPham.aspx");
        }
        // Lưu hình để lấy lại hình sản phẩm trong trường hợp hình không thay đổi
        private int LuuTamIdHinhSanPham
        {
            get { return (int)ViewState[IdHinh]; }
            set { ViewState[IdHinh] = value; }
        }
    }
}