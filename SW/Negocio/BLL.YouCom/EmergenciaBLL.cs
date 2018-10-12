﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Emergencia;
using YouCom.DAL.Emergencia;

namespace YouCom.bll
{
    public class EmergenciaBLL
    {
        public static IList<EmergenciaDTO> getListadoEmergencia()
        {
            YouCom.facade.Emergencia EmergenciaFA = new YouCom.facade.Emergencia();
            var Emergencia = YouCom.facade.Emergencia.getListadoEmergencia();
            return Emergencia;
        }

        public static EmergenciaDTO detalleEmergencia(decimal idEmergencia)
        {
            EmergenciaDTO Emergencias;
            Emergencias = facade.Emergencia.getListadoEmergencia().Where(x => x.IdEmergencia == idEmergencia).First();
            return Emergencias;
        }

        public static IList<EmergenciaDTO> getListadoEmergenciaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var emergencias = listaEmergenciaActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return emergencias;
        }

        public static IList<EmergenciaDTO> listaEmergenciaActivo()
        {
            IList<EmergenciaDTO> Emergencias;
            Emergencias = facade.Emergencia.getListadoEmergencia().Where(x => x.Estado == "1").ToList();
            return Emergencias;
        }

        public static IList<EmergenciaDTO> listaEmergenciaInactivo()
        {
            IList<EmergenciaDTO> Emergencias;
            Emergencias = facade.Emergencia.getListadoEmergencia().Where(x => x.Estado == "2").ToList();
            return Emergencias;
        }

        public static bool Delete(EmergenciaDTO myEmergenciaDTO)
        {
            bool resultado = EmergenciaDAL.Delete(myEmergenciaDTO);
            return resultado;
        }

        public static bool Insert(EmergenciaDTO myEmergenciaDTO)
        {
            bool resultado = EmergenciaDAL.Insert(myEmergenciaDTO);
            return resultado;
        }

        public static bool Update(EmergenciaDTO myEmergenciaDTO)
        {
            bool resultado = EmergenciaDAL.Update(myEmergenciaDTO);
            return resultado;
        }

        public static bool ActivaEmergencia(EmergenciaDTO theEmergenciaDTO)
        {
            bool respuesta = EmergenciaDAL.ActivaEmergencia(theEmergenciaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionEmergencia(EmergenciaDTO theEmergenciaDTO)
        {
            bool respuesta = facade.Emergencia.ValidaEliminacionEmergencia(theEmergenciaDTO);
            return respuesta;
        }
    }
}
