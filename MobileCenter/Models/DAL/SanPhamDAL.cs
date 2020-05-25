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
            com.Parameters.Add("@LinkSanPham", SqlDbType.VarBinary).Value = _sanPham.HinhSanPham.LinkSanPham;
            com.Parameters.Add("@IdDanhMucSanPham", SqlDbType.Int).Value = _sanPham.IdDanhMucSanPham;
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

        public SqlDataSource SelectHinhSanPham()
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "HinhSanpham_Select";
            sqlData.SelectParameters.Add("IdHinhSanPham", _sanPham.IdHinhSanPham.ToString());
            return sqlData;
        }

        public SqlDataSource SelectTop10()
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "SanPham10_Select";
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

        public void Update()
        {
            SqlDataSource sqlData = Connect();
            SqlConnection conect = new SqlConnection(sqlData.ConnectionString);
            conect.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = conect;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = "Sanpham_UpDate";
            com.Parameters.Add("@IdDanhMucSanPham", SqlDbType.Int).Value =
            _sanPham.IdDanhMucSanPham;
            com.Parameters.Add("@TenSanPham", SqlDbType.NVarChar).Value =
            _sanPham.TenSanPham;
            com.Parameters.Add("@IdHinhSanPham", SqlDbType.Int).Value =
            _sanPham.IdHinhSanPham;
            com.Parameters.Add("@LinkSanPham", SqlDbType.VarBinary).Value =
            _sanPham.HinhSanPham.LinkSanPham;
            com.Parameters.Add("@MoTaSanPham", SqlDbType.NText).Value =
            _sanPham.MoTaSanPham;
            com.Parameters.Add("@GiaSanPham", SqlDbType.Int).Value =
            _sanPham.GiaSanPham;
            com.Parameters.Add("@IdSanPham ", SqlDbType.Int).Value =
            _sanPham.IdHinhSanPham;
            com.ExecuteNonQuery();
        }

        public SqlDataSource Search(string Tieuchuan)
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "SanPham_SelectSearch";
            sqlData.SelectParameters.Add("tieuchuantim", Tieuchuan);
            return sqlData;
        }
    }
}