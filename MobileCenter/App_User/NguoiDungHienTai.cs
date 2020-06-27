using MobileCenter.Models.DTO;

namespace MobileCenter.App_User
{
    public class NguoiDungHienTai : System.Web.UI.Page
    {
        internal const string KEY_CURRENTUSER = "Current Logged In User";
        public NguoiDungDTO _NguoiDungHienTai
        {
            get
            {
                try
                {
                    return (NguoiDungDTO)(Session[KEY_CURRENTUSER]);
                }
                catch
                {
                    return (null);
                }
            }
            set
            {
                if (value == null)
                {
                    Session.Remove(KEY_CURRENTUSER);
                }
                else
                {
                    Session[KEY_CURRENTUSER] = value;
                }
            }
        }
    }
}