using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.facade
{
    public class Proyecto
    {
        public static IList<YouCom.DTO.ProyectoDTO> getListadoProyecto()
        {
            IList<YouCom.DTO.ProyectoDTO> IProyecto = new List<YouCom.DTO.ProyectoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ProyectoDAL.getListadoProyecto(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.ProyectoDTO proyecto = new YouCom.DTO.ProyectoDTO();

                    proyecto.IdProyecto = decimal.Parse(wobjDataRow["idProyecto"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    proyecto.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    proyecto.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propuesta.PropuestaDTO myPropuestaDTO = new YouCom.DTO.Propuesta.PropuestaDTO();
                    myPropuestaDTO.IdPropuesta = decimal.Parse(wobjDataRow["idPropuesta"].ToString());
                    myPropuestaDTO.NombrePropuesta = wobjDataRow["nombrePropuesta"].ToString();
                    proyecto.ThePropuestaDTO = myPropuestaDTO;

                    proyecto.NombreProyecto = wobjDataRow["nombreProyecto"].ToString();
                    proyecto.DescripcionProyecto = wobjDataRow["descripcionProyecto"].ToString();
                    proyecto.FechaInicioProyecto = Convert.ToDateTime(wobjDataRow["fechaInicioProyecto"].ToString());
                    proyecto.FechaTerminoProyecto = Convert.ToDateTime(wobjDataRow["fechaTerminoProyecto"].ToString());
                    proyecto.FechaEntregaProyecto = Convert.ToDateTime(wobjDataRow["fechaEntregaProyecto"].ToString());
                    proyecto.PresupuestoProyecto = decimal.Parse(wobjDataRow["presupuestoProyecto"].ToString());
                    proyecto.DireccionProyecto = wobjDataRow["direccionProyecto"].ToString();

                    YouCom.DTO.EmpresaContratistaDTO myEmpresaContratistaDTO = new YouCom.DTO.EmpresaContratistaDTO();
                    myEmpresaContratistaDTO.IdEmpresaContratista = decimal.Parse(wobjDataRow["idEmpresaContratista"].ToString());
                    proyecto.TheEmpresaContratistaDTO = myEmpresaContratistaDTO;

                    YouCom.DTO.ProyectoEstadoDTO myProyectoEstadoDTO = new YouCom.DTO.ProyectoEstadoDTO();
                    myProyectoEstadoDTO.IdProyectoEstado = decimal.Parse(wobjDataRow["idProyectoEstado"].ToString());
                    myProyectoEstadoDTO.NombreProyectoEstado = wobjDataRow["nombreProyectoEstado"].ToString();
                    proyecto.TheProyectoEstadoDTO = myProyectoEstadoDTO;

                    proyecto.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    proyecto.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    proyecto.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    proyecto.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();
                    proyecto.Estado = wobjDataRow["estado"].ToString();

                    IProyecto.Add(proyecto);
                }
            }

            return IProyecto;

        }

        public static bool ValidaEliminacionProyecto(YouCom.DTO.ProyectoDTO theProyectoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.ProyectoDAL.ValidaEliminacionProyecto(theProyectoDTO, ref pobjDataTable))
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
