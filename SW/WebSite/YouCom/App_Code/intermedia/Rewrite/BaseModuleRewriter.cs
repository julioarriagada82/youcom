using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;



public abstract class BaseModuleRewriter : IHttpModule
{
        public virtual void Init(HttpApplication app)
        {
            app.AuthorizeRequest += new
            EventHandler(this.BaseModuleRewriter_AuthorizeRequest);
        }
        public virtual void Dispose() 
        {
        }
        protected virtual void BaseModuleRewriter_AuthorizeRequest(object sender, EventArgs e)
        {
                HttpApplication app = (HttpApplication) sender;
             Rewrite(app.Request.Path, app);
                }
                protected abstract void Rewrite(string requestedPath,
                HttpApplication app);
 }

