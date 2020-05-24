using MobileCenter.Models.DAL;
using MobileCenter.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MobileCenter.Models.BUS
{
    public class ChiTietDonHangBUS
    {
        public ChiTietDonHangDTO _chiTietDonHang { get; set; }
        public SqlDataSource KetQua { get; set; }
        public void Select()
        {
            ChiTietDonHangDAL selectChiTietDonHang = new ChiTietDonHangDAL();
            selectChiTietDonHang._chitietdonhang = this._chiTietDonHang;
            KetQua = selectChiTietDonHang.SelectById();
        }
    }
}