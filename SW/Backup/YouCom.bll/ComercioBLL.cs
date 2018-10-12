using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class ComercioBLL
    {
        public static IList<ComercioDTO> getListadoComercio()
        {
            YouCom.facade.Comercio ComercioFA = new YouCom.facade.Comercio();
            var Comercio = YouCom.facade.Comercio.getListadoComercio();
            return Comercio;
        }

        public static ComercioDTO detalleComercio(decimal idComercio)
        {
            ComercioDTO Comercios;
            Comercios = facade.Comercio.getListadoComercio().Where(x => x.IdComercio == idComercio).First();
            return Comercios;
        }

        public static IList<ComercioDTO> listaComercioActivo()
        {
            IList<ComercioDTO> Comercios;
            Comercios = facade.Comercio.getListadoComercio().Where(x => x.Estado == "1").ToList();
            return Comercios;
        }

        public static IList<ComercioDTO> listaComercioInactivo()
        {
            IList<ComercioDTO> Comercios;
            Comercios = facade.Comercio.getListadoComercio().Where(x => x.Estado == "2").ToList();
            return Comercios;
        }

        public static bool Delete(DTO.ComercioDTO myComercioDTO)
        {
            bool resultado = ComercioDAL.Delete(myComercioDTO);
            return resultado;
        }

        public static bool Insert(DTO.ComercioDTO myComercioDTO)
        {
            bool resultado = ComercioDAL.Insert(myComercioDTO);
            return resultado;
        }

        public static bool Update(DTO.ComercioDTO myComercioDTO)
        {
            bool resultado = ComercioDAL.Update(myComercioDTO);
            return resultado;
        }

        public static bool ActivaComercio(ComercioDTO theComercioDTO)
        {
            bool respuesta = YouCom.DAL.ComercioDAL.ActivaComercio(theComercioDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionComercio(ComercioDTO theComercioDTO)
        {
            bool respuesta = facade.Comercio.ValidaEliminacionComercio(theComercioDTO);
            return respuesta;
        }
    }
}
