using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class EmpresaContratistaDTO : MantenedoresBase
    {
        private decimal _idEmpresaContratista;

        public decimal IdEmpresaContratista
        {
            get { return _idEmpresaContratista; }
            set { _idEmpresaContratista = value; }
        }

        private string _RutCondominioContratista;

        public string RutCondominioContratista
        {
            get { return _RutCondominioContratista; }
            set { _RutCondominioContratista = value; }
        }
        
        private string _razonSocialEmpresaContratista;

        public string RazonSocialEmpresaContratista
        {
            get { return _razonSocialEmpresaContratista; }
            set { _razonSocialEmpresaContratista = value; }
        }

        private string _direccionEmpresaContratista;

        public string DireccionEmpresaContratista
        {
            get { return _direccionEmpresaContratista; }
            set { _direccionEmpresaContratista = value; }
        }

        private GiroDTO theGiroDTO;
        public GiroDTO TheGiroDTO
        {
            get { return theGiroDTO; }
            set { theGiroDTO = value; }
        }

        private ComunaDTO theComunaDTO;
        public ComunaDTO TheComunaDTO
        {
            get { return theComunaDTO; }
            set { theComunaDTO = value; }
        }

        private string _latitudEmpresaContratista;

        public string LatitudEmpresaContratista
        {
            get { return _latitudEmpresaContratista; }
            set { _latitudEmpresaContratista = value; }
        }

        private string _longitudEmpresaContratista;

        public string LongitudEmpresaContratista
        {
            get { return _longitudEmpresaContratista; }
            set { _longitudEmpresaContratista = value; }
        }

        private string _telefonoEmpresaContratista;

        public string TelefonoEmpresaContratista
        {
            get { return _telefonoEmpresaContratista; }
            set { _telefonoEmpresaContratista = value; }
        }

        private string _celularEmpresaContratista;

        public string CelularEmpresaContratista
        {
            get { return _celularEmpresaContratista; }
            set { _celularEmpresaContratista = value; }
        }

        private string _emailEmpresaContratista;

        public string EmailEmpresaContratista
        {
            get { return _emailEmpresaContratista; }
            set { _emailEmpresaContratista = value; }
        }

        private string _urlEmpresaContratista;

        public string UrlEmpresaContratista
        {
            get { return _urlEmpresaContratista; }
            set { _urlEmpresaContratista = value; }
        }

        private string _logoEmpresaContratista;

        public string LogoEmpresaContratista
        {
            get { return _logoEmpresaContratista; }
            set { _logoEmpresaContratista = value; }
        }
    }
}
