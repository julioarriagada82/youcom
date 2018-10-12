using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Foro
{
    public class ForoComunidadDTO : MantenedoresBase
    {
        private decimal _idForoComunidad;

        public decimal IdForoComunidad
        {
            get { return _idForoComunidad; }
            set { _idForoComunidad = value; }
        }

        private decimal _idPadre;

        public decimal IdPadre
        {
            get { return _idPadre; }
            set { _idPadre = value; }
        }

        private DTO.Propietario.FamiliaDTO theFamiliaDTO;
        public DTO.Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
        }
        private string _tituloForoComunidad;

        public string TituloForoComunidad
        {
            get { return _tituloForoComunidad; }
            set { _tituloForoComunidad = value; }
        }

        private string _descripcionForoComunidad;

        public string DescripcionForoComunidad
        {
            get { return _descripcionForoComunidad; }
            set { _descripcionForoComunidad = value; }
        }

        private DateTime _fechaForoComunidad;

        public DateTime FechaForoComunidad
        {
            get { return _fechaForoComunidad; }
            set { _fechaForoComunidad = value; }
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

        private ForoComunidadEstadoDTO theForoComunidadEstadoDTO;
        public ForoComunidadEstadoDTO TheForoComunidadEstadoDTO
        {
            get { return theForoComunidadEstadoDTO; }
            set { theForoComunidadEstadoDTO = value; }
        }

        private string _motivoEstadoForoComunidad;

        public string MotivoEstadoForoComunidad
        {
            get { return _motivoEstadoForoComunidad; }
            set { _motivoEstadoForoComunidad = value; }
        }

        private CategoriaDTO theCategoriaDTO;
        public CategoriaDTO TheCategoriaDTO
        {
            get { return theCategoriaDTO; }
            set { theCategoriaDTO = value; }
        }
    }
}
