using MobileCenter.Models.BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MobileCenter.View
{
    public partial class GioiThieuSanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HienThiSanPham();
            }
            this.Form.DefaultButton = ImageButtonTim.UniqueID; 
            this.textSearch.Focus(); 
        }

        private void HienThiSanPham()
        {
            SanPhamBUS sanPhamBUS = new SanPhamBUS();
            try
            {
                sanPhamBUS.SelectAll();
            }
            catch
            {
                Response.Redirect("Trangloi.aspx");
            }
            dtlSanPham.DataSource = sanPhamBUS.KetQua; // dtlSanPham là ID của DataList
            dtlSanPham.DataBind();

            //Phân trang sản phẩm
            DataView dataview = (DataView)sanPhamBUS.KetQua.Select(DataSourceSelectArguments.Empty);
            CollectionPagerPhanTrang.PageSize = 12; ////số sản phẩm hiển thị trên một trang
            CollectionPagerPhanTrang.DataSource = dataview;
            //dtlSanPham là tên datalist
            CollectionPagerPhanTrang.BindToControl = dtlSanPham;
            dtlSanPham.DataSource = CollectionPagerPhanTrang.DataSourcePaged;

        }
        private void Timsanpham(string tieuchuantim)
        {
            SanPhamBUS sanPhamBUS = new SanPhamBUS();
            try
            {
                sanPhamBUS.Search(tieuchuantim);
            }
            catch
            {
                Response.Redirect("Trangloi.aspx");
            }
            dtlSanPham.DataSource = sanPhamBUS.KetQua;// dtlSanPham là ID của Datalist
            dtlSanPham.DataBind();
            if (dtlSanPham.Items.Count != 0)
                lblketqua.Text = "Các sản phẩm bạn cần tìm:";
            //lblketqua là ID của Label chứa dòng thông tin để thông báo kết quả tìm kiếm
            else
            {
                lblketqua.Text = "Không tìm thấy sản phẩm";
            }
        }
        protected void ImageButtonTim_Click(object sender, ImageClickEventArgs e)
        {
            Timsanpham(textSearch.Text);
            // textSearch là ID TextBox dùng để nhập nội dung cần tìm
            //commandSearch là ID của nút lệnh Tìm kiếm
        }
    }
}