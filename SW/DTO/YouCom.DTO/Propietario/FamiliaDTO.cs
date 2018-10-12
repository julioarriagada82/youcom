using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Propietario
{
    public class FamiliaDTO : MantenedoresBase
    {
        private decimal _idFamilia;

        public decimal IdFamilia
        {
            get { return _idFamilia; }
            set { _idFamilia = value; }
        }

        private CasaDTO theCasaDTO;
        public CasaDTO TheCasaDTO
        {
            get { return theCasaDTO; }
            set { theCasaDTO = value; }
        }

        private OcupacionDTO theOcupacionDTO;
        public OcupacionDTO TheOcupacionDTO
        {
            get { return theOcupacionDTO; }
            set { theOcupacionDTO = value; }
        }

        private string _rutFamilia;

        public string RutFamilia
        {
            get { return _rutFamilia; }
            set { _rutFamilia = value; }
        }
        private string _nombreFamilia;

        public string NombreFamilia
        {
            get { return _nombreFamilia; }
            set { _nombreFamilia = value; }
        }

        private string _apellidoPaternoFamilia;

        public string ApellidoPaternoFamilia
        {
            get { return _apellidoPaternoFamilia; }
            set { _apellidoPaternoFamilia = value; }
        }

        private string _apellidoMaternoFamilia;

        public string ApellidoMaternoFamilia
        {
            get { return _apellidoMaternoFamilia; }
            set { _apellidoMaternoFamilia = value; }
        }

        private DateTime _fechaNacimientoFamilia;

        public DateTime FechaNacimientoFamilia
        {
            get { return _fechaNacimientoFamilia; }
            set { _fechaNacimientoFamilia = value; }
        }

        private ParentescoDTO theParentescoDTO;
        public ParentescoDTO TheParentescoDTO
        {
            get { return theParentescoDTO; }
            set { theParentescoDTO = value; }
        }

        private string _telefonoFamilia;

        public string TelefonoFamilia
        {
            get { return _telefonoFamilia; }
            set { _telefonoFamilia = value; }
        }

        private string _celularFamilia;

        public string CelularFamilia
        {
            get { return _celularFamilia; }
            set { _celularFamilia = value; }
        }

        private string _emailFamilia;

        public string EmailFamilia
        {
            get { return _emailFamilia; }
            set { _emailFamilia = value; }
        }

        public string NombreCompleto
        {
            get
            {
                return _nombreFamilia + " " + _apellidoPaternoFamilia + " " + _apellidoMaternoFamilia;
            }
        }
    }
}
