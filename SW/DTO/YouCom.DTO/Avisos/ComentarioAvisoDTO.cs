using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Avisos
{
    public class ComentarioAvisoDTO : MantenedoresBase
    {
        private decimal _idComentarioAviso;

        public decimal IdComentarioAviso
        {
            get { return _idComentarioAviso; }
            set { _idComentarioAviso = value; }
        }

        private decimal _idPadre;

        public decimal IdPadre
        {
            get { return _idPadre; }
            set { _idPadre = value; }
        }

        private AvisoDTO theAvisosDTO;
        public AvisoDTO TheAvisosDTO
        {
            get { return theAvisosDTO; }
            set { theAvisosDTO = value; }
        }

        private Propietario.FamiliaDTO theFamiliaDTO;
        public Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
        }

        private string _emailComentarioAviso;

        public string EmailComentarioAviso
        {
            get { return _emailComentarioAviso; }
            set { _emailComentarioAviso = value; }
        }

        private string _comentarioAviso;

        public string ComentarioAviso
        {
            get { return _comentarioAviso; }
            set { _comentarioAviso = value; }
        }

        private DateTime _fechaComentarioAviso;

        public DateTime FechaComentarioAviso
        {
            get { return _fechaComentarioAviso; }
            set { _fechaComentarioAviso = value; }
        }
    }
}
