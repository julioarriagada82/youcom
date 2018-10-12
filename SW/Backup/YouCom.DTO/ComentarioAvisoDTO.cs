using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class ComentarioAvisoDTO : MantenedoresBase
    {
        private decimal _idComentarioAviso;

        public decimal IdComentarioAviso
        {
            get { return _idComentarioAviso; }
            set { _idComentarioAviso = value; }
        }

        private decimal _idAviso;

        public decimal IdAviso
        {
            get { return _idAviso; }
            set { _idAviso = value; }
        }

        private decimal _idFamilia;

        public decimal IdFamilia
        {
            get { return _idFamilia; }
            set { _idFamilia = value; }
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
