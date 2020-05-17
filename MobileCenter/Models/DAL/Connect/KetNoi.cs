using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MobileCenter.Models.DAL
{
    public class KetNoi
    {
        public string ConnectionString()
        {
            return
            WebConfigurationManager.ConnectionStrings["dataMobileCenter"].ConnectionString;
        }
    }
}