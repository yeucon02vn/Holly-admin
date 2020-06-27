<%@ WebHandler Language = "C#" Class="MobileCenter.View.HienThiHinhSanPham" %>

using System.Web;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MobileCenter.Models.DTO;
using MobileCenter.Models.BUS;

namespace MobileCenter.View
{
    /// <summary>
    /// Summary description for HienThiHinhSanPham
    /// </summary>
    public class HienThiHinhSanPham : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            SanPhamDTO sanPham = new SanPhamDTO();
            sanPham.IdHinhSanPham = int.Parse(context.Request.QueryString["IdHinhSanPham"]);
            SanPhamBUS sanPhamBus = new SanPhamBUS();
            sanPhamBus._sanPham = sanPham;
            sanPhamBus.SelectHinhSanPhamById();
            SqlDataSource src = new SqlDataSource();
            src = sanPhamBus.KetQua;
            DataView view = (DataView)src.Select(DataSourceSelectArguments.Empty);
            context.Response.BinaryWrite((byte[])view[0]["LinkSanPham"]);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}