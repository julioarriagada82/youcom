using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Parentesco
    {
        public static IList<YouCom.DTO.Propietario.ParentescoDTO> getListadoParentesco()
        {
            IList<YouCom.DTO.Propietario.ParentescoDTO> IParentesco = new List<YouCom.DTO.Propietario.ParentescoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.Propietario.ParentescoDAL.getListadoParentesco(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Propietario.ParentescoDTO parentesco = new YouCom.DTO.Propietario.ParentescoDTO();

                    parentesco.IdParentesco = decimal.Parse(wobjDataRow["IdParentesco"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    parentesco.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    parentesco.TheComunidadDTO = myComunidadDTO;

                    parentesco.NombreParentesco = wobjDataRow["nombreParentesco"].ToString();

                    parentesco.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    parentesco.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    parentesco.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    parentesco.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    parentesco.Estado = wobjDataRow["estado"].ToString();

                    IParentesco.Add(parentesco);
                }
            }

            return IParentesco;

        }

        public static bool ValidaEliminacionParentesco(YouCom.DTO.Propietario.ParentescoDTO theParentescoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.Propietario.ParentescoDAL.ValidaEliminacionParentesco(theParentescoDTO, ref pobjDataTable))
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
