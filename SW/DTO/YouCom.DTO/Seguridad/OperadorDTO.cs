using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Seguridad
{
    public class OperadorDTO : MantenedoresBase
    {
        private string _usuario;

        public string Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        private int _operadorNro;

        public int OperadorNro
        {
            get { return _operadorNro; }
            set { _operadorNro = value; }
        }
        private string _esAut;
        public string EsAut
        {
            get { return _esAut; }
            set { _esAut = value; }
        }
        
        private string _operadorDescripcion;
        public string OperadorDescripcion
        {
            get { return _operadorDescripcion; }
            set { _operadorDescripcion = value; }
        }
        
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        
        private DateTime _fechaPassword;
        public DateTime FechaPassword
        {
            get { return _fechaPassword; }
            set { _fechaPassword = value; }
        }

        private int _periodoCambio;
        public int PeriodoCambio
        {
            get { return _periodoCambio; }
            set { _periodoCambio = value; }
        }
        private DateTime _intentoFallidoFecha;
        public DateTime IntentoFallidoFecha
        {
            get { return _intentoFallidoFecha; }
            set { _intentoFallidoFecha = value; }
        }
        
        private int _intentoFallidoCant;
        public int IntentoFallidoCant
        {
            get { return _intentoFallidoCant; }
            set { _intentoFallidoCant = value; }
        }

        private List<FuncionGrupoDTO> grupo;

        public List<FuncionGrupoDTO> Grupo
        {
            get { return grupo; }
            set { grupo = value; }
        }

        private string _rut;

        public string Rut
        {
            get { return _rut; }
            set { _rut = value; }
        }

        private string _paterno { get; set; }
        private string _materno { get; set; }
        private string _nombres { get; set; }
        private string _mail { get; set; }

        public string Paterno
        {
            get
            {
                return _paterno;
            }
            set
            {
                _paterno = value;
            }
        }
        public string Materno
        {
            get
            {
                return _materno;
            }
            set
            {
                _materno = value;
            }
        }
        public string Nombres
        {
            get
            {
                return _nombres;
            }
            set
            {
                _nombres = value;
            }
        }
        public string Mail
        {
            get
            {
                return _mail;
            }
            set
            {
                _mail = value;
            }
        }
        private DateTime _fechaNacimiento;
        public DateTime FechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        private PerfilDTO thePerfilDTO;
        public PerfilDTO ThePerfilDTO
        {
            get { return thePerfilDTO; }
            set { thePerfilDTO = value; }
        }

        private Propietario.CasaDTO theCasaDTO;
        public Propietario.CasaDTO TheCasaDTO
        {
            get { return theCasaDTO; }
            set { theCasaDTO = value; }
        }
    }
}