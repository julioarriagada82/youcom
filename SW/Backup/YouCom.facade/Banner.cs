using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Banner
    {
        public static IList<YouCom.DTO.BannerDTO> getListadoBanner()
        {
            IList<YouCom.DTO.BannerDTO> IBanner = new List<YouCom.DTO.BannerDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.BannerDAL.getListadoBanner(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.BannerDTO banner = new YouCom.DTO.BannerDTO();

                    banner.BannerId = decimal.Parse(wobjDataRow["banner_id"].ToString());
                    banner.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    banner.BannerNombre = wobjDataRow["banner_nombre"].ToString();
                    banner.BannerDescripcion = wobjDataRow["banner_descripcion"].ToString();
                    banner.BannerImagen = wobjDataRow["banner_imagen"].ToString();
                    banner.BannerTipoDespliegue = wobjDataRow["banner_tipo_despliegue"].ToString();
                    banner.BannerLink = wobjDataRow["banner_link"].ToString();
                    banner.BannerTarget = wobjDataRow["banner_target"].ToString();
                    banner.BannerArchivo = wobjDataRow["banner_archivo"].ToString();

                    banner.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    banner.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    banner.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    banner.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    banner.Estado = wobjDataRow["estado"].ToString();

                    IBanner.Add(banner);
                }
            }

            return IBanner;

        }

        public static bool ValidaEliminacionBanner(YouCom.DTO.BannerDTO theBannerDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.BannerDAL.ValidaEliminacionBanner(theBannerDTO, ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    retorno = true;
                }
            }

            return retorno;
        }
    }
}
