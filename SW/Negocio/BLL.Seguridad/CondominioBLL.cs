using System.Collections.Generic;
using System.Linq;
using YouCom.DTO.Seguridad;

namespace YouCom.Seguridad.BLL
{
    public class CondominioBLL
    {
        public static bool Insert(CondominioDTO theCondominioDTO)
        {
            var resultado = YouCom.Seguridad.DAL.CondominioDAL.Insert(theCondominioDTO);
            return resultado;
        }
        public static bool Update(CondominioDTO theCondominioDTO)
        {
            var resultado = YouCom.Seguridad.DAL.CondominioDAL.Update(theCondominioDTO);
            return resultado;
        }
        public static bool Delete(CondominioDTO theCondominioDTO)
        {
            var resultado = YouCom.Seguridad.DAL.CondominioDAL.Delete(theCondominioDTO);
            return resultado;
        }
        public static IList<CondominioDTO> getListadoCondominio()
        {
            var resultado = YouCom.facade.Seguridad.Condominio.getListadoCondominio();
            return resultado;
        }
        
        public static IList<CondominioDTO> listaCategoriaActivo()
        {
            IList<CondominioDTO> condominio;
            condominio = YouCom.facade.Seguridad.Condominio.getListadoCondominio().Where(x => x.Estado == "1").ToList();
            return condominio;
        }

        public static IList<CondominioDTO> listaCategoriaInactivo()
        {
            IList<CondominioDTO> Categorias;
            Categorias = YouCom.facade.Seguridad.Condominio.getListadoCondominio().Where(x => x.Estado == "2").ToList();
            return Categorias;
        }
    }
}
