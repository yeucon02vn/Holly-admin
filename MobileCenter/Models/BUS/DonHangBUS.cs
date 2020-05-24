using MobileCenter.Models.DAL;
using MobileCenter.Models.DTO;
using System;
using System.Web.UI.WebControls;

namespace MobileCenter.Models.BUS
{
    public class DonHangBUS
    {
        public DonHangDTO _donhang { get; set; }

        public NguoiDungDTO _nguoiDung { get; set; }

        public SqlDataSource KetQua { get; set; }

        public void Insert()
        {
            DonHangDAL insertDonHang = new DonHangDAL();
            ChiTietDonHangDAL insertChiTietDonHang = new ChiTietDonHangDAL();
            insertDonHang._donHang = this._donhang;
            GridView g = new GridView();
            insertDonHang.Insert();
            g.DataSource = insertDonHang.SelectTop1();
            g.DataBind();
            _donhang.IdDonHang = int.Parse(g.Rows[0].Cells[0].Text);
            _donhang.ChiTietDonHang = insertChiTietDonHang._chitietdonhang;
            for (int i = 0; i < _donhang.ChiTietDonHang.SanPham.Length; i++)
            {
                insertChiTietDonHang._chitietdonhang.IdDonHang = _donhang.IdDonHang;
                insertChiTietDonHang._chitietdonhang.IdSanPham =
                _donhang.ChiTietDonHang.SanPham[i].IdSanPham;
                insertChiTietDonHang._chitietdonhang.SoLuongSanPham =
                _donhang.ChiTietDonHang.SanPham[i].SoLuong;
                insertChiTietDonHang.Insert();
            }
        }

        public void Update()
        {
            DonHangDAL updateDonHang = new DonHangDAL();
            updateDonHang._donHang = this._donhang;
            updateDonHang.Update();
        }

        public void SelectByIdNguoiDung()
        {
            DonHangDAL selectDonHangByIdNguoiDung = new DonHangDAL();
            selectDonHangByIdNguoiDung._nguoiDung = this._nguoiDung;
            KetQua = selectDonHangByIdNguoiDung.SelectByIdNguoiDung();
        }

        public void SelectById()
        {
            DonHangDAL selectDonHangById = new DonHangDAL();
            selectDonHangById._donHang = this._donhang;
            KetQua = selectDonHangById.SelectById();
            GridView grid = new GridView();
            grid.DataSource = KetQua;
            grid.DataBind();
            if (grid.Rows.Count > 0)
            {
                if (grid.Rows[0].Cells[1].Text.ToString() != "&nbsp;")
                //grid.Rows[0].Cells[1]phu thuoc cau truy van, lay cot ngay xu ly don hang
                {
                    _donhang.NgayXuLyDonHang =
                    Convert.ToDateTime(grid.Rows[0].Cells[1].Text.ToString());
                }
                _donhang.TrackingNumber =
                grid.Rows[0].Cells[3].Text.ToString().Replace("&nbsp;", "");
                _donhang.IdTinhTrangDonHang = int.Parse(grid.Rows[0].Cells[2].Text.ToString());

            }
        }

        public void SelectAll()
        {
            DonHangDAL selectAllDonHang = new DonHangDAL();
            KetQua = selectAllDonHang.SelectAll();
        }
    }
}