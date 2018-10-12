using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class CategoriaBLL
    {
        public static IList<CategoriaDTO> getListadoCategoria()
        {
            YouCom.facade.Categoria CategoriaFA = new YouCom.facade.Categoria();
            var Categoria = YouCom.facade.Categoria.getListadoCategoria();
            return Categoria;
        }

        public static CategoriaDTO detalleCategoria(decimal idCategoria)
        {
            CategoriaDTO Categorias;
            Categorias = facade.Categoria.getListadoCategoria().Where(x => x.IdCategoria == idCategoria).First();
            return Categorias;
        }

        public static IList<CategoriaDTO> getListadoCategoriaByCondominioByComunidad(decimal idCondominio, decimal idComunidad)
        {
            var categorias = listaCategoriaActivo().Where(x => x.TheCondominioDTO.IdCondominio == idCondominio && x.TheComunidadDTO.IdComunidad == idComunidad).ToList();
            return categorias;
        }

        public static IList<CategoriaDTO> listaCategoriaActivo()
        {
            IList<CategoriaDTO> Categorias;
            Categorias = facade.Categoria.getListadoCategoria().Where(x => x.Estado == "1").ToList();
            return Categorias;
        }

        public static IList<CategoriaDTO> listaCategoriaInactivo()
        {
            IList<CategoriaDTO> Categorias;
            Categorias = facade.Categoria.getListadoCategoria().Where(x => x.Estado == "2").ToList();
            return Categorias;
        }

        public static bool Delete(DTO.CategoriaDTO myCategoriaDTO)
        {
            bool resultado = CategoriaDAL.Delete(myCategoriaDTO);
            return resultado;
        }

        public static bool Insert(DTO.CategoriaDTO myCategoriaDTO)
        {
            bool resultado = CategoriaDAL.Insert(myCategoriaDTO);
            return resultado;
        }

        public static bool Update(DTO.CategoriaDTO myCategoriaDTO)
        {
            bool resultado = CategoriaDAL.Update(myCategoriaDTO);
            return resultado;
        }

        public static bool ActivaCategoria(CategoriaDTO theCategoriaDTO)
        {
            bool respuesta = CategoriaDAL.ActivaCategoria(theCategoriaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionCategoria(CategoriaDTO theCategoriaDTO)
        {
            bool respuesta = facade.Categoria.ValidaEliminacionCategoria(theCategoriaDTO);
            return respuesta;
        }
    }
}
