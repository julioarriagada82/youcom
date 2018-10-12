using System.Collections.Generic;
using System.Linq;
using YouCom.DTO.Avisos;

namespace YouCom.bll.Avisos
{
    public class ImagenAvisoBLL
    {
        public static IList<ImagenAvisoDTO> getListadoImagenAviso()
        {
            var ImagenAviso = YouCom.facade.Avisos.ImagenAviso.getListadoImagenAviso();
            return ImagenAviso;
        }

        public static ImagenAvisoDTO detalleImagenAviso(decimal idImagenAviso)
        {
            ImagenAvisoDTO ImagenAviso;
            ImagenAviso = YouCom.facade.Avisos.ImagenAviso.getListadoImagenAviso().Where(x => x.IdImagenAviso == idImagenAviso).First();
            return ImagenAviso;
        }

        public static IList<ImagenAvisoDTO> getListadoImagenAvisoByIdAviso(decimal idAviso)
        {
            var mensajes = getListadoImagenAviso().Where(x => x.TheAvisosDTO.IdAviso == idAviso).ToList();
            return mensajes;
        }

        public static bool Delete(ImagenAvisoDTO myImagenAvisoDTO)
        {
            bool resultado = YouCom.DAL.Avisos.ImagenAvisoDAL.Delete(myImagenAvisoDTO);
            return resultado;
        }

        public static bool Insert(ImagenAvisoDTO myImagenAvisoDTO)
        {
            bool resultado = YouCom.DAL.Avisos.ImagenAvisoDAL.Insert(myImagenAvisoDTO);
            return resultado;
        }

        public static bool Update(ImagenAvisoDTO myImagenAvisoDTO)
        {
            bool resultado = YouCom.DAL.Avisos.ImagenAvisoDAL.Update(myImagenAvisoDTO);
            return resultado;
        }
    }
}
