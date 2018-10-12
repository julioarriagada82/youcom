using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade
{
    public class Propuesta
    {
        public static IList<YouCom.DTO.Propuesta.PropuestaDTO> getListadoPropuesta()
        {
            IList<YouCom.DTO.Propuesta.PropuestaDTO> IPropuesta = new List<YouCom.DTO.Propuesta.PropuestaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.PropuestaDAL.getListadoPropuesta(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Propuesta.PropuestaDTO Propuesta = new YouCom.DTO.Propuesta.PropuestaDTO();

                    Propuesta.IdPropuesta = decimal.Parse(wobjDataRow["idPropuesta"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    Propuesta.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    Propuesta.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    myFamiliaDTO.NombreFamilia = wobjDataRow["nombreFamilia"].ToString();
                    myFamiliaDTO.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamilia"].ToString();
                    myFamiliaDTO.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamilia"].ToString();
                    Propuesta.TheFamiliaDTO = myFamiliaDTO;

                    YouCom.DTO.PropuestaEstadoDTO myPropuestaEstadoDTO = new YouCom.DTO.PropuestaEstadoDTO();
                    myPropuestaEstadoDTO.IdPropuestaEstado = decimal.Parse(wobjDataRow["idPropuestaEstado"].ToString());
                    myPropuestaEstadoDTO.NombrePropuestaEstado = wobjDataRow["nombrePropuestaEstado"].ToString();
                    Propuesta.ThePropuestaEstadoDTO = myPropuestaEstadoDTO;

                    Propuesta.NombrePropuesta = wobjDataRow["nombrePropuesta"].ToString();
                    Propuesta.DescripcionPropuesta = wobjDataRow["descripcionPropuesta"].ToString();
                    Propuesta.FechaPropuesta = Convert.ToDateTime(wobjDataRow["fechaPropuesta"].ToString());
                    Propuesta.DireccionPropuesta = wobjDataRow["direccionPropuesta"].ToString();
                    
                    Propuesta.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    Propuesta.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    Propuesta.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    Propuesta.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();
                    Propuesta.Estado = wobjDataRow["estado"].ToString();

                    IPropuesta.Add(Propuesta);
                }
            }

            return IPropuesta;

        }

        public static bool ValidaEliminacionPropuesta(YouCom.DTO.Propuesta.PropuestaDTO thePropuestaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.PropuestaDAL.ValidaEliminacionPropuesta(thePropuestaDTO, ref pobjDataTable))
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
