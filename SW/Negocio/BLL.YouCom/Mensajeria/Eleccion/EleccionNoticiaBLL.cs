using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Mensajeria;

namespace YouCom.bll.Mensajeria
{
    public class EleccionNoticiaBLL
    {
        public static IList<EleccionNoticiaDTO> getListadoEleccionNoticia()
        {
            var EleccionNoticia = YouCom.facade.Mensajeria.EleccionNoticia.getListadoEleccionNoticia();
            return EleccionNoticia;
        }

        public static EleccionNoticiaDTO detalleEleccionNoticia(decimal idEleccionNoticia)
        {
            EleccionNoticiaDTO EleccionNoticias;
            EleccionNoticias = YouCom.facade.Mensajeria.EleccionNoticia.getListadoEleccionNoticia().Where(x => x.IdEleccionNoticia == idEleccionNoticia).First();
            return EleccionNoticias;
        }

        public static IList<EleccionNoticiaDTO> getListadoEleccionNoticiaByIdNoticia(decimal idNoticia)
        {
            var mensajes = getListadoEleccionNoticia().Where(x => x.TheNoticiaDTO.NoticiaId == idNoticia).ToList();
            return mensajes;
        }

        public static EleccionNoticiaDTO getListadoEleccionNoticiaByIdFamilia(decimal idFamilia)
        {
            var mensajes = getListadoEleccionNoticia().Where(x => x.TheFamiliaDTO.IdFamilia == idFamilia).FirstOrDefault();
            return mensajes;
        }

        public static EleccionNoticiaDTO getListadoEleccionNoticiaByIdFamilia(decimal idNoticia, decimal idFamilia)
        {
            var mensajes = getListadoEleccionNoticia().Where(x => x.TheFamiliaDTO.IdFamilia == idFamilia && x.TheNoticiaDTO.NoticiaId == idNoticia).FirstOrDefault();
            return mensajes;
        }

        public static bool Delete(EleccionNoticiaDTO myEleccionNoticiaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.EleccionNoticiaDAL.Delete(myEleccionNoticiaDTO);
            return resultado;
        }

        public static bool Insert(EleccionNoticiaDTO myEleccionNoticiaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.EleccionNoticiaDAL.Insert(myEleccionNoticiaDTO);
            return resultado;
        }

        public static bool Update(EleccionNoticiaDTO myEleccionNoticiaDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.EleccionNoticiaDAL.Update(myEleccionNoticiaDTO);
            return resultado;
        }
    }
}
