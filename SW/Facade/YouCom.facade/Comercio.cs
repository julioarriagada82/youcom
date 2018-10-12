using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Comercio
    {
        public static IList<YouCom.DTO.ComercioDTO> getListadoComercio()
        {
            IList<YouCom.DTO.ComercioDTO> IComercio = new List<YouCom.DTO.ComercioDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ComercioDAL.getListadoComercio(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.ComercioDTO comercio = new YouCom.DTO.ComercioDTO();

                    comercio.IdComercio = decimal.Parse(wobjDataRow["IdComercio"].ToString());
                    
                    YouCom.DTO.CategoriaDTO myCategoriaDTO = new YouCom.DTO.CategoriaDTO();
                    myCategoriaDTO.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    comercio.TheCategoriaDTO = myCategoriaDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    comercio.TheCondominioDTO = myCondominio;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    comercio.TheComunidadDTO = myComunidadDTO;

                    comercio.NombreComercio = wobjDataRow["nombreComercio"].ToString();
                    comercio.LogoComercio = wobjDataRow["logoComercio"].ToString();
                    comercio.DireccionComercio = wobjDataRow["direccionComercio"].ToString();
                    comercio.TelefonoComercio = wobjDataRow["telefonoComercio"].ToString();
                    comercio.UrlComercio = string.IsNullOrEmpty(wobjDataRow["urlComercio"].ToString()) ? string.Empty : wobjDataRow["urlComercio"].ToString();
                    comercio.EmailComercio = string.IsNullOrEmpty(wobjDataRow["emailComercio"].ToString()) ? string.Empty : wobjDataRow["emailComercio"].ToString();

                    YouCom.DTO.ComunaDTO myComunaDTO = new YouCom.DTO.ComunaDTO();
                    myComunaDTO.IdComuna = decimal.Parse(wobjDataRow["idComuna"].ToString());
                    comercio.TheComunaDTO = myComunaDTO;

                    comercio.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    comercio.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    comercio.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    comercio.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    comercio.Estado = wobjDataRow["estado"].ToString();

                    IComercio.Add(comercio);
                }
            }

            return IComercio;

        }

        public static bool ValidaEliminacionComercio(YouCom.DTO.ComercioDTO theComercioDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.ComercioDAL.ValidaEliminacionComercio(theComercioDTO, ref pobjDataTable))
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
