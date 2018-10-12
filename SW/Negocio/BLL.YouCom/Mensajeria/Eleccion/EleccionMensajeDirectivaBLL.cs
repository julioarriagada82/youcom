using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Mensajeria;

namespace YouCom.bll.Mensajeria
{
    public class EleccionMensajeDirectivaBLL
    {
        public static IList<EleccionMensajeDirectivaDTO> getListadoEleccionMensajeDirectiva()
        {
            var EleccionMensajeDirectiva = YouCom.facade.Mensajeria.EleccionMensajeDirectiva.getListadoEleccionMensajeDirectiva();
            return EleccionMensajeDirectiva;
        }

        public static EleccionMensajeDirectivaDTO detalleEleccionMensajeDirectiva(decimal idEleccionMensajeDirectiva)
        {
            EleccionMensajeDirectivaDTO EleccionMensajeDirectivas;
            EleccionMensajeDirectivas = YouCom.facade.Mensajeria.EleccionMensajeDirectiva.getListadoEleccionMensajeDirectiva().Where(x => x.IdEleccionMensajeDirectiva == idEleccionMensajeDirectiva).First();
            return EleccionMensajeDirectivas;
        }

        public static IList<EleccionMensajeDirectivaDTO> getListadoEleccionMensajeDirectivaByIdMensaje(decimal idMensaje)
        {
            var mensajes = getListadoEleccionMensajeDirectiva().Where(x => x.TheMensajeDirectivaDTO.IdMensajeDirectiva == idMensaje).ToList();
            return mensajes;
        }

        public static EleccionMensajeDirectivaDTO getListadoEleccionMensajeDirectivaByIdFamilia(decimal idFamilia)
        {
            var mensajes = getListadoEleccionMensajeDirectiva().Where(x => x.TheFamiliaDTO.IdFamilia == idFamilia).FirstOrDefault();
            return mensajes;
        }

        public static EleccionMensajeDirectivaDTO getListadoEleccionMensajeDirectivaByIdFamilia(decimal idMensaje, decimal idFamilia)
        {
            var mensajes = getListadoEleccionMensajeDirectiva().Where(x => x.TheFamiliaDTO.IdFamilia == idFamilia && x.TheMensajeDirectivaDTO.IdMensajeDirectiva == idMensaje).FirstOrDefault();
            return mensajes;
        }

        public static bool Delete(EleccionMensajeDirectivaDTO myEleccionMensajeDirectivaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.EleccionMensajeDirectivaDAL.Delete(myEleccionMensajeDirectivaDTO);
            return resultado;
        }

        public static bool Insert(EleccionMensajeDirectivaDTO myEleccionMensajeDirectivaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.EleccionMensajeDirectivaDAL.Insert(myEleccionMensajeDirectivaDTO);
            return resultado;
        }

        public static bool Update(EleccionMensajeDirectivaDTO myEleccionMensajeDirectivaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.EleccionMensajeDirectivaDAL.Update(myEleccionMensajeDirectivaDTO);
            return resultado;
        }
    }
}
