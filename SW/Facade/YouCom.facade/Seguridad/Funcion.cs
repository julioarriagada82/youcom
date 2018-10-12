using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Seguridad;
using System.Data;

namespace YouCom.facade.Seguridad
{
    public class Funcion
    {

        public static List<FuncionDTO> ListaFunciones(int FuncionGrupo)
        {
            DataTable pobjDataTable = new DataTable();
            YouCom.DTO.Seguridad.FuncionDTO theFuncionDTO;
            List<YouCom.DTO.Seguridad.FuncionDTO> collFunciones = new List<FuncionDTO>();

            if (YouCom.Seguridad.DAL.FuncionDAL.ListaFunciones(FuncionGrupo, ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    theFuncionDTO = new FuncionDTO();
                    theFuncionDTO.FuncionCod = wobjDataRow["FuncionCod"] != null ? wobjDataRow["FuncionCod"].ToString() : string.Empty;
                    theFuncionDTO.FuncionNombre = wobjDataRow["FuncionNom"] != null ? wobjDataRow["FuncionNom"].ToString() : string.Empty;
                    collFunciones.Add(theFuncionDTO);
                }
            }
            return collFunciones;
        }

        public static List<FuncionDTO> ListaFuncionGrupoSistema()
        {
            DataTable pobjDataTable = new DataTable();
            YouCom.DTO.Seguridad.FuncionDTO theFuncionDTO;
            List<YouCom.DTO.Seguridad.FuncionDTO> collFunciones = new List<FuncionDTO>();

            if (YouCom.Seguridad.DAL.FuncionDAL.ListaFuncionGrupoSistema(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    theFuncionDTO = new FuncionDTO();
                    theFuncionDTO.FuncionCod = wobjDataRow["FuncionCod"] != null ? wobjDataRow["FuncionCod"].ToString() : string.Empty;
                    theFuncionDTO.FuncionNombre = wobjDataRow["FuncionNom"] != null ? wobjDataRow["FuncionNom"].ToString() : string.Empty;
                    collFunciones.Add(theFuncionDTO);
                }
            }
            return collFunciones;
        }

        public static List<FuncionDTO> ListadoFuncion()
        {
           DataTable pobjDataTable = new DataTable();
           YouCom.DTO.Seguridad.FuncionDTO theFuncionDTO;
           List<YouCom.DTO.Seguridad.FuncionDTO > collFunciones=new List<FuncionDTO>();

           if (YouCom.Seguridad.DAL.FuncionDAL.ListadoFuncion(ref pobjDataTable))
           {
               foreach (DataRow wobjDataRow in pobjDataTable.Rows)
               {
                   theFuncionDTO=new FuncionDTO();
                   theFuncionDTO.FuncionCod = wobjDataRow["FuncionCod"] != null ? wobjDataRow["FuncionCod"].ToString() : string.Empty;

                    if (wobjDataRow["PadreCod"] != null)
                    {
                        theFuncionDTO.PadreCod = !string.IsNullOrEmpty(wobjDataRow["PadreCod"].ToString()) ? int.Parse(wobjDataRow["PadreCod"].ToString()) : 0;
                    }

                    theFuncionDTO.FuncionNombre = wobjDataRow["FuncionNom"] != null ? wobjDataRow["FuncionNom"].ToString() : string.Empty;
                   theFuncionDTO.FuncionTipoCod = wobjDataRow["FuncionTipoCod"] != null ? wobjDataRow["FuncionTipoCod"].ToString() : string.Empty;
                   theFuncionDTO.FuncionGrupoCod = wobjDataRow["FuncionGrpCod"] != null ? wobjDataRow["FuncionGrpCod"].ToString() : string.Empty;
                   theFuncionDTO.Url = wobjDataRow["url"] != null ? wobjDataRow["url"].ToString() : string.Empty;
                   theFuncionDTO.FuncionalidadNegocio = wobjDataRow["funcionalidadNegocio"] != null ? wobjDataRow["funcionalidadNegocio"].ToString() : string.Empty;
                   theFuncionDTO.FechaIngreso = wobjDataRow["fechaIngreso"] != null ? wobjDataRow["fechaIngreso"].ToString() : string.Empty;
                   theFuncionDTO.UsuarioIngreso = wobjDataRow["usuarioIngreso"] != null ? wobjDataRow["usuarioIngreso"].ToString() : string.Empty;
                   theFuncionDTO.UsuarioModificacion = wobjDataRow["usuarioModificacion"] != null ? wobjDataRow["usuarioModificacion"].ToString() : string.Empty;
                   theFuncionDTO.FechaModificacion = wobjDataRow["fechaModificacion"] != null ? wobjDataRow["fechaModificacion"].ToString() : string.Empty;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["empresa"].ToString());
                    theFuncionDTO.TheCondominioDTO = myCondominio;

                    theFuncionDTO.Estado = wobjDataRow["estado"] != null ? wobjDataRow["estado"].ToString() : string.Empty;

                   collFunciones.Add(theFuncionDTO);
               }
           }
           return collFunciones;
         }

        public static bool ValidaEliminacionFuncion(FuncionDTO theFuncionDTO)
         {
             DataTable pobjDataTable = new DataTable();
             bool retorno = false;
             if (YouCom.Seguridad.DAL.FuncionDAL.ValidaEliminacionFuncion(theFuncionDTO, ref pobjDataTable))
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
