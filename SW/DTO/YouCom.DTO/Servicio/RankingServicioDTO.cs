using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Servicio
{
    public class RankingServicioDTO :MantenedoresBase
    {
        private decimal _idRanking;

        public decimal IdRanking
        {
            get { return _idRanking; }
            set { _idRanking = value; }
        }

        private Servicio.EmpresaServicioDTO theEmpresaServicioDTO;
        public Servicio.EmpresaServicioDTO TheEmpresaServicioDTO
        {
            get { return theEmpresaServicioDTO; }
            set { theEmpresaServicioDTO = value; }
        }
        private DTO.Propietario.FamiliaDTO theFamiliaDTO;
        public DTO.Propietario.FamiliaDTO TheFamiliaDTO
        {
            get { return theFamiliaDTO; }
            set { theFamiliaDTO = value; }
        }

        private string _comentario;

        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }

        private DateTime _fechaRanking;

        public DateTime FechaRanking
        {
            get { return _fechaRanking; }
            set { _fechaRanking = value; }
        }
        private int _nota;

        public int Nota
        {
            get { return _nota; }
            set { _nota = value; }
        }
    }
}
