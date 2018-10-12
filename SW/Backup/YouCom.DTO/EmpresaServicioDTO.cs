using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class EmpresaServicioDTO: MantenedoresBase
    {
        private decimal _idEmpresaServicio;

        public decimal IdEmpresaServicio
        {
            get { return _idEmpresaServicio; }
            set { _idEmpresaServicio = value; }
        }
        private string _razonSocialEmpresaServicio;

        public string RazonSocialEmpresaServicio
        {
            get { return _razonSocialEmpresaServicio; }
            set { _razonSocialEmpresaServicio = value; }
        }
        private string _rutEmpresaServicio;

        public string RutEmpresaServicio
        {
            get { return _rutEmpresaServicio; }
            set { _rutEmpresaServicio = value; }
        }
        private string _direccionEmpresaServicio;

        public string DireccionEmpresaServicio
        {
            get { return _direccionEmpresaServicio; }
            set { _direccionEmpresaServicio = value; }
        }
        private decimal _idGiro;

        public decimal IdGiro
        {
            get { return _idGiro; }
            set { _idGiro = value; }
        }
        private string _telefonoEmpresaServicio;

        public string TelefonoEmpresaServicio
        {
            get { return _telefonoEmpresaServicio; }
            set { _telefonoEmpresaServicio = value; }
        }
        private string _urlEmpresaServicio;

        public string UrlEmpresaServicio
        {
            get { return _urlEmpresaServicio; }
            set { _urlEmpresaServicio = value; }
        }
        private string _nombreResponsable;

        public string NombreResponsable
        {
            get { return _nombreResponsable; }
            set { _nombreResponsable = value; }
        }
        private string _rutResponsable;

        public string RutResponsable
        {
            get { return _rutResponsable; }
            set { _rutResponsable = value; }
        }
        private string _telefonoResponsable;

        public string TelefonoResponsable
        {
            get { return _telefonoResponsable; }
            set { _telefonoResponsable = value; }
        }
        private string _cargoResponsable;

        public string CargoResponsable
        {
            get { return _cargoResponsable; }
            set { _cargoResponsable = value; }
        }

    }
}
