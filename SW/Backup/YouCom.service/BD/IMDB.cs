using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Data.SqlClient;

namespace YouCom.Service.IMDB
{
    /// <summary>
    /// Summary description for IMDB
    /// </summary>
    public class IMDB
    {
        public IMDB()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static SqlConnection GetConnection()
        {
            try
            {
                if (ConfigurationManager.ConnectionStrings["LocalSqlServer"] != null)
                {
                    string strConnection = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
                    if (!string.IsNullOrEmpty(strConnection))
                    {
                        SqlConnection mySqlConnection = new SqlConnection(strConnection);
                        return mySqlConnection;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            throw new Exception("No hay string de conexion");
        }

        public static SqlConnection GetConnectionKTF()
        {
            try
            {
                if (ConfigurationManager.ConnectionStrings["LocalSqlServerKTF"] != null)
                {
                    string strConnection = ConfigurationManager.ConnectionStrings["LocalSqlServerKTF"].ConnectionString;
                    if (!string.IsNullOrEmpty(strConnection))
                    {
                        SqlConnection mySqlConnection = new SqlConnection(strConnection);
                        return mySqlConnection;
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
            throw new Exception("No hay string de conexion");
        }
    }
}
