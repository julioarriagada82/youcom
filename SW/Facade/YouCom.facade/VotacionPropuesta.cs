using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade
{
    public class VotacionPropuesta
    {
        public static IList<YouCom.DTO.Propuesta.VotacionPropuestaDTO> getListadoVotacionPropuesta()
        {
            IList<YouCom.DTO.Propuesta.VotacionPropuestaDTO> IVotacionPropuesta = new List<YouCom.DTO.Propuesta.VotacionPropuestaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.VotacionPropuestaDAL.getListadoVotacionPropuesta(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Propuesta.VotacionPropuestaDTO votacion = new YouCom.DTO.Propuesta.VotacionPropuestaDTO();

                    votacion.IdVotacionPropuesta = decimal.Parse(wobjDataRow["idVotacionPropuesta"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    votacion.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    votacion.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propuesta.PropuestaDTO myPropuestaDTO = new YouCom.DTO.Propuesta.PropuestaDTO();
                    myPropuestaDTO.IdPropuesta = decimal.Parse(wobjDataRow["idPropuesta"].ToString());
                    myPropuestaDTO.NombrePropuesta = wobjDataRow["nombrePropuesta"].ToString();
                    myPropuestaDTO.DescripcionPropuesta = wobjDataRow["descripcionPropuesta"].ToString();

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamilia"].ToString();
                    myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamilia"].ToString();
                    myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamilia"].ToString();
                    myPropuestaDTO.TheFamiliaDTO = myFamiliaDTO;

                    votacion.ThePropuestaDTO = myPropuestaDTO;

                    YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO myVotacionPropuestaEstadoDTO = new YouCom.DTO.Propuesta.VotacionPropuestaEstadoDTO();
                    myVotacionPropuestaEstadoDTO.IdVotacionPropuestaEstado = decimal.Parse(wobjDataRow["idVotacionPropuestaEstado"].ToString());
                    myVotacionPropuestaEstadoDTO.NombreVotacionPropuestaEstado = wobjDataRow["nombreVotacionPropuestaEstado"].ToString();
                    votacion.TheVotacionPropuestaEstadoDTO = myVotacionPropuestaEstadoDTO;

                    votacion.FechaInicioVotacionPropuesta = Convert.ToDateTime(wobjDataRow["fechaInicioVotacionPropuesta"].ToString());
                    votacion.FechaTerminoVotacionPropuesta = Convert.ToDateTime(wobjDataRow["fechaTerminoVotacionPropuesta"].ToString());

                    votacion.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    votacion.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    votacion.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    votacion.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();
                    votacion.Estado = wobjDataRow["estado"].ToString();

                    IVotacionPropuesta.Add(votacion);
                }
            }

            return IVotacionPropuesta;

        }

        public static bool ValidaEliminacionPropuesta(YouCom.DTO.Propuesta.VotacionPropuestaDTO theVotacionPropuestaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.VotacionPropuestaDAL.ValidaEliminacionVotacionPropuesta(theVotacionPropuestaDTO, ref pobjDataTable))
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
