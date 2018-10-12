using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Mensajeria.Imagen;

namespace YouCom.bll.Mensajeria.Imagen
{
    public class ImagenMensajePropietarioBLL
    {
        public static IList<ImagenMensajePropietarioDTO> getListadoImagenMensajePropietario()
        {
            var ImagenMensajePropietario = YouCom.facade.Mensajeria.Imagen.ImagenMensajePropietario.getListadoImagenMensajePropietario();
            return ImagenMensajePropietario;
        }

        public static ImagenMensajePropietarioDTO detalleImagenMensajePropietario(decimal idImagenMensajePropietario)
        {
            ImagenMensajePropietarioDTO ImagenMensajePropietarios;
            ImagenMensajePropietarios = YouCom.facade.Mensajeria.Imagen.ImagenMensajePropietario.getListadoImagenMensajePropietario().Where(x => x.IdImagenMensajePropietario == idImagenMensajePropietario).First();
            return ImagenMensajePropietarios;
        }

        public static IList<ImagenMensajePropietarioDTO> getListadoImagenMensajePropietarioByIdMensaje(decimal idMensaje)
        {
            var mensajes = getListadoImagenMensajePropietario().Where(x => x.TheMensajePropietarioDTO.IdMensajePropietario == idMensaje).ToList();
            return mensajes;
        }

        public static ImagenMensajePropietarioDTO getListadoImagenMensajePropietarioByIdFamilia(decimal idMensaje)
        {
            var mensajes = getListadoImagenMensajePropietario().Where(x => x.TheMensajePropietarioDTO.IdMensajePropietario == idMensaje).FirstOrDefault();
            return mensajes;
        }

        public static bool Delete(ImagenMensajePropietarioDTO myImagenMensajePropietarioDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Imagen.ImagenMensajePropietarioDAL.Delete(myImagenMensajePropietarioDTO);
            return resultado;
        }

        public static bool Insert(ImagenMensajePropietarioDTO myImagenMensajePropietarioDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Imagen.ImagenMensajePropietarioDAL.Insert(myImagenMensajePropietarioDTO);
            return resultado;
        }

        public static bool Update(ImagenMensajePropietarioDTO myImagenMensajePropietarioDTO)
        {
            bool resultado = YouCom.Mensajeria.DAL.Imagen.ImagenMensajePropietarioDAL.Update(myImagenMensajePropietarioDTO);
            return resultado;
        }
    }
}
