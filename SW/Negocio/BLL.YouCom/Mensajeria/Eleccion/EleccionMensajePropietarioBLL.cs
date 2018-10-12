using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Mensajeria;

namespace YouCom.bll.Mensajeria
{
    public class EleccionMensajePropietarioBLL
    {
        public static IList<EleccionMensajePropietarioDTO> getListadoEleccionMensajePropietario()
        {
            var EleccionMensajePropietario = YouCom.facade.Mensajeria.EleccionMensajePropietario.getListadoEleccionMensajePropietario();
            return EleccionMensajePropietario;
        }

        public static EleccionMensajePropietarioDTO detalleEleccionMensajePropietario(decimal idEleccionMensajePropietario)
        {
            EleccionMensajePropietarioDTO EleccionMensajePropietarios;
            EleccionMensajePropietarios = YouCom.facade.Mensajeria.EleccionMensajePropietario.getListadoEleccionMensajePropietario().Where(x => x.IdEleccionMensajePropietario == idEleccionMensajePropietario).First();
            return EleccionMensajePropietarios;
        }

        public static IList<EleccionMensajePropietarioDTO> getListadoEleccionMensajePropietarioByIdMensaje(decimal idMensaje)
        {
            var mensajes = getListadoEleccionMensajePropietario().Where(x => x.TheMensajePropietarioDTO.IdMensajePropietario == idMensaje).ToList();
            return mensajes;
        }

        public static EleccionMensajePropietarioDTO getListadoEleccionMensajePropietarioByIdFamilia(decimal idFamilia)
        {
            var mensajes = getListadoEleccionMensajePropietario().Where(x => x.TheFamiliaDTO.IdFamilia == idFamilia).FirstOrDefault();
            return mensajes;
        }

        public static EleccionMensajePropietarioDTO getListadoEleccionMensajePropietarioByIdFamilia(decimal idMensaje, decimal idFamilia)
        {
            var mensajes = getListadoEleccionMensajePropietario().Where(x => x.TheFamiliaDTO.IdFamilia == idFamilia && x.TheMensajePropietarioDTO.IdMensajePropietario == idMensaje).FirstOrDefault();
            return mensajes;
        }

        public static bool Delete(EleccionMensajePropietarioDTO myEleccionMensajePropietarioDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.EleccionMensajePropietarioDAL.Delete(myEleccionMensajePropietarioDTO);
            return resultado;
        }

        public static bool Insert(EleccionMensajePropietarioDTO myEleccionMensajePropietarioDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.EleccionMensajePropietarioDAL.Insert(myEleccionMensajePropietarioDTO);
            return resultado;
        }

        public static bool Update(EleccionMensajePropietarioDTO myEleccionMensajePropietarioDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.EleccionMensajePropietarioDAL.Update(myEleccionMensajePropietarioDTO);
            return resultado;
        }
    }
}
