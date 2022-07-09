using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MyPhamOBJ;

namespace MyPhamDAO
{
    public partial class UserDAO
    {
        DataHelper dh = new DataHelper();
        public UserOBJ GetUser(string UserId, string pas)
        {
            string sql = "select*from Users where (MaNV ='" + UserId + "') and (Pas='" + pas + "')";
            DataTable dt = dh.GetDataTable(sql);
            if (dt.Rows.Count <= 0)
                return null;
            else
            {
                UserOBJ us = new UserOBJ(dt.Rows[0].ToString(), dt.Rows[0][1].ToString(),
                    dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString());
                return us;
            }

        }
    }
}
