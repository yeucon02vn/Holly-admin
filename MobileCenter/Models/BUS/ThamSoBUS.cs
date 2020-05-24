using MobileCenter.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MobileCenter.Models.BUS
{
    public class ThamSoBUS
    {
        public SqlDataSource KetQua { get; set; }

        public void Select()
        {
            ThamSoDAL selectSoLuongTruyCap = new ThamSoDAL();
            KetQua = selectSoLuongTruyCap.Select();
        }

        public void Update()
        {
            ThamSoDAL updateSoLuongTruyCap = new ThamSoDAL();
            updateSoLuongTruyCap.Update();
        }
    }
}