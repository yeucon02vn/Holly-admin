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
        public SqlDataSource KetQua { get; set; }

        public void Insert()
        {
            SanPhamDAL insertSanPham = new SanPhamDAL();
            insertSanPham._sanPham = this._sanPham;
            insertSanPham.Insert();
        }

        public void Update()
        {
            SanPhamDAL updateSanPham = new SanPhamDAL();
            updateSanPham._sanPham = this._sanPham;
            updateSanPham.Update();
        }

        public void SelectAll()
        {
            SanPhamDAL spDAL = new SanPhamDAL();
            KetQua = spDAL.SelectAll();
        }
        public void SelectById()
        {
            SanPhamDAL spDAL = new SanPhamDAL();
            spDAL._sanPham = this._sanPham;
            KetQua = spDAL.SelectById();
            GridView gv = new GridView();
            gv.DataSource = KetQua;
            gv.DataBind();
            _sanPham.TenSanPham = gv.Rows[0].Cells[1].Text.ToString();
            _sanPham.MoTaSanPham = gv.Rows[0].Cells[4].Text.ToString();
            _sanPham.GiaSanPham = Convert.ToInt32(gv.Rows[0].Cells[5].Text.ToString());
            _sanPham.IdSanPham = int.Parse(gv.Rows[0].Cells[0].Text.ToString());
            _sanPham.DanhMucSanPham.TenDanhMucSanPham = gv.Rows[0].Cells[2].Text.ToString();
            _sanPham.IdHinhSanPham = int.Parse(gv.Rows[0].Cells[3].Text.ToString());
        }
        public void SelectByDanhMuc()
        {
            SanPhamDAL spDAL = new SanPhamDAL();
            KetQua = spDAL.SelectByDanhMuc();
        }

        public void SelectTop10()
        {
            SanPhamDAL selectTop10SanPham = new SanPhamDAL();
            KetQua = selectTop10SanPham.SelectTop10();
        }

        public void SelectHinhSanPhamById()
        {
            SanPhamDAL selectHinhSanPhamById = new SanPhamDAL();
            selectHinhSanPhamById._sanPham = this._sanPham;
            KetQua = selectHinhSanPhamById.SelectHinhSanPham();
        }

        public void Search(string keyword)
        {
            SanPhamDAL searchSanPham = new SanPhamDAL();
            KetQua = searchSanPham.Search(keyword);
        }
    }
}