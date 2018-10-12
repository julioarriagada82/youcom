using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class AreasComunesBLL
    {
        public static IList<AreasComunesDTO> getListadoAreasComunes()
        {
            YouCom.facade.AreasComunes AreasComunesFA = new YouCom.facade.AreasComunes();
            var AreasComunes = YouCom.facade.AreasComunes.getListadoAreasComunes();
            return AreasComunes;
        }

        public static AreasComunesDTO detalleAreasComunes(decimal idAreasComunes)
        {
            AreasComunesDTO AreasComuness;
            AreasComuness = facade.AreasComunes.getListadoAreasComunes().Where(x => x.IdAreasComunes == idAreasComunes).First();
            return AreasComuness;
        }
        public static IList<AreasComunesDTO> getListadoAreasComunesByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var areas = listaAreasComunesActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return areas;
        }

        public static IList<AreasComunesDTO> listaAreasComunesActivo()
        {
            IList<AreasComunesDTO> AreasComuness;
            AreasComuness = facade.AreasComunes.getListadoAreasComunes().Where(x => x.Estado == "1").ToList();
            return AreasComuness;
        }

        public static IList<AreasComunesDTO> listaAreasComunesInactivo()
        {
            IList<AreasComunesDTO> AreasComuness;
            AreasComuness = facade.AreasComunes.getListadoAreasComunes().Where(x => x.Estado == "2").ToList();
            return AreasComuness;
        }

        public static bool Delete(DTO.AreasComunesDTO myAreasComunesDTO)
        {
            bool resultado = AreasComunesDAL.Delete(myAreasComunesDTO);
            return resultado;
        }

        public static bool Insert(DTO.AreasComunesDTO myAreasComunesDTO)
        {
            bool resultado = AreasComunesDAL.Insert(myAreasComunesDTO);
            return resultado;
        }

        public static bool Update(DTO.AreasComunesDTO myAreasComunesDTO)
        {
            bool resultado = AreasComunesDAL.Update(myAreasComunesDTO);
            return resultado;
        }

        public static bool ActivaAreasComunes(AreasComunesDTO theAreasComunesDTO)
        {
            bool respuesta = AreasComunesDAL.ActivaAreasComunes(theAreasComunesDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionAreasComunes(AreasComunesDTO theAreasComunesDTO)
        {
            bool respuesta = facade.AreasComunes.ValidaEliminacionAreasComunes(theAreasComunesDTO);
            return respuesta;
        }
    }
}
