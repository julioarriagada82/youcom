using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Servicio
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

        private GiroDTO theGiroDTO;
        public GiroDTO TheGiroDTO
        {
            get { return theGiroDTO; }
            set { theGiroDTO = value; }
        }

        private ServiciosDTO theServiciosDTO;
        public ServiciosDTO TheServiciosDTO
        {
            get { return theServiciosDTO; }
            set { theServiciosDTO = value; }
        }

        private ResponsableDTO theResponsableEmpresaServicioDTO;
        public ResponsableDTO TheResponsableEmpresaServicioDTO
        {
            get { return theResponsableEmpresaServicioDTO; }
            set { theResponsableEmpresaServicioDTO = value; }
        }

        private string _direccionEmpresaServicio;

        public string DireccionEmpresaServicio
        {
            get { return _direccionEmpresaServicio; }
            set { _direccionEmpresaServicio = value; }
        }

        private ComunaDTO theComunaDTO;
        public ComunaDTO TheComunaDTO
        {
            get { return theComunaDTO; }
            set { theComunaDTO = value; }
        }

        private string _telefonoEmpresaServicio;

        public string TelefonoEmpresaServicio
        {
            get { return _telefonoEmpresaServicio; }
            set { _telefonoEmpresaServicio = value; }
        }

        private string _celularEmpresaServicio;

        public string CelularEmpresaServicio
        {
            get { return _celularEmpresaServicio; }
            set { _celularEmpresaServicio = value; }
        }

        private string _urlEmpresaServicio;

        public string UrlEmpresaServicio
        {
            get { return _urlEmpresaServicio; }
            set { _urlEmpresaServicio = value; }
        }

        private string _emailEmpresaServicio;

        public string EmailEmpresaServicio
        {
            get { return _emailEmpresaServicio; }
            set { _emailEmpresaServicio = value; }
        }

        private string _logoEmpresaServicio;

        public string LogoEmpresaServicio
        {
            get { return _logoEmpresaServicio; }
            set { _logoEmpresaServicio = value; }
        }

        private TipoEmpresaServicioDTO theTipoEmpresaServicioDTO;
        public TipoEmpresaServicioDTO TheTipoEmpresaServicioDTO
        {
            get { return theTipoEmpresaServicioDTO; }
            set { theTipoEmpresaServicioDTO = value; }
        }
    }
}
