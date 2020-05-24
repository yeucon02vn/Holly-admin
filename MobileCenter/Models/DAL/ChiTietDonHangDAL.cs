using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileCenter.Models.DTO;
using System.Web.UI.WebControls;

namespace MobileCenter.Models.DAL
{
    public class ChiTietDonHangDAL
    {
        public ChiTietDonHangDTO _chitietdonhang { get; set; }

        public SqlDataSource Connect()
        {
            SqlDataSource sqlData = new SqlDataSource();
            KetNoi chuoiketnoi = new KetNoi();
            sqlData.ConnectionString = chuoiketnoi.ConnectionString();
            return sqlData;
        }
        public void Insert()
        {
            SqlDataSource sqlData = Connect();
            sqlData.InsertCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.InsertCommand = "ChiTietDonHang_Insert";
            sqlData.InsertParameters.Add("IdDonHang", _chitietdonhang.IdDonHang.ToString());
            sqlData.InsertParameters.Add("IdSanPham", _chitietdonhang.IdSanPham.ToString());
            sqlData.InsertParameters.Add("SoLuongSanPham", _chitietdonhang.SoLuongSanPham.ToString());
            sqlData.Insert();
        }
        public SqlDataSource SelectById()
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "ChiTietDonHang_Select";
            sqlData.SelectParameters.Add("IdDonHang", _chitietdonhang.IdDonHang.ToString());
            return sqlData;
        }
    }
}