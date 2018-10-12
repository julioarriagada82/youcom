using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade
{
    public class EmpresaServicio
    {
        public static IList<YouCom.DTO.Servicio.EmpresaServicioDTO> getListadoEmpresaServicio()
        {
            IList<YouCom.DTO.Servicio.EmpresaServicioDTO> IEmpresaServicio = new List<YouCom.DTO.Servicio.EmpresaServicioDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.EmpresaServicioDAL.getListadoEmpresaServicio(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Servicio.EmpresaServicioDTO empresa_servicio = new YouCom.DTO.Servicio.EmpresaServicioDTO();

                    empresa_servicio.IdEmpresaServicio = decimal.Parse(wobjDataRow["idEmpresaServicio"].ToString());

                    YouCom.DTO.Servicio.ServiciosDTO myServiciosDTO = new YouCom.DTO.Servicio.ServiciosDTO();
                    myServiciosDTO.IdServicio = decimal.Parse(wobjDataRow["idServicios"].ToString());
                    myServiciosDTO.NombreServicio = wobjDataRow["nombreServicio"].ToString();
                    empresa_servicio.TheServiciosDTO = myServiciosDTO;

                    YouCom.DTO.GiroDTO myGiroDTO = new YouCom.DTO.GiroDTO();
                    myGiroDTO.IdGiro = decimal.Parse(wobjDataRow["idGiro"].ToString());
                    myGiroDTO.NombreGiro = wobjDataRow["nombreGiro"].ToString();
                    empresa_servicio.TheGiroDTO = myGiroDTO;

                    empresa_servicio.RutEmpresaServicio = wobjDataRow["RutEmpresaServicio"].ToString();
                    empresa_servicio.RazonSocialEmpresaServicio = wobjDataRow["razonSocialEmpresaServicio"].ToString();
                    empresa_servicio.DireccionEmpresaServicio = wobjDataRow["direccionEmpresaServicio"].ToString();

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
                    
                    empresa_servicio.TheComunaDTO = myComunaDTO;

                    empresa_servicio.TelefonoEmpresaServicio = wobjDataRow["telefonoEmpresaServicio"].ToString();
                    empresa_servicio.CelularEmpresaServicio = wobjDataRow["telefonoEmpresaServicio"].ToString();
                    empresa_servicio.EmailEmpresaServicio = wobjDataRow["emailEmpresaServicio"].ToString();
                    empresa_servicio.UrlEmpresaServicio = wobjDataRow["urlEmpresaServicio"].ToString();
                    empresa_servicio.LogoEmpresaServicio = wobjDataRow["logoEmpresaServicio"].ToString();

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    empresa_servicio.TheCondominioDTO = myCondominio;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    empresa_servicio.TheComunidadDTO = myComunidadDTO;

                    empresa_servicio.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    empresa_servicio.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    empresa_servicio.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    empresa_servicio.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    empresa_servicio.Estado = wobjDataRow["estado"].ToString();

                    IEmpresaServicio.Add(empresa_servicio);
                }
            }

            return IEmpresaServicio;

        }

        public static bool ValidaEliminacionEmpresaServicio(YouCom.DTO.Servicio.EmpresaServicioDTO theEmpresaServicioDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.EmpresaServicioDAL.ValidaEliminacionEmpresaServicio(theEmpresaServicioDTO, ref pobjDataTable))
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
