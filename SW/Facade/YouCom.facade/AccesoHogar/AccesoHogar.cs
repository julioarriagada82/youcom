using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using YouCom.DTO;

namespace YouCom.facade.AccesoHogar
{
    public class AccesoHogar
    {
        public static IList<YouCom.DTO.AccesoHogar.AccesoHogarDTO> getListadoAccesoHogar()
        {
            IList<YouCom.DTO.AccesoHogar.AccesoHogarDTO> IAccesoHogar = new List<YouCom.DTO.AccesoHogar.AccesoHogarDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.AccesoHogar.AccesoHogarDAL.getListadoAccesoHogar(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.AccesoHogar.AccesoHogarDTO accesoHogar = new YouCom.DTO.AccesoHogar.AccesoHogarDTO();

                    accesoHogar.IdAccesoHogar = decimal.Parse(wobjDataRow["IdAccesoHogar"].ToString());

                    DTO.Propietario.CasaDTO myCasa = new DTO.Propietario.CasaDTO();
                    myCasa.IdCasa = decimal.Parse(wobjDataRow["idCasa"].ToString());
                    accesoHogar.TheCasaDTO = myCasa;

                    YouCom.DTO.AccesoHogar.TipoVisitaDTO myTipoVisita = new YouCom.DTO.AccesoHogar.TipoVisitaDTO();
                    myTipoVisita.IdTipoVisita = decimal.Parse(wobjDataRow["idTipoVisita"].ToString());
                    myTipoVisita.NombreTipoVisita = wobjDataRow["nombreTipoVisita"].ToString();
                    accesoHogar.TheTipoVisitaDTO = myTipoVisita;

                    YouCom.DTO.AccesoHogar.FrecuenciaDTO myFrecuencia = new YouCom.DTO.AccesoHogar.FrecuenciaDTO();
                    myFrecuencia.IdFrecuencia = decimal.Parse(wobjDataRow["idFrecuencia"].ToString());
                    myFrecuencia.NombreFrecuencia = wobjDataRow["nombreFrecuencia"].ToString();
                    accesoHogar.TheFrecuenciaDTO = myFrecuencia;

                    DTO.Propietario.FamiliaDTO myFamilia = new DTO.Propietario.FamiliaDTO();
                    myFamilia.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    myFamilia.RutFamilia = wobjDataRow["rutFamilia"].ToString();
                    myFamilia.NombreFamilia = wobjDataRow["nombreFamilia"].ToString();
                    myFamilia.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamilia"].ToString();
                    myFamilia.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamilia"].ToString();
                    accesoHogar.TheFamiliaDTO = myFamilia;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    accesoHogar.TheCondominioDTO = myCondominio;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    accesoHogar.TheComunidadDTO = myComunidadDTO;

                    accesoHogar.FechaInicio = DateTime.Parse(wobjDataRow["FechaInicio"].ToString());
                    accesoHogar.FechaTermino = DateTime.Parse(wobjDataRow["fechaTermino"].ToString());

                    accesoHogar.HoraInicio = wobjDataRow["HoraInicio"].ToString();
                    accesoHogar.HoraTermino = wobjDataRow["HoraTermino"].ToString();

                    accesoHogar.NombreVisita = wobjDataRow["nombreVisita"].ToString();
                    accesoHogar.ApellidoPaternoVisita = wobjDataRow["apellidoPaternoVisita"].ToString();
                    accesoHogar.ApellidoMaternoVisita = wobjDataRow["apellidoMaternoVisita"].ToString();

                    accesoHogar.RutVisita = wobjDataRow["rutVisita"].ToString();
                    accesoHogar.EmailVisita = wobjDataRow["emailVisita"].ToString();
                    accesoHogar.Avisar = wobjDataRow["avisar"].ToString();

                    accesoHogar.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    accesoHogar.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    accesoHogar.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    accesoHogar.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    accesoHogar.Estado = wobjDataRow["estado"].ToString();

                    IAccesoHogar.Add(accesoHogar);
                }
            }

            return IAccesoHogar;

        }

        public static bool ValidaEliminacionAccesoHogar(YouCom.DTO.AccesoHogar.AccesoHogarDTO theAccesoHogarDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.AccesoHogar.AccesoHogarDAL.ValidaEliminacionAccesoHogar(theAccesoHogarDTO, ref pobjDataTable))
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
