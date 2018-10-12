using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade
{
    public class EmpresaContratista
    {
        public static IList<YouCom.DTO.EmpresaContratistaDTO> getListadoEmpresaContratista()
        {
            IList<YouCom.DTO.EmpresaContratistaDTO> IEmpresaContratista = new List<YouCom.DTO.EmpresaContratistaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.EmpresaContratistaDAL.getListadoEmpresaContratista(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.EmpresaContratistaDTO empresa_contratista = new YouCom.DTO.EmpresaContratistaDTO();

                    empresa_contratista.IdEmpresaContratista = decimal.Parse(wobjDataRow["idEmpresaContratista"].ToString());

                    YouCom.DTO.GiroDTO myGiroDTO = new YouCom.DTO.GiroDTO();
                    myGiroDTO.IdGiro = decimal.Parse(wobjDataRow["idGiro"].ToString());
                    myGiroDTO.NombreGiro = wobjDataRow["nombreGiro"].ToString();
                    empresa_contratista.TheGiroDTO = myGiroDTO;

                    empresa_contratista.RutCondominioContratista = wobjDataRow["RutCondominioContratista"].ToString();
                    empresa_contratista.RazonSocialEmpresaContratista = wobjDataRow["razonSocialEmpresaContratista"].ToString();
                    empresa_contratista.DireccionEmpresaContratista = wobjDataRow["direccionEmpresaContratista"].ToString();

                    YouCom.DTO.ComunaDTO myComunaDTO = new YouCom.DTO.ComunaDTO();
                    myComunaDTO.IdComuna = decimal.Parse(wobjDataRow["idComuna"].ToString());

                    YouCom.DTO.CiudadDTO myCiudadDTO = new YouCom.DTO.CiudadDTO();
                    myCiudadDTO.IdCiudad = decimal.Parse(wobjDataRow["idCiudad"].ToString());

                    YouCom.DTO.RegionDTO myRegionDTO = new YouCom.DTO.RegionDTO();
                    myRegionDTO.IdRegion = decimal.Parse(wobjDataRow["idRegion"].ToString());

                    YouCom.DTO.PaisDTO myPaisDTO = new YouCom.DTO.PaisDTO();
                    myPaisDTO.IdPais = decimal.Parse(wobjDataRow["idPais"].ToString());

                    myComunaDTO.TheCiudadDTO = myCiudadDTO;
                    myCiudadDTO.TheRegionDTO = myRegionDTO;
                    myRegionDTO.ThePaisDTO = myPaisDTO;

                    empresa_contratista.TheComunaDTO = myComunaDTO;

                    empresa_contratista.TelefonoEmpresaContratista = wobjDataRow["telefonoEmpresaContratista"].ToString();
                    empresa_contratista.CelularEmpresaContratista = wobjDataRow["celularEmpresaContratista"].ToString();
                    empresa_contratista.EmailEmpresaContratista = wobjDataRow["emailEmpresaContratista"].ToString();
                    empresa_contratista.UrlEmpresaContratista = wobjDataRow["urlEmpresaContratista"].ToString();
                    empresa_contratista.LogoEmpresaContratista = wobjDataRow["logoEmpresaContratista"].ToString();

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    empresa_contratista.TheCondominioDTO = myCondominio;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    empresa_contratista.TheComunidadDTO = myComunidadDTO;

                    empresa_contratista.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    empresa_contratista.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    empresa_contratista.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    empresa_contratista.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    empresa_contratista.Estado = wobjDataRow["estado"].ToString();

                    IEmpresaContratista.Add(empresa_contratista);
                }
            }

            return IEmpresaContratista;

        }

        public static bool ValidaEliminacionEmpresaContratista(YouCom.DTO.EmpresaContratistaDTO theEmpresaContratistaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.EmpresaContratistaDAL.ValidaEliminacionEmpresaContratista(theEmpresaContratistaDTO, ref pobjDataTable))
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
