using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Seguridad;
using System.Data;

namespace YouCom.facade
{
    public class Funcion
    {
         public static List<FuncionDTO> ListadoFuncion()
        {
           DataTable pobjDataTable = new DataTable();
           YouCom.DTO.Seguridad.FuncionDTO theFuncionDTO;
           List<YouCom.DTO.Seguridad.FuncionDTO > collFunciones=new List<FuncionDTO>();

           if (YouCom.Comun.DAL.Accesos.Funcion.ListadoFuncion(ref pobjDataTable))
           {
               foreach (DataRow wobjDataRow in pobjDataTable.Rows)
               {
                   theFuncionDTO=new FuncionDTO();
                   theFuncionDTO.FuncionCod = wobjDataRow["FuncionCod"] != null ? wobjDataRow["FuncionCod"].ToString() : string.Empty;
                   theFuncionDTO.FuncionNombre = wobjDataRow["FuncionNom"] != null ? wobjDataRow["FuncionNom"].ToString() : string.Empty;
                   theFuncionDTO.FuncionTipoCod = wobjDataRow["FuncionTipoCod"] != null ? wobjDataRow["FuncionTipoCod"].ToString() : string.Empty;
                   theFuncionDTO.FuncionGrupoCod = wobjDataRow["FuncionGrpCod"] != null ? wobjDataRow["FuncionGrpCod"].ToString() : string.Empty;
                   theFuncionDTO.Url = wobjDataRow["url"] != null ? wobjDataRow["url"].ToString() : string.Empty;
                   theFuncionDTO.FuncionalidadNegocio = wobjDataRow["funcionalidadNegocio"] != null ? wobjDataRow["funcionalidadNegocio"].ToString() : string.Empty;
                   theFuncionDTO.FechaIngreso = wobjDataRow["fechaIngreso"] != null ? wobjDataRow["fechaIngreso"].ToString() : string.Empty;
                   theFuncionDTO.UsuarioIngreso = wobjDataRow["usuarioIngreso"] != null ? wobjDataRow["usuarioIngreso"].ToString() : string.Empty;
                   theFuncionDTO.UsuarioModificacion = wobjDataRow["usuarioModificacion"] != null ? wobjDataRow["usuarioModificacion"].ToString() : string.Empty;
                   theFuncionDTO.FechaModificacion = wobjDataRow["fechaModificacion"] != null ? wobjDataRow["fechaModificacion"].ToString() : string.Empty;

                   theFuncionDTO.IdCondominio = wobjDataRow["empresa"] != null ? decimal.Parse(wobjDataRow["empresa"].ToString()) : 0;
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
             if (YouCom.mantenedores.DAL.MantenedoresDAL.ValidaEliminacionFuncion(theFuncionDTO, ref pobjDataTable))
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
