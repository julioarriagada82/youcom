using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class ParentescoBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<ParentescoDTO> getListadoParentesco()
        {
            var casa = YouCom.facade.Parentesco.getListadoParentesco();
            return casa;
        }

        public static ParentescoDTO detalleParentesco(decimal idParentesco)
        {
            ParentescoDTO parentesco;
            parentesco = YouCom.facade.Parentesco.getListadoParentesco().Where(x => x.IdParentesco == idParentesco).First();
            return parentesco;
        }

        public static IList<ParentescoDTO> listaParentescoActivo()
        {
            IList<ParentescoDTO> parentesco;
            parentesco = YouCom.facade.Parentesco.getListadoParentesco().Where(x => x.Estado == "1").ToList();
            return parentesco;
        }

        public static IList<ParentescoDTO> listaParentescoInactivo()
        {
            IList<ParentescoDTO> parentesco;
            parentesco = YouCom.facade.Parentesco.getListadoParentesco().Where(x => x.Estado == "2").ToList();
            return parentesco;
        }

        public static bool Delete(ParentescoDTO theParentescoDTO)
        {
            bool resultado = ParentescoDAL.Delete(theParentescoDTO);
            return resultado;
        }

        public static bool Insert(DTO.ParentescoDTO theParentescoDTO)
        {
            bool resultado = ParentescoDAL.Insert(theParentescoDTO);
            return resultado;
        }

        public static bool Update(DTO.ParentescoDTO theParentescoDTO)
        {
            bool resultado = ParentescoDAL.Update(theParentescoDTO);
            return resultado;
        }

        public static bool ActivaParentesco(ParentescoDTO theParentescoDTO)
        {
            bool respuesta = YouCom.DAL.ParentescoDAL.ActivaParentesco(theParentescoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionParentesco(ParentescoDTO theParentescoDTO)
        {
            bool respuesta = facade.Parentesco.ValidaEliminacionParentesco(theParentescoDTO);
            return respuesta;
        }
    }
}
