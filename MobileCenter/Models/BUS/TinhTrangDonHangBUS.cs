using MobileCenter.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MobileCenter.Models.BUS
{
    public class TinhTrangDonHangBUS
    {
        public SqlDataSource KetQua { get; set; }

        public void Select()
        {
            TinhTrangDonHangDAL selectTinhTrang = new TinhTrangDonHangDAL();
            KetQua = selectTinhTrang.Select();
        }
    }
}