using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Web;
using System.Collections.Specialized;

namespace YouCom.Service.Configuracion
{
    public class Config
    {
        public static string GetPropiedad(string pvarPropiedad)
        {
            AppSettingsReader appSettings = null;

            try
            {

                appSettings = new AppSettingsReader();
                return (string)appSettings.GetValue(pvarPropiedad, typeof(string));
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
