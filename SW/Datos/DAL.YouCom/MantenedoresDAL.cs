using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.Service.IMDB;
using System.Data.SqlClient;
using System.Data;
using YouCom.DTO;
using System.Collections;
using YouCom.DTO.Seguridad;

namespace YouCom.DAL
{
    public class MantenedoresDAL
    {   
        #region CRUD LOCALIDAD
        public static bool InsertLocalidad(LocalidadDTO theLocalidadDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@Region", SqlDbType.VarChar, 20, theLocalidadDTO.IdRegion);
            wobjSQLHelper.SetParametro("@descripcionLocalidad", SqlDbType.VarChar, 100, theLocalidadDTO.Descripcion);
            wobjSQLHelper.SetParametro("@PUsuarioIngreso", SqlDbType.VarChar, 20, theLocalidadDTO.UsuarioIngreso);


            try
            {
                
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_localidad", "YouCom"))
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
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }
        public static bool UpdateLocalidad(LocalidadDTO theLocalidadDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@idLocalidad", SqlDbType.VarChar, 20, theLocalidadDTO.IdLocalidad);
            wobjSQLHelper.SetParametro("@Region", SqlDbType.VarChar, 100, theLocalidadDTO.IdRegion);
            wobjSQLHelper.SetParametro("@descripcionLocalidad", SqlDbType.VarChar, 20, theLocalidadDTO.Descripcion);
            wobjSQLHelper.SetParametro("@PUsuarioModificacion", SqlDbType.VarChar, 20, theLocalidadDTO.UsuarioModificacion);


            try
            {
               //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UDP_localidad", "YouCom"))
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
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }
        public static bool DeleteLocalidad(LocalidadDTO theLocalidadDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@idLocalidad", SqlDbType.VarChar, 20, theLocalidadDTO.IdLocalidad);
            wobjSQLHelper.SetParametro("@PUsuarioModificacion", SqlDbType.VarChar, 20, theLocalidadDTO.UsuarioModificacion);

            try
            {
                
               //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Delete_localidad", "YouCom"))
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
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }
        public static bool ActivaLocalidad(LocalidadDTO theLocalidadDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@PidLocalidad", SqlDbType.VarChar, 20, theLocalidadDTO.IdLocalidad);
            wobjSQLHelper.SetParametro("@PusuarioIngreso", SqlDbType.VarChar, 20, theLocalidadDTO.UsuarioModificacion);

            try
            {
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_localidad", "YouCom"))
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
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }
        public static bool ValidaEliminacionLocalidad(LocalidadDTO theLocalidadDTO,ref DataTable pobjDatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@idLocalidad", SqlDbType.VarChar, 20, theLocalidadDTO.IdLocalidad);

            try
            {
                
                //====================================================================================
                if(wobjSQLHelper.Ejecutar("validaEliminacionLocalidad", "YouCom", pobjDatable)<=0)
                {
                    retorno = true;
                
                }
                else
                {
                   retorno = false;
                
                }
                //====================================================================================
                
             
            }
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }
        #endregion CRUD LOCALIDAD
    }
}
