using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class ProyectoDTO : MantenedoresBase
    {
        private decimal _idProyecto;

        public decimal IdProyecto
        {
            get { return _idProyecto; }
            set { _idProyecto = value; }
        }

        private Propuesta.PropuestaDTO thePropuestaDTO;
        public Propuesta.PropuestaDTO ThePropuestaDTO
        {
            get { return thePropuestaDTO; }
            set { thePropuestaDTO = value; }
        }

        private string _nombreProyecto;

        public string NombreProyecto
        {
            get { return _nombreProyecto; }
            set { _nombreProyecto = value; }
        }
        private string _descripcionProyecto;

        public string DescripcionProyecto
        {
            get { return _descripcionProyecto; }
            set { _descripcionProyecto = value; }
        }
        private DateTime _fechaInicioProyecto;

        public DateTime FechaInicioProyecto
        {
            get { return _fechaInicioProyecto; }
            set { _fechaInicioProyecto = value; }
        }
        private DateTime _fechaTerminoProyecto;

        public DateTime FechaTerminoProyecto
        {
            get { return _fechaTerminoProyecto; }
            set { _fechaTerminoProyecto = value; }
        }
        private DateTime _fechaEntregaProyecto;

        public DateTime FechaEntregaProyecto
        {
            get { return _fechaEntregaProyecto; }
            set { _fechaEntregaProyecto = value; }
        }
        private decimal _presupuestoProyecto;

        public decimal PresupuestoProyecto
        {
            get { return _presupuestoProyecto; }
            set { _presupuestoProyecto = value; }
        }
        private string _direccionProyecto;

        public string DireccionProyecto
        {
            get { return _direccionProyecto; }
            set { _direccionProyecto = value; }
        }
        private EmpresaContratistaDTO theEmpresaContratistaDTO;
        public EmpresaContratistaDTO TheEmpresaContratistaDTO
        {
            get { return theEmpresaContratistaDTO; }
            set { theEmpresaContratistaDTO = value; }
        }

        private ProyectoEstadoDTO theProyectoEstadoDTO;
        public ProyectoEstadoDTO TheProyectoEstadoDTO
        {
            get { return theProyectoEstadoDTO; }
            set { theProyectoEstadoDTO = value; }
        }
    }
}
