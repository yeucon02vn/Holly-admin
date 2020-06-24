using MobileCenter.Models.BUS;
using MobileCenter.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileCenter.Admins.View
{
    public partial class ThemSanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTenSanPham.Focus(); // txtTenSanPham là ID của TextBox
                HienThiDanhMucSanPham();
            }
        }

        private void HienThiDanhMucSanPham()
        {
            DanhMucSanPhamBUS selectDanhMuc = new DanhMucSanPhamBUS();
            try
            {
                selectDanhMuc.Select();
            }
            catch
            {
                Response.Redirect("../Trangloi.aspx");
            }
            dropDanhMucSanPham.DataTextField = "TenDanhMucSanPham";
            // dropDanhMucSanPham là ID của điều khiển DropDownList
            dropDanhMucSanPham.DataValueField = "IdDanhMucSanPham";
            dropDanhMucSanPham.DataSource = selectDanhMuc.KetQua;
            dropDanhMucSanPham.DataBind();
        }

        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                SanPhamBUS insertSanPham = new SanPhamBUS();
                SanPhamDTO sanPham = new SanPhamDTO();

                sanPham.IdDanhMucSanPham = int.Parse(dropDanhMucSanPham.SelectedItem.Value);
                sanPham.TenSanPham = txtTenSanPham.Text; // txtTenSanPham là ID của TextBox
                sanPham.MoTaSanPham = CKEditorControlMoTa.Text;//txtTenSanPham là ID của TextBox      
                sanPham.HinhSanPham.LinkSanPham = fileuploadHinhSanPham.FileBytes;
                // fileuploadHinhSanPham là ID của điều khiển FileUpLoad
                sanPham.GiaSanPham = int.Parse(txtGia.Text); // txtGia là ID của TextBox
                insertSanPham._sanPham = sanPham;
                try
                {
                    insertSanPham.Insert();
                }
                catch
                {
                    Response.Redirect("../Trangloi.aspx");
                }
                // tắt khúc này vì chưa có trang SanPham.aspx nên khi add thành công thì nó chuyển qua trang SanPham sẽ lỗi
                //Response.Redirect("SanPham.aspx");
            }
        }
        protected void BtnBoQua_Click(object sender, EventArgs e)
        {
            Response.Redirect("SanPham.aspx");
        }
    }
}