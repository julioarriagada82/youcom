using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Seguridad
{
    public class FuncionDTO : MantenedoresBase
    {
        private string _enviaCorreo;
        public string EnviaCorreo
        {
            get { return _enviaCorreo; }
            set { _enviaCorreo = value; }
        }
        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        private string _funcionalidadNegocio;
        public string FuncionalidadNegocio
        {
            get { return _funcionalidadNegocio; }
            set { _funcionalidadNegocio = value; }
        }
        private string _funcionCod;
        public string FuncionCod
        {
            get { return _funcionCod; }
            set { _funcionCod = value; }
        }
        private string _funcionNombre;
        public string FuncionNombre
        {
            get { return _funcionNombre; }
            set { _funcionNombre = value; }
        }
        private string _funcionTipoCod;
        public string FuncionTipoCod
        {
            get { return _funcionTipoCod; }
            set { _funcionTipoCod = value; }
        }
        private string _funcionGrupoCod;
        public string FuncionGrupoCod
        {
            get { return _funcionGrupoCod; }
            set { _funcionGrupoCod = value; }
        }
        private string _rutUsuario;
        public string RutUsuario
        {
            get { return _rutUsuario; }
            set { _rutUsuario = value; }
        }

        private string _grupoCod;
        public string GrupoCod
        {
            get { return _grupoCod; }
            set { _grupoCod = value; }
        }
    }

}
