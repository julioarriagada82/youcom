using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Propuesta
{
    public class PropuestaDTO : MantenedoresBase
    {
        private decimal _idPropuesta;

        public decimal IdPropuesta
        {
            get { return _idPropuesta; }
            set { _idPropuesta = value; }
        }
        private string _nombrePropuesta;

        public string NombrePropuesta
        {
            get { return _nombrePropuesta; }
            set { _nombrePropuesta = value; }
        }
        private string _descripcionPropuesta;

        public string DescripcionPropuesta
        {
            get { return _descripcionPropuesta; }
            set { _descripcionPropuesta = value; }
        }
        private DateTime _fechaPropuesta;

        public DateTime FechaPropuesta
        {
            get { return _fechaPropuesta; }
            set { _fechaPropuesta = value; }
        }
        private string _direccionPropuesta;

        public string DireccionPropuesta
        {
            get { return _direccionPropuesta; }
            set { _direccionPropuesta = value; }
        }

        private Propietario.FamiliaDTO theFamiliaDTO;
        public Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
        }

        private PropuestaEstadoDTO thePropuestaEstadoDTO;
        public PropuestaEstadoDTO ThePropuestaEstadoDTO
        {
            get { return thePropuestaEstadoDTO; }
            set { thePropuestaEstadoDTO = value; }
        }

        private string _motivoEstado;

        public string MotivoEstado
        {
            get { return _motivoEstado; }
            set { _motivoEstado = value; }
        }
    }
}
