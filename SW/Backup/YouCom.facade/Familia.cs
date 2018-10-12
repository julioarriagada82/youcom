using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class Familia
    {
        public static IList<YouCom.DTO.FamiliaDTO> getListadoFamilia()
        {
            IList<YouCom.DTO.FamiliaDTO> IFamilia = new List<YouCom.DTO.FamiliaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.FamiliaDAL.getListadoFamilia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.FamiliaDTO familia = new YouCom.DTO.FamiliaDTO();

                    familia.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    familia.IdCasa = decimal.Parse(wobjDataRow["idCasa"].ToString());
                    familia.IdOcupacion = decimal.Parse(wobjDataRow["idOcupacion"].ToString());
                    familia.RutFamilia = wobjDataRow["rutFamilia"].ToString();
                    familia.NombreFamilia = wobjDataRow["nombreFamilia"].ToString();
                    familia.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamilia"].ToString();
                    familia.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamilia"].ToString();
                    familia.IdParentescoFamilia = decimal.Parse(wobjDataRow["idParentesco"].ToString());
                    familia.CelularFamilia = wobjDataRow["celularFamilia"].ToString();
                    familia.TelefonoFamilia = wobjDataRow["telefonoFamilia"].ToString();
                    familia.EmailFamilia = wobjDataRow["emailFamilia"].ToString();

                    familia.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    familia.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    familia.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    familia.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();
                    familia.Estado = wobjDataRow["estado"].ToString();

                    IFamilia.Add(familia);
                }
            }

            return IFamilia;

        }

        public static bool ValidaEliminacionFamilia(YouCom.DTO.FamiliaDTO theFamiliaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.FamiliaDAL.ValidaEliminacionFamilia(theFamiliaDTO, ref pobjDataTable))
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
