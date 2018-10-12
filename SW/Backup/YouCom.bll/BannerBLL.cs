using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class BannerBLL
    {
        /// <summary>
        /// Lista Eventos Operacion 
        /// </summary>
        /// <param name="theUsuario"></param>
        /// <returns></returns>
        public static IList<BannerDTO> getListadoBanner()
        {
            var banner = YouCom.facade.Banner.getListadoBanner();
            return banner;
        }

        public static BannerDTO detalleBanner(decimal idBanner)
        {
            BannerDTO banner;
            banner = facade.Banner.getListadoBanner().Where(x => x.BannerId == idBanner).First();
            return banner;
        }

        public static IList<BannerDTO> listaBannerActivo()
        {
            IList<BannerDTO> banner;
            banner = facade.Banner.getListadoBanner().Where(x => x.Estado == "1").ToList();
            return banner;
        }

        public static IList<BannerDTO> listaBannerInactivo()
        {
            IList<BannerDTO> banner;
            banner = facade.Banner.getListadoBanner().Where(x => x.Estado == "2").ToList();
            return banner;
        }

        public static bool Delete(DTO.BannerDTO myBannerDTO)
        {
            bool resultado = BannerDAL.Delete(myBannerDTO);
            return resultado;
        }

        public static bool Insert(DTO.BannerDTO myBannerDTO)
        {
            bool resultado = BannerDAL.Insert(myBannerDTO);
            return resultado;
        }

        public static bool Update(DTO.BannerDTO myBannerDTO)
        {
            bool resultado = BannerDAL.Update(myBannerDTO);
            return resultado;
        }

        public static bool ActivaBanner(BannerDTO theBannerDTO)
        {
            bool respuesta = YouCom.DAL.BannerDAL.ActivaBanner(theBannerDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionBanner(BannerDTO theBannerDTO)
        {
            bool respuesta = facade.Banner.ValidaEliminacionBanner(theBannerDTO);
            return respuesta;
        }
    }
}
