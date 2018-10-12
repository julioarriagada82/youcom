using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Seguridad
{
    public class CondominioDTO : MantenedoresBase
    {
        private decimal _idCondominio;

        public decimal IdCondominio
        {
            get { return _idCondominio; }
            set { _idCondominio = value; }
        }

        private string _rutCondominio;

        public string RutCondominio
        {
            get { return _rutCondominio; }
            set { _rutCondominio = value; }
        }
        private string _nombreCondominio;

        public string NombreCondominio
        {
            get { return _nombreCondominio; }
            set { _nombreCondominio = value; }
        }

        private string _telefonoCondominio;

        public string TelefonoCondominio
        {
            get { return _telefonoCondominio; }
            set { _telefonoCondominio = value; }
        }

        private string _direccionCondominio;

        public string DireccionCondominio
        {
            get { return _direccionCondominio; }
            set { _direccionCondominio = value; }
        }

        private string _emailCondominio;

        public string EmailCondominio
        {
            get { return _emailCondominio; }
            set { _emailCondominio = value; }
        }

        private ComunaDTO theComunaDTO;
        public ComunaDTO TheComunaDTO
        {
            get { return theComunaDTO; }
            set { theComunaDTO = value; }
        }

        private string _latitudCondominio;

        public string LatitudCondominio
        {
            get { return _latitudCondominio; }
            set { _latitudCondominio = value; }
        }

        private string _longitudCondominio;

        public string LongitudCondominio
        {
            get { return _longitudCondominio; }
            set { _longitudCondominio = value; }
        }

        private IList<DTO.Seguridad.ComunidadDTO> theComunidadDTO = new List<Seguridad.ComunidadDTO>();
        public IList<DTO.Seguridad.ComunidadDTO> TheComunidadDTO
        {
            get { return theComunidadDTO; }
            set { theComunidadDTO = value; }
        }

        private DTO.Seguridad.RolDTO theRolDTO = new Seguridad.RolDTO();
        public DTO.Seguridad.RolDTO TheRolDTO
        {
            get { return theRolDTO; }
            set { theRolDTO = value; }
        }

        private ProductoCollection _productos;
        public ProductoCollection Productos
        {
            get
            {
                if (_productos == null)
                    _productos = new ProductoCollection();
                return _productos;
            }
        }
    }
}
