using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO.Seguridad;
using System.Data;

namespace YouCom.facade.Seguridad
{
    public class FuncionTipo
    {
        public static bool ValidaEliminacionFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.Seguridad.DAL.FuncionTipoDAL.ValidaEliminacionFuncionTipo(theFuncionTipoDTO, ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    retorno = true;

                }

            }
            return retorno;
        }
        public static List<FuncionTipoDTO> ListadoFuncionTipo()
        {
           DataTable pobjDataTable = new DataTable();
           YouCom.DTO.Seguridad.FuncionTipoDTO theFuncionTipoDTO;
           List<YouCom.DTO.Seguridad.FuncionTipoDTO > collFuncionesTipo=new List<FuncionTipoDTO>();

           if (YouCom.Seguridad.DAL.FuncionTipoDAL.ListadoFuncionTipo(ref pobjDataTable))
           {
               foreach (DataRow wobjDataRow in pobjDataTable.Rows)
               {
                   theFuncionTipoDTO=new FuncionTipoDTO();
                   theFuncionTipoDTO.FuncionTipoCod = wobjDataRow["FuncionTipoCod"] != null ? wobjDataRow["FuncionTipoCod"].ToString() : string.Empty;
                   theFuncionTipoDTO.FuncionTipoNombre = wobjDataRow["FuncionTipoDes"] != null ? wobjDataRow["FuncionTipoDes"].ToString() : string.Empty;
                   theFuncionTipoDTO.UsuarioIngreso = wobjDataRow["usuarioingreso"] != null ? wobjDataRow["usuarioingreso"].ToString() : string.Empty;
                   theFuncionTipoDTO.FechaIngreso = wobjDataRow["fechaingreso"] != null ? wobjDataRow["fechaingreso"].ToString() : string.Empty;
                   theFuncionTipoDTO.UsuarioModificacion = wobjDataRow["usuariomodificacion"] != null ? wobjDataRow["usuariomodificacion"].ToString() : string.Empty;
                   theFuncionTipoDTO.FechaModificacion = wobjDataRow["fechamodificacion"] != null ? wobjDataRow["fechamodificacion"].ToString() : string.Empty;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["empresa"].ToString());
                    theFuncionTipoDTO.TheCondominioDTO = myCondominio;

                    theFuncionTipoDTO.Estado = wobjDataRow["estado"] != null ? wobjDataRow["estado"].ToString() : string.Empty;

                   collFuncionesTipo.Add(theFuncionTipoDTO);
               }
           }
           return collFuncionesTipo;
         }
        }
    }

