﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class ServiciosBLL
    {
        public static IList<ServiciosDTO> getListadoServicios()
        {
            YouCom.facade.Servicios ServiciosFA = new YouCom.facade.Servicios();
            var Servicios = YouCom.facade.Servicios.getListadoServicios();
            return Servicios;
        }

        public static ServiciosDTO detalleServicios(decimal idServicio)
        {
            ServiciosDTO Servicioss;
            Servicioss = facade.Servicios.getListadoServicios().Where(x => x.IdServicio == idServicio).First();
            return Servicioss;
        }

        public static IList<ServiciosDTO> listaServiciosActivo()
        {
            IList<ServiciosDTO> Servicioss;
            Servicioss = facade.Servicios.getListadoServicios().Where(x => x.Estado == "1").ToList();
            return Servicioss;
        }

        public static IList<ServiciosDTO> listaServiciosInactivo()
        {
            IList<ServiciosDTO> Servicioss;
            Servicioss = facade.Servicios.getListadoServicios().Where(x => x.Estado == "2").ToList();
            return Servicioss;
        }

        public static bool Delete(DTO.ServiciosDTO myServiciosDTO)
        {
            bool resultado = ServiciosDAL.Delete(myServiciosDTO);
            return resultado;
        }

        public static bool Insert(DTO.ServiciosDTO myServiciosDTO)
        {
            bool resultado = ServiciosDAL.Insert(myServiciosDTO);
            return resultado;
        }

        public static bool Update(DTO.ServiciosDTO myServiciosDTO)
        {
            bool resultado = ServiciosDAL.Update(myServiciosDTO);
            return resultado;
        }

        public static bool ActivaServicios(ServiciosDTO theServiciosDTO)
        {
            bool respuesta = YouCom.DAL.ServiciosDAL.ActivaServicio(theServiciosDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionServicios(ServiciosDTO theServiciosDTO)
        {
            bool respuesta = facade.Servicios.ValidaEliminacionServicio(theServiciosDTO);
            return respuesta;
        }
    }
}
