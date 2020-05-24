using MobileCenter.Models.DAL;
using MobileCenter.Models.DTO;
using System.Web.UI.WebControls;

namespace MobileCenter.Models.BUS
{
    public class GioHangBUS
    {
        public GioHangDTO _gioHang { get; set; }
        public SqlDataSource KetQua { get; set; }

        public void Update()
        {
            GioHangDAL updateGioHang = new GioHangDAL();
            updateGioHang._gioHang = this._gioHang;
            updateGioHang.Update();
        }

        public void Select()
        {
            GioHangDAL selectGioHang = new GioHangDAL();
            selectGioHang._gioHang = _gioHang;
            KetQua = selectGioHang.Select();
        }

        public void Insert()
        {
            GioHangDAL insertGioHang = new GioHangDAL();
            insertGioHang._gioHang = this._gioHang;
            insertGioHang.Insert();
        }

        public void Delete()
        {
            GioHangDAL deleteGioHang = new GioHangDAL();
            deleteGioHang._gioHang = this._gioHang;
            deleteGioHang.Delete();
        }
    }
}