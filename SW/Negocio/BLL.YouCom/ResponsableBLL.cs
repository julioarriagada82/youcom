using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Servicio;
using YouCom.DAL;

namespace YouCom.bll
{
    public class ResponsableBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<ResponsableDTO> getListadoResponsable()
        {
            var Responsable = YouCom.facade.Responsable.getListadoResponsable();
            return Responsable;
        }

        public static ResponsableDTO detalleResponsable(decimal idResponsable)
        {
            ResponsableDTO Responsable;
            Responsable = facade.Responsable.getListadoResponsable().Where(x => x.IdResponsable == idResponsable).First();
            return Responsable;
        }
        public static IList<ResponsableDTO> getListadoResponsableByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var responsable = listaResponsableActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return responsable;
        }

        public static IList<ResponsableDTO> listaResponsableActivo()
        {
            IList<ResponsableDTO> Responsable;
            Responsable = facade.Responsable.getListadoResponsable().Where(x => x.Estado == "1").ToList();
            return Responsable;
        }

        public static IList<ResponsableDTO> listaResponsableInactivo()
        {
            IList<ResponsableDTO> Responsable;
            Responsable = facade.Responsable.getListadoResponsable().Where(x => x.Estado == "2").ToList();
            return Responsable;
        }

        public static bool Delete(ResponsableDTO myResponsableDTO)
        {
            bool resultado = ResponsableDAL.Delete(myResponsableDTO);
            return resultado;
        }

        public static bool Insert(ResponsableDTO myResponsableDTO)
        {
            bool resultado = ResponsableDAL.Insert(myResponsableDTO);
            return resultado;
        }

        public static bool Update(ResponsableDTO myResponsableDTO)
        {
            bool resultado = ResponsableDAL.Update(myResponsableDTO);
            return resultado;
        }

        public static bool ActivaResponsable(ResponsableDTO theResponsableDTO)
        {
            bool respuesta = ResponsableDAL.ActivaResponsable(theResponsableDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionResponsable(ResponsableDTO theResponsableDTO)
        {
            bool respuesta = facade.Responsable.ValidaEliminacionResponsable(theResponsableDTO);
            return respuesta;
        }
    }
}
