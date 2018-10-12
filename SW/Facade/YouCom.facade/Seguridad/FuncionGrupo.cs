using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Seguridad;
using System.Data;

namespace YouCom.facade.Seguridad
{
    public class FuncionGrupo
    {
        public static bool ValidaEliminacionFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.Seguridad.DAL.FuncionGrupoDAL.ValidaEliminacionFuncionGrupo(theFuncionGrupoDTO, ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    retorno = true;

                }

            }
            return retorno;
        }
        public static List<FuncionGrupoDTO> ListadoFuncionGrupo()
        {
            DataTable pobjDataTable = new DataTable();
            YouCom.DTO.Seguridad.FuncionGrupoDTO theFuncionGrupoDTO;
            List<YouCom.DTO.Seguridad.FuncionGrupoDTO> collFuncionesGrupo=new List<FuncionGrupoDTO>();

            if (YouCom.Seguridad.DAL.FuncionGrupoDAL.ListadoFuncionGrupo(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    theFuncionGrupoDTO=new FuncionGrupoDTO();
                    theFuncionGrupoDTO.FuncionGrupoCod = wobjDataRow["FunciongrpCod"] != null ? wobjDataRow["FunciongrpCod"].ToString() : string.Empty;
                    theFuncionGrupoDTO.FuncionGrupoNombre = wobjDataRow["FuncionGrpNom"] != null ? wobjDataRow["FuncionGrpNom"].ToString() : string.Empty;
                    theFuncionGrupoDTO.UsuarioIngreso = wobjDataRow["usuarioingreso"] != null ? wobjDataRow["usuarioingreso"].ToString() : string.Empty;
                    theFuncionGrupoDTO.FechaIngreso = wobjDataRow["fechaingreso"] != null ? wobjDataRow["fechaingreso"].ToString() : string.Empty;
                    theFuncionGrupoDTO.UsuarioModificacion = wobjDataRow["usuariomodificacion"] != null ? wobjDataRow["usuariomodificacion"].ToString() : string.Empty;
                    theFuncionGrupoDTO.FechaModificacion = wobjDataRow["fechamodificacion"] != null ? wobjDataRow["fechamodificacion"].ToString() : string.Empty;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["empresa"].ToString());
                    theFuncionGrupoDTO.TheCondominioDTO = myCondominio;

                    theFuncionGrupoDTO.Estado = wobjDataRow["estado"] != null ? wobjDataRow["estado"].ToString() : string.Empty;
                    collFuncionesGrupo.Add(theFuncionGrupoDTO);
                }
            }
            return collFuncionesGrupo;

        }

        public static List<FuncionGrupoDTO> ListaGruposSistema()
        {
            DataTable pobjDataTable = new DataTable();
            YouCom.DTO.Seguridad.FuncionGrupoDTO theFuncionGrupoDTO;
            List<YouCom.DTO.Seguridad.FuncionGrupoDTO> collFuncionesGrupo = new List<FuncionGrupoDTO>();

            if (YouCom.Seguridad.DAL.FuncionGrupoDAL.ListaGruposSistema(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    theFuncionGrupoDTO = new FuncionGrupoDTO();
                    theFuncionGrupoDTO.FuncionGrupoCod = wobjDataRow["FunciongrpCod"] != null ? wobjDataRow["FunciongrpCod"].ToString() : string.Empty;
                    theFuncionGrupoDTO.FuncionGrupoNombre = wobjDataRow["FuncionGrpNom"] != null ? wobjDataRow["FuncionGrpNom"].ToString() : string.Empty;

                    collFuncionesGrupo.Add(theFuncionGrupoDTO);
                }
            }
            return collFuncionesGrupo;

        }
    }
}
