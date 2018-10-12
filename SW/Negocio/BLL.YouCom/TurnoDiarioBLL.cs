using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class TurnoDiarioBLL
    {
        public static IList<TurnoDiarioDTO> getListadoTurnoDiario()
        {
            YouCom.facade.TurnoDiario TurnoDiarioFA = new YouCom.facade.TurnoDiario();
            var TurnoDiario = YouCom.facade.TurnoDiario.getListadoTurnoDiario();
            return TurnoDiario;
        }

        public static TurnoDiarioDTO detalleTurnoDiario(decimal idTurnoDiario)
        {
            TurnoDiarioDTO TurnoDiarios;
            TurnoDiarios = facade.TurnoDiario.getListadoTurnoDiario().Where(x => x.IdTurnoDiario == idTurnoDiario).First();
            return TurnoDiarios;
        }

        public static IList<TurnoDiarioDTO> getListadoTurnoDiarioByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var turnos = listaTurnoDiarioActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return turnos;
        }

        public static IList<TurnoDiarioDTO> listaTurnoDiarioActivo()
        {
            IList<TurnoDiarioDTO> TurnoDiarios;
            TurnoDiarios = facade.TurnoDiario.getListadoTurnoDiario().Where(x => x.Estado == "1").ToList();
            return TurnoDiarios;
        }

        public static IList<TurnoDiarioDTO> listaTurnoDiarioInactivo()
        {
            IList<TurnoDiarioDTO> TurnoDiarios;
            TurnoDiarios = facade.TurnoDiario.getListadoTurnoDiario().Where(x => x.Estado == "2").ToList();
            return TurnoDiarios;
        }

        public static bool Delete(DTO.TurnoDiarioDTO myTurnoDiarioDTO)
        {
            bool resultado = TurnoDiarioDAL.Delete(myTurnoDiarioDTO);
            return resultado;
        }

        public static bool Insert(DTO.TurnoDiarioDTO myTurnoDiarioDTO)
        {
            bool resultado = TurnoDiarioDAL.Insert(myTurnoDiarioDTO);
            return resultado;
        }

        public static bool Update(DTO.TurnoDiarioDTO myTurnoDiarioDTO)
        {
            bool resultado = TurnoDiarioDAL.Update(myTurnoDiarioDTO);
            return resultado;
        }

        public static bool ActivaTurnoDiario(TurnoDiarioDTO theTurnoDiarioDTO)
        {
            bool respuesta = YouCom.DAL.TurnoDiarioDAL.ActivaTurnoDiario(theTurnoDiarioDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionTurnoDiario(TurnoDiarioDTO theTurnoDiarioDTO)
        {
            bool respuesta = facade.TurnoDiario.ValidaEliminacionTurnoDiario(theTurnoDiarioDTO);
            return respuesta;
        }
    }
}
