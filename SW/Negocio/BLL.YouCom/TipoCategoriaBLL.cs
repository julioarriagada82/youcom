using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class TipoCategoriaBLL
    {
        public static IList<TipoCategoriaDTO> getListadoTipoCategoria()
        {
            YouCom.facade.TipoCategoria TipoCategoriaFA = new YouCom.facade.TipoCategoria();
            var TipoCategoria = YouCom.facade.TipoCategoria.getListadoTipoCategoria();
            return TipoCategoria;
        }

        public static TipoCategoriaDTO detalleTipoCategoria(decimal idTipoCategoria)
        {
            TipoCategoriaDTO TipoCategorias;
            TipoCategorias = facade.TipoCategoria.getListadoTipoCategoria().Where(x => x.IdTipoCategoria == idTipoCategoria).First();
            return TipoCategorias;
        }

        public static IList<TipoCategoriaDTO> listaTipoCategoriaActivo()
        {
            IList<TipoCategoriaDTO> TipoCategorias;
            TipoCategorias = facade.TipoCategoria.getListadoTipoCategoria().Where(x => x.Estado == "1").ToList();
            return TipoCategorias;
        }

        public static IList<TipoCategoriaDTO> listaTipoCategoriaInactivo()
        {
            IList<TipoCategoriaDTO> TipoCategorias;
            TipoCategorias = facade.TipoCategoria.getListadoTipoCategoria().Where(x => x.Estado == "2").ToList();
            return TipoCategorias;
        }

        public static bool Delete(DTO.TipoCategoriaDTO myTipoCategoriaDTO)
        {
            bool resultado = TipoCategoriaDAL.Delete(myTipoCategoriaDTO);
            return resultado;
        }

        public static bool Insert(DTO.TipoCategoriaDTO myTipoCategoriaDTO)
        {
            bool resultado = TipoCategoriaDAL.Insert(myTipoCategoriaDTO);
            return resultado;
        }

        public static bool Update(DTO.TipoCategoriaDTO myTipoCategoriaDTO)
        {
            bool resultado = TipoCategoriaDAL.Update(myTipoCategoriaDTO);
            return resultado;
        }

        public static bool ActivaTipoCategoria(TipoCategoriaDTO theTipoCategoriaDTO)
        {
            bool respuesta = TipoCategoriaDAL.ActivaTipoCategoria(theTipoCategoriaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionTipoCategoria(TipoCategoriaDTO theTipoCategoriaDTO)
        {
            bool respuesta = facade.TipoCategoria.ValidaEliminacionTipoCategoria(theTipoCategoriaDTO);
            return respuesta;
        }
    }
}
