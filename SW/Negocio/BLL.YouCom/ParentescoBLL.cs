using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL.Propietario;

namespace YouCom.bll
{
    public class ParentescoBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<DTO.Propietario.ParentescoDTO> getListadoParentesco()
        {
            var casa = YouCom.facade.Parentesco.getListadoParentesco();
            return casa;
        }

        public static DTO.Propietario.ParentescoDTO detalleParentesco(decimal idParentesco)
        {
            DTO.Propietario.ParentescoDTO parentesco;
            parentesco = YouCom.facade.Parentesco.getListadoParentesco().Where(x => x.IdParentesco == idParentesco).First();
            return parentesco;
        }

        public static IList<DTO.Propietario.ParentescoDTO> getListadoParentescoByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var parentescos = listaParentescoActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return parentescos;
        }

        public static IList<DTO.Propietario.ParentescoDTO> listaParentescoActivo()
        {
            IList<DTO.Propietario.ParentescoDTO> parentesco;
            parentesco = YouCom.facade.Parentesco.getListadoParentesco().Where(x => x.Estado == "1").ToList();
            return parentesco;
        }

        public static IList<DTO.Propietario.ParentescoDTO> listaParentescoInactivo()
        {
            IList<DTO.Propietario.ParentescoDTO> parentesco;
            parentesco = YouCom.facade.Parentesco.getListadoParentesco().Where(x => x.Estado == "2").ToList();
            return parentesco;
        }

        public static bool Delete(DTO.Propietario.ParentescoDTO theParentescoDTO)
        {
            bool resultado = ParentescoDAL.Delete(theParentescoDTO);
            return resultado;
        }

        public static bool Insert(DTO.Propietario.ParentescoDTO theParentescoDTO)
        {
            bool resultado = ParentescoDAL.Insert(theParentescoDTO);
            return resultado;
        }

        public static bool Update(DTO.Propietario.ParentescoDTO theParentescoDTO)
        {
            bool resultado = ParentescoDAL.Update(theParentescoDTO);
            return resultado;
        }

        public static bool ActivaParentesco(DTO.Propietario.ParentescoDTO theParentescoDTO)
        {
            bool respuesta = ParentescoDAL.ActivaParentesco(theParentescoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionParentesco(DTO.Propietario.ParentescoDTO theParentescoDTO)
        {
            bool respuesta = facade.Parentesco.ValidaEliminacionParentesco(theParentescoDTO);
            return respuesta;
        }
    }
}
