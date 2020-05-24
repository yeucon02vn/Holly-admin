using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileCenter.Models.DTO;
using System.Web.UI.WebControls;

namespace MobileCenter.Models.DAL
{
    public class DonHangDAL
    {
        public DonHangDTO _donHang { get; set; }
        public NguoiDungDTO _nguoiDung { get; set; }
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
            sqlData.InsertCommand = "DonHang_Insert";
            sqlData.InsertParameters.Add("IdNguoiDung", _donHang.IdNguoiDung.ToString());
            sqlData.InsertParameters.Add("MaGiaoDich", _donHang.MaGiaoDich);
            sqlData.Insert();
        }
        public SqlDataSource SelectTop1()
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "DonHang_Top1_Select ";
            return sqlData;
        }

        public SqlDataSource SelectAll()
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "DonHangAll_Select";
            return sqlData;
        }

        public SqlDataSource SelectById()
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "DonHangByID_Select";
            sqlData.SelectParameters.Add("IdDonHang", _donHang.IdDonHang.ToString());
            return sqlData;
        }
        public SqlDataSource SelectByIdNguoiDung()
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "DonHang_Select";
            sqlData.SelectParameters.Add("IdNguoiDung", _nguoiDung.IdNguoiDung.ToString());
            return sqlData;
        }

        public void Update()
        {
            SqlDataSource sqlData = Connect();
            sqlData.UpdateCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.UpdateCommand = "DonHang_Update";
            sqlData.UpdateParameters.Add("IdDonHang", _donHang.IdDonHang.ToString());
            sqlData.UpdateParameters.Add("IdTinhTrangDonHang", _donHang.IdTinhTrangDonHang.ToString());
            sqlData.UpdateParameters.Add("NgayXuLyDonHang", _donHang.NgayXuLyDonHang.ToShortDateString());
            sqlData.UpdateParameters.Add("TrackingNumber", _donHang.TrackingNumber);
            sqlData.Update();
        }
    }
}