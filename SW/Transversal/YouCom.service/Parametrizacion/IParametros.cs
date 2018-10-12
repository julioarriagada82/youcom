using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;

namespace YouCom.Service.Parametrizacion
{
    public interface IParametros
    {
          string getDescripcionParametros(string codigo, string concepto);
          Boolean ConsultaDescripcionParametros(string pConcepto, string pCodigo, ref XmlDocument pdomResponse);
          bool GetConsultaDescripcion(string pConcepto, string pCodigo, DataTable pobjDataTable);
          void ArmoXMLRespuesta(DataTable pobjDataTable, XmlDocument pdomResponse);
          String getPageName(bool full);
    }
}
