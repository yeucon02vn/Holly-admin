using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileCenter.Models.DTO;
using MobileCenter.Models.DAL;
using System.Web.UI.WebControls;

namespace MobileCenter.Models.BUS
{
    public class SanPhamBUS
    {
        public SanPhamDTO _sanPham { get; set; }
        public SqlDataSource _ketqua { get; set; }
        public void Insert()
        {
            SanPhamDAL spDAL = new SanPhamDAL();
            spDAL._sanPham = this._sanPham;
            spDAL.Insert();
        }
        public void SelectAll()
        {
            SanPhamDAL spDAL = new SanPhamDAL();
            _ketqua = spDAL.SelectAll();
        }
        public void SelectById()
        {
            SanPhamDAL spDAL = new SanPhamDAL();
            spDAL._sanPham = this._sanPham;
            _ketqua = spDAL.SelectById();
            GridView gv = new GridView();
            gv.DataSource = _ketqua;
            gv.DataBind();
            _sanPham.TenSanPham = gv.Rows[0].Cells[1].Text.ToString();
            _sanPham.MoTaSanPham = gv.Rows[0].Cells[4].Text.ToString();
            _sanPham.GiaSanPham = Convert.ToInt32(gv.Rows[0].Cells[5].Text.ToString());
            _sanPham.IdSanPham = int.Parse(gv.Rows[0].Cells[0].Text.ToString());
            _sanPham.IdDanhMucSanPham = int.Parse(gv.Rows[0].Cells[2].Text.ToString());
            _sanPham.IdHinhSanPham = int.Parse(gv.Rows[0].Cells[3].Text.ToString());
        }
        public void SelectByDanhMuc()
        {
            SanPhamDAL spDAL = new SanPhamDAL();
            _ketqua = spDAL.SelectByDanhMuc();
        }
    }
}