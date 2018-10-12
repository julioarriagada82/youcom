using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    public class RankingServicioDTO :MantenedoresBase
    {
        private decimal _idRanking;

        public decimal IdRanking
        {
            get { return _idRanking; }
            set { _idRanking = value; }
        }
        private decimal _idServicio;

        public decimal IdServicio
        {
            get { return _idServicio; }
            set { _idServicio = value; }
        }
        private decimal _idFamilia;

        public decimal IdFamilia
        {
            get { return _idFamilia; }
            set { _idFamilia = value; }
        }
        private string _comentario;

        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }
        private int _nota;

        public int Nota
        {
            get { return _nota; }
            set { _nota = value; }
        }
    }
}
