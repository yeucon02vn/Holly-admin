using MobileCenter.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MobileCenter.Models.DAL
{
    public class DanhMucSanPhamDAL
    {
        public DanhMucSanPhamDTO _danhMucSanPham { get; set; }

        public SqlDataSource Connect()
        {
            SqlDataSource sqlData = new SqlDataSource();
            KetNoi chuoiketnoi = new KetNoi();
            sqlData.ConnectionString = chuoiketnoi.ConnectionString();
            return sqlData;
        }

        public SqlDataSource Select()
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "DanhMucSanPham_Select";
            return sqlData;
        }

        public SqlDataSource SelectByMaster()
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "DanhMucSanPhamMaster_Select";
            return sqlData;
        }
    }
}