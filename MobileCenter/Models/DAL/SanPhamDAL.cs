using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MobileCenter.Models.DTO;
using System.Web.UI.WebControls;

namespace MobileCenter.Models.DAL
{
    public class SanPhamDAL
    {
        public SanPhamDTO _sanPham { get; set; }
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
            SqlConnection conect = new SqlConnection(sqlData.ConnectionString);
            conect.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conect;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "SanPham_Insert";
            com.Parameters.Add("@IdDanhMucSanPham", SqlDbType.Int).Value = _sanPham.IdDanhMucSanPham;
            com.Parameters.Add("@IdHinhSanPham", SqlDbType.Int).Value = _sanPham.IdHinhSanPham;
            com.Parameters.Add("@TenSanPham", SqlDbType.NVarChar).Value = _sanPham.TenSanPham;         
            com.Parameters.Add("@MoTaSanPham", SqlDbType.NVarChar).Value = _sanPham.MoTaSanPham;
            com.Parameters.Add("@GiaSanPham", SqlDbType.Int).Value = _sanPham.GiaSanPham;
            com.ExecuteNonQuery();
        }
        public SqlDataSource SelectAll()
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "SanPham_Select";
            return sqlData;
        }
        public SqlDataSource SelectById()
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "SanPhamByID_Select";
            sqlData.SelectParameters.Add("IdSanPham ", _sanPham.IdSanPham.ToString());
            return sqlData;
        }
        public SqlDataSource SelectByDanhMuc()
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "SanPhamTheoDanhMuc_Select";
            sqlData.SelectParameters.Add("IdDanhMucSanPham", _sanPham.IdDanhMucSanPham.ToString());
            return sqlData;
        }
    }
}