using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DAL;
using YouCom.DTO;

namespace YouCom.bll
{
    public class ComunaBLL
    {
        public static IList<ComunaDTO> getListadoComuna()
        {
            YouCom.facade.Comuna ComunaFA = new YouCom.facade.Comuna();
            var Comuna = YouCom.facade.Comuna.getListadoComuna();
            return Comuna;
        }

        public static ComunaDTO detalleComuna(decimal idComuna)
        {
            ComunaDTO Comunas;
            Comunas = facade.Comuna.getListadoComuna().Where(x => x.IdComuna == idComuna).First();
            return Comunas;
        }

        public static IList<ComunaDTO> listaComunaByCiudad(decimal idCiudad)
        {
            IList<ComunaDTO> Comunas;
            Comunas = facade.Comuna.getListadoComuna().Where(x => x.IdComuna == idCiudad).ToList();
            return Comunas;
        }

        public static IList<ComunaDTO> listaComunaActivo()
        {
            IList<ComunaDTO> Comunas;
            Comunas = facade.Comuna.getListadoComuna().Where(x => x.Estado == "1").ToList();
            return Comunas;
        }

        public static IList<ComunaDTO> listaComunaInactivo()
        {
            IList<ComunaDTO> Comunas;
            Comunas = facade.Comuna.getListadoComuna().Where(x => x.Estado == "2").ToList();
            return Comunas;
        }

        public static bool Delete(DTO.ComunaDTO myComunaDTO)
        {
            bool resultado = ComunaDAL.Delete(myComunaDTO);
            return resultado;
        }

        public static bool Insert(DTO.ComunaDTO myComunaDTO)
        {
            bool resultado = ComunaDAL.Insert(myComunaDTO);
            return resultado;
        }

        public static bool Update(DTO.ComunaDTO myComunaDTO)
        {
            bool resultado = ComunaDAL.Update(myComunaDTO);
            return resultado;
        }

        public static bool ActivaComuna(ComunaDTO theComunaDTO)
        {
            bool respuesta = ComunaDAL.ActivaComuna(theComunaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionComuna(ComunaDTO theComunaDTO)
        {
            bool respuesta = facade.Comuna.ValidaEliminacionComuna(theComunaDTO);
            return respuesta;
        }
    }
}
