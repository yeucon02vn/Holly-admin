using MobileCenter.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MobileCenter.Models.DAL
{
    public class ThamSoDAL
    {
        public ThamSo _thamSo { get; set; }

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
            sqlData.SelectCommand = "NguoiTruyCap_Select";
            return sqlData;
        }

        public void Update()
        {
            SqlDataSource sqlData = Connect();
            sqlData.UpdateCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.UpdateCommand = "NguoiTruyCap_Update";
            sqlData.Update();
        }
    }
}