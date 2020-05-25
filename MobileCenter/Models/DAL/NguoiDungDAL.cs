using MobileCenter.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MobileCenter.Models.DAL
{
    public class NguoiDungDAL
    {
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
            sqlData.InsertCommand = "NguoiDung_Insert";
            sqlData.InsertParameters.Add("HoTen", _nguoiDung.HoTen);
            sqlData.InsertParameters.Add("TenDangNhap", _nguoiDung.TenDangNhap);
            sqlData.InsertParameters.Add("DiaChi", _nguoiDung.DiaChi);
            sqlData.InsertParameters.Add("SoDienThoai", _nguoiDung.SoDienThoai);
            sqlData.InsertParameters.Add("Email", _nguoiDung.Email);
            sqlData.InsertParameters.Add("IdKieuNguoiDung", _nguoiDung.IdKieuNguoiDung.ToString());
            sqlData.InsertParameters.Add("MatKhau", _nguoiDung.MatKhau);
            sqlData.Insert();

        }

        public SqlDataSource SelectByAdmin()
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "DangNhapAdmin_Select";
            sqlData.SelectParameters.Add("TenDangNhap", _nguoiDung.TenDangNhap);
            sqlData.SelectParameters.Add("MatKhau", _nguoiDung.MatKhau);
            return sqlData;
        }

        public SqlDataSource SelectByUser()
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "DangNhapNguoiDung_Select";
            sqlData.SelectParameters.Add("TenDangNhap", _nguoiDung.TenDangNhap);
            sqlData.SelectParameters.Add("MatKhau", _nguoiDung.MatKhau);
            return sqlData;
        }
    }
}