using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Seguridad
{
    [Serializable()]
    public class UsuarioDTO
    {
        private string _nombres;
        private string _paterno;
        private string _materno;

        public string Nombres
        {
            get { return _nombres; }
            set { _nombres = value; }
        }
        public string Paterno
        {
            get { return _paterno; }
            set { _paterno = value; }
        }
        public string Materno
        {
            get { return _materno; }
            set { _materno = value; }
        }

        private string _token;
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }

        private string _token_usr;
        public string Token_Usr
        {
            get { return _token_usr; }
            set { _token_usr = value; }
        }

        private decimal _indexCondominio;
        public decimal IndexCondominio
        {
            get { return _indexCondominio; }
            set { _indexCondominio = value; }
        }

        private decimal _indexComunidad;
        public decimal IndexComunidad
        {
            get { return _indexComunidad; }
            set { _indexComunidad = value; }
        }

        private string _rutCondominio;
        public string RutCondominio
        {
            get { return _rutCondominio; }
            set { _rutCondominio = value; }
        }

        private string _rutCondominiosindv;
        public string RutCondominioSinDv
        {
            get { return _rutCondominiosindv; }
            set { _rutCondominiosindv = value; }
        }

        private string _dvCondominio;
        public string DVCondominio
        {
            get { return _dvCondominio; }
            set { _dvCondominio = value; }
        }

        private string _rut;
        public string Rut
        {
            get { return _rut; }
            set { _rut = value; }
        }

        private string _rutsindv;
        public string RutSinDV
        {
            get { return _rutsindv; }
            set { _rutsindv = value; }
        }

        private string _dv;
        public string DV
        {
            get { return _dv; }
            set { _dv = value; }
        }

        private string _nombrecompleto;
        public string NombreCompleto
        {
            get { return _nombrecompleto; }
            set { _nombrecompleto = value; }
        }

        private string _nombrecompletoCondominio;
        public string NombreCompletoCondominio
        {
            get { return _nombrecompletoCondominio; }
            set { _nombrecompletoCondominio = value; }
        }
        
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private IList<DTO.Seguridad.CondominioDTO> theCondominioDTO = new List<Seguridad.CondominioDTO>();
        public  IList<DTO.Seguridad.CondominioDTO> TheCondominioDTO
        {
            get { return theCondominioDTO; }
            set { theCondominioDTO = value; }
        }

        private DTO.Seguridad.CondominioDTO theCondominioSeleccionDTO = new Seguridad.CondominioDTO();
        public DTO.Seguridad.CondominioDTO TheCondominioSeleccionDTO
        {
            get { return theCondominioSeleccionDTO; }
            set { theCondominioSeleccionDTO = value; }
        }

        private DTO.Seguridad.ComunidadDTO theComunidadSeleccionDTO = new Seguridad.ComunidadDTO();
        public DTO.Seguridad.ComunidadDTO TheComunidadSeleccionDTO
        {
            get { return theComunidadSeleccionDTO; }
            set { theComunidadSeleccionDTO = value; }
        }

        private DTO.Propietario.FamiliaDTO theFamiliaDTO = new Propietario.FamiliaDTO();
        public DTO.Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
        }

        public UsuarioDTO()
        {
        }
    }
}
