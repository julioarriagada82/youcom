using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class ParametrosDTO
    {
        private decimal _idParametro;

        public decimal IdParametro
        {
            get { return _idParametro; }
            set { _idParametro = value; }
        }
        private string _concepto;

        public string Concepto
        {
            get { return _concepto; }
            set { _concepto = value; }
        }
        private string _codigo;

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        private string _descricion;

        public string Descricion
        {
            get { return _descricion; }
            set { _descricion = value; }
        }
        private string _descripcionCorta;

        public string DescripcionCorta
        {
            get { return _descripcionCorta; }
            set { _descripcionCorta = value; }
        }
        private int _orden;

        public int Orden
        {
            get { return _orden; }
            set { _orden = value; }
        }
        private string _estado;

        public string Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
    }
}
