using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace cl.intermedia.classes.global
{
    /// <summary>
    /// Summary description for IMDateTime
    /// </summary>
    public class IMDateTime
    {
        public IMDateTime()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static double DateDiff(string howtocompare, System.DateTime startDate, System.DateTime endDate)
        {
            double diff = 0;
            try
            {
                System.TimeSpan TS = new
                System.TimeSpan(startDate.Ticks - endDate.Ticks);
                switch (howtocompare.ToLower())
                {
                    case "m":
                        diff = Convert.ToDouble(TS.TotalMinutes);
                        break;
                    case "s":
                        diff = Convert.ToDouble(TS.TotalSeconds);
                        break;
                    case "t":
                        diff = Convert.ToDouble(TS.Ticks);
                        break;
                    case "mm":
                        diff = Convert.ToDouble(TS.TotalMilliseconds);
                        break;
                    case "yyyy":
                        diff = Convert.ToDouble(TS.TotalDays / 365);
                        break;
                    case "q":
                        diff = Convert.ToDouble((TS.TotalDays / 365) / 4);
                        break;
                    default:
                        //d
                        diff = Convert.ToDouble(TS.TotalDays);
                        break;
                }
            }
            catch
            {
                diff = -1;
            }
            return diff;
        }


        public static bool IsDate(string date)
        {
            try
            {
                Regex myRegex = new Regex("(0[0-9]|[1-2][0-9]|30|31)/(0[1-9]|1[0-2])/[1-9][0-9][0-9][0-9]");
                if (myRegex.IsMatch(date))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool _IsDate(string sdate)
        {
            DateTime dt;
            bool isDate = true;
            try
            {
                dt = DateTime.Parse(sdate);
            }
            catch
            {
                isDate = false;
            }
            return isDate;
        }
    }
}