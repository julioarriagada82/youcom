using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class ParametrosDTO : MantenedoresBase
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
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
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
    }
}
