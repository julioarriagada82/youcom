using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Mensajeria;
using YouCom.Mensajeria.DAL;

namespace YouCom.bll.Mensajeria
{
    public class EleccionMensajePorteriaBLL
    {
        public static IList<EleccionMensajePorteriaDTO> getListadoEleccionMensajePorteria()
        {
            var EleccionMensajePorteria = YouCom.facade.Mensajeria.EleccionMensajePorteria.getListadoEleccionMensajePorteria();
            return EleccionMensajePorteria;
        }

        public static EleccionMensajePorteriaDTO detalleEleccionMensajePorteria(decimal idEleccionMensajePorteria)
        {
            EleccionMensajePorteriaDTO EleccionMensajePorterias;
            EleccionMensajePorterias = YouCom.facade.Mensajeria.EleccionMensajePorteria.getListadoEleccionMensajePorteria().Where(x => x.IdEleccionMensajePorteria == idEleccionMensajePorteria).First();
            return EleccionMensajePorterias;
        }

        public static IList<EleccionMensajePorteriaDTO> getListadoEleccionMensajePorteriaByIdMensaje(decimal idMensaje)
        {
            var mensajes = getListadoEleccionMensajePorteria().Where(x => x.TheMensajePorteriaDTO.IdMensajePorteria == idMensaje).ToList();
            return mensajes;
        }

        public static EleccionMensajePorteriaDTO getListadoEleccionMensajePorteriaByIdFamilia(decimal idFamilia)
        {
            var mensajes = getListadoEleccionMensajePorteria().Where(x => x.TheFamiliaDTO.IdFamilia == idFamilia).FirstOrDefault();
            return mensajes;
        }

        public static EleccionMensajePorteriaDTO getListadoEleccionMensajePorteriaByIdFamilia(decimal idMensaje, decimal idFamilia)
        {
            var mensajes = getListadoEleccionMensajePorteria().Where(x => x.TheFamiliaDTO.IdFamilia == idFamilia && x.TheMensajePorteriaDTO.IdMensajePorteria == idMensaje).FirstOrDefault();
            return mensajes;
        }

        public static bool Delete(EleccionMensajePorteriaDTO myEleccionMensajePorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.EleccionMensajePorteriaDAL.Delete(myEleccionMensajePorteriaDTO);
            return resultado;
        }

        public static bool Insert(EleccionMensajePorteriaDTO myEleccionMensajePorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.EleccionMensajePorteriaDAL.Insert(myEleccionMensajePorteriaDTO);
            return resultado;
        }

        public static bool Update(EleccionMensajePorteriaDTO myEleccionMensajePorteriaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.EleccionMensajePorteriaDAL.Update(myEleccionMensajePorteriaDTO);
            return resultado;
        }
    }
}
