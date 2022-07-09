using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MyPhamDAO
{
    public class DataHelper
    {
        string stcon;
        SqlConnection con;
        public DataHelper()
        {
            stcon = ConfigurationManager.ConnectionStrings["strconnect"].ConnectionString;
            con = new SqlConnection(stcon);
        }

        public DataTable GetDataTable(string sql)
        {
            //if (con.State == ConnectionState.Closed)
            //    con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, stcon);
            
            da.Fill(dt);
            return dt;
        }
        public string MoKetNoi()
        {

            //if (con.State != ConnectionState.Open)
            //{
            //    con.Open();
            //}
            //return "";

            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        public void Close()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        public SqlDataReader StoreReaders(string tenStore, params object[] giatri)
        {
            SqlCommand cm;
            MoKetNoi();
            try
            {
                cm = new SqlCommand(tenStore, con);
                cm.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cm);
                for (int i = 1; i < cm.Parameters.Count; i++)
                {
                    cm.Parameters[i].Value = giatri[i - 1];
                }
                SqlDataReader dr = cm.ExecuteReader();
                return dr;
            }
            catch
            { return null; }
        }
        public string ExcuteNonQuery(string sql)
        {
            MoKetNoi();
            try
            {
                SqlCommand cm = new SqlCommand(sql, con);
                cm.ExecuteNonQuery();
                return "";
            }
            catch (SqlException e)
            {
                return e.Message;
            }
        }

        public SqlDataReader ExcuteReader(string sqlSelect)
        {
            string st = MoKetNoi();
            if (st != "")
                throw new Exception(st);
            SqlCommand cm = new SqlCommand(sqlSelect, con);
            return cm.ExecuteReader();
        }
    }
}
