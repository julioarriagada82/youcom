using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class ForoComunidadDTO : MantenedoresBase
    {
        private decimal _idForoComunidad;

        public decimal IdForoComunidad
        {
            get { return _idForoComunidad; }
            set { _idForoComunidad = value; }
        }
        private decimal _idFamilia;

        public decimal IdFamilia
        {
            get { return _idFamilia; }
            set { _idFamilia = value; }
        }
        private string _tituloForoComunidad;

        public string TituloForoComunidad
        {
            get { return _tituloForoComunidad; }
            set { _tituloForoComunidad = value; }
        }

        private string _resumenForoComunidad;

        public string ResumenForoComunidad
        {
            get { return _resumenForoComunidad; }
            set { _resumenForoComunidad = value; }
        }

        private string _descripcionForoComunidad;

        public string DescripcionForoComunidad
        {
            get { return _descripcionForoComunidad; }
            set { _descripcionForoComunidad = value; }
        }

        private decimal _idTipo;

        public decimal IdTipo
        {
            get { return _idTipo; }
            set { _idTipo = value; }
        }
        private decimal _idCategoria;

        public decimal IdCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }
        
        private DateTime _fechaPublicacion;

        public DateTime FechaPublicacion
        {
            get { return _fechaPublicacion; }
            set { _fechaPublicacion = value; }
        }
        private DateTime _fechaTermino;

        public DateTime FechaTermino
        {
            get { return _fechaTermino; }
            set { _fechaTermino = value; }
        }
    }
}
