using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace Intermedia.IMSystem.Security
{
    /// <summary>
    /// Summary description for IMModule
    /// </summary>
    public class IMModule
    {
        private decimal id;
        private string codigo;
        private string nombre;
        private string padre;
        private int indentacion;
        private ArrayList childrens = new ArrayList();

        public IMModule()
        {
        }

        public IMModule(string code)
        {
            this.codigo = code;
        }

        public void AddChildren(IMModule module)
        {
            this.childrens.Add(module);
        }

        public ArrayList GetItems()
        {
            return this.childrens;
        }

        public bool HasChilds()
        {
            if (this.childrens.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int CountChilds()
        {
            return this.childrens.Count;
        }

        public decimal myId
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string myCodigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }

        public string myNombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public string myPadre
        {
            get
            {
                return padre;
            }
            set
            {
                padre = value;
            }
        }

        public int myIndentacion
        {
            get
            {
                return indentacion;
            }
            set
            {
                indentacion = value;
            }
        }

        public ArrayList myChildrens
        {
            get
            {
                return childrens;
            }
            set
            {
                childrens = value;
            }
        }

    }
}