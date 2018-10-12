using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.DAL
{
    public class RankingServicioDAL
    {
        #region " Metodo getListadoRanking "
        public static bool getListadoRankingServicio(ref DataTable pobjDataTable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                if (wobjSQLHelper.Ejecutar("QRY_ListadoRankingServicio",
                                           "YouCom",
                                           pobjDataTable) <= 0)
                {
                    retorno = false;
                }
                else
                {
                    retorno = true;
                }
                //====================================================================================
            }

            #region Catch

            catch (Exception eobjException)
            {
                throw eobjException;
            }
            #endregion

            return retorno;
        }
        #endregion // ElementsPersistence

        #region " Metodo Insert "
        public static bool Insert(YouCom.DTO.Servicio.RankingServicioDTO myRankingServicioDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            try
            {
                //Seteo Parámetros.
                //====================================================================================
                wobjSQLHelper.SetParametro("@pIdEmpresaServicio", SqlDbType.Decimal, -1, myRankingServicioDTO.TheEmpresaServicioDTO.IdEmpresaServicio);
                wobjSQLHelper.SetParametro("@pIdCondominio", SqlDbType.Decimal, -1, myRankingServicioDTO.TheCondominioDTO.IdCondominio);
                wobjSQLHelper.SetParametro("@pIdComunidad", SqlDbType.Decimal, -1, myRankingServicioDTO.TheComunidadDTO.IdComunidad);
                wobjSQLHelper.SetParametro("@pIdFamilia", SqlDbType.Decimal, -1, myRankingServicioDTO.TheFamiliaDTO.IdFamilia);
                wobjSQLHelper.SetParametro("@pComentario", SqlDbType.Text, -1, !string.IsNullOrEmpty(myRankingServicioDTO.Comentario) ? myRankingServicioDTO.Comentario : System.Data.SqlTypes.SqlString.Null);
                wobjSQLHelper.SetParametro("@pFechaRanking", SqlDbType.DateTime, -1, myRankingServicioDTO.FechaRanking);
                wobjSQLHelper.SetParametro("@pNota", SqlDbType.Int, -1, myRankingServicioDTO.Nota);
                wobjSQLHelper.SetParametro("@pUsuarioIngreso", SqlDbType.VarChar, 20, myRankingServicioDTO.UsuarioIngreso);
                //====================================================================================

                //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_RankingServicio", "YouCom"))
                {
                    case 0:
                        throw new Exception("No se pudo grabar.");
                    case -1:
                        throw new Exception("Hubo un error.");
                    case -2:
                        throw new Exception("Hubo un error.");
                }
                //====================================================================================

                retorno = true;
            }

            #region Catch

            catch (Exception eobjException)
            {
                throw eobjException;
            }
            #endregion

            return retorno;
        }
        #endregion // Metodo SaveOrUpdatePersistence
    }
}
