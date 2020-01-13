using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public class conn
    {
        private static string _chaineConnection;

        public conn(string chaine)
        {
            _chaineConnection = chaine;
        }

        public static SqlConnection cn = new SqlConnection(_chaineConnection);
        private void conns()
        {
            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
        }
        //// return datatable
        public  DataTable select(string query )
        {
            DataTable dt = new DataTable();
            SqlDataReader dr;
            SqlCommand cmd;
            dt.Clear();
            this.conns();
            cmd = new SqlCommand(query, cn);
            dr = d.cmdc.ExecuteReader();
            dt.Load(dr);
            return dt;
        }
        //ajouter - supprimer - modifier 
        public int ajouter(string query)
        {
            this.conns();
            SqlCommand cmd = new SqlCommand(query, cn);
            int y = cmd.ExecuteNonQuery();
            return y;   
        }
        //chercher 
        public int chercher(DataTable dt,string code,int chanpIndex)
        {
            int y = -1;
            for (int i = 0; i < d.dtc.Rows.Count; i++)
            {
                if (Convert.ToString(d.dtc.Rows[i][chanpIndex]) == code.ToString())
                {
                    return i;
                }
            }
            return y;
        }
        
       

       
      
    }
}