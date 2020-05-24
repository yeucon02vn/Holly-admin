using MobileCenter.Models.DTO;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace MobileCenter.Models.DAL
{
    public class GioHangDAL
    {
        public GioHangDTO _gioHang { get; set; }
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
            sqlData.InsertCommand = "GioHang_Insert";
            sqlData.InsertParameters.Add("CartGuid", _gioHang.CartGuid);
            sqlData.InsertParameters.Add("IdSanPham", _gioHang.IdSanPham.ToString());
            sqlData.InsertParameters.Add("SoLuong", _gioHang.SoLuong.ToString());
            sqlData.Insert();
        }

        public SqlDataSource Select()
        {
            SqlDataSource sqlData = Connect();
            sqlData.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.SelectCommand = "GioHang_Select";
            sqlData.SelectParameters.Add("CartGuid", _gioHang.CartGuid);
            return sqlData;
        }

        public void Update()
        {
            SqlDataSource sqlData = Connect();
            sqlData.UpdateCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.UpdateCommand = "GioHang_Update";
            sqlData.UpdateParameters.Add("SoLuong", _gioHang.SoLuong.ToString());
            sqlData.UpdateParameters.Add("IdGioHang", _gioHang.IdGioHang.ToString());
            sqlData.Update();
        }

        public void Delete()
        {
            SqlDataSource sqlData = Connect();
            sqlData.DeleteCommandType = SqlDataSourceCommandType.StoredProcedure;
            sqlData.DeleteCommand = "GioHang_Delete";
            sqlData.DeleteParameters.Add("IdGioHang", _gioHang.IdGioHang.ToString());
            sqlData.Delete();
        }
    }
}