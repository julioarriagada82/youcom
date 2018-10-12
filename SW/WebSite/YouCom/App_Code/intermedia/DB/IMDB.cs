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

namespace cl.intermedia.classes.global
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
                SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
                return mySqlConnection;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }
    }
}
