

using MobileCenter.Models.DAL;
using System.Web.UI.WebControls;

namespace MobileCenter.Models.BUS
{
    public class DanhMucSanPhamBUS
    {
        public SqlDataSource KetQua { get; set; }

        public void Select()
        {
            DanhMucSanPhamDAL selectDanhMuc = new DanhMucSanPhamDAL();
            KetQua = selectDanhMuc.Select();
        }

        public void SelectByMaster()
        {
            DanhMucSanPhamDAL selectDanhMucByMaster = new DanhMucSanPhamDAL();
            KetQua = selectDanhMucByMaster.SelectByMaster();
        }
    }
}