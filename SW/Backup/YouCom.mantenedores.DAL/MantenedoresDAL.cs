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

namespace YouCom.mantenedores.DAL
{
    public class MantenedoresDAL
    {
        #region CRUD Pais
        public static bool InsertPais(PaisDTO thePaisDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();



            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, thePaisDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@Descripcion", SqlDbType.VarChar, 20, thePaisDTO.Descripcion);


            try
            {
                
                      //Ejecuto SP.
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Pais", "YouCom"))
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
        public static bool ActivaPais(PaisDTO thePaisDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();



            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, thePaisDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@PidPais", SqlDbType.VarChar, 20, thePaisDTO.IdPais);

          
            try
            {
                  //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Pais", "YouCom"))
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
        public static bool UpdatePais(PaisDTO thePaisDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();



            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, thePaisDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@Descripcion", SqlDbType.VarChar, 20, thePaisDTO.Descripcion);
            wobjSQLHelper.SetParametro("@IdPais", SqlDbType.VarChar, 20, thePaisDTO.IdPais);

    
            try
            {
                
               //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UDP_Pais", "YouCom"))
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
        public static bool DeletePais(PaisDTO thePaisDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();



            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, thePaisDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@IdPais", SqlDbType.VarChar, 20, thePaisDTO.IdPais);


            try
            {
                 //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Delete_Pais", "YouCom"))
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
        public static bool ValidaEliminacionPais(PaisDTO thePaisDTO,ref DataTable pobjDatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();



            wobjSQLHelper.SetParametro("@idpais", SqlDbType.VarChar, 20, thePaisDTO.IdPais);

            try
            {
                 //====================================================================================
                if(wobjSQLHelper.Ejecutar("validaEliminacionPais", "YouCom", pobjDatable)<=0)
                {
                     retorno = true;
                }
                else
                {
                    retorno=false;
                }
                //====================================================================================
               
             
            }
            catch (Exception eobjException)
            {
                throw eobjException;
            }
            return retorno;
        }
        #endregion Pais

        #region CRUD Region
        public static bool InsertRegion(RegionDTO theRegionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();



            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theRegionDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@Descripcion", SqlDbType.VarChar, 20, theRegionDTO.Descripcion);
            wobjSQLHelper.SetParametro("@idPais", SqlDbType.VarChar, 20, theRegionDTO.IdPais);

           


            try
            {
                
               
            //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Region", "YouCom"))
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
        public static bool ActivaRegion(RegionDTO theRegionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();



            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theRegionDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@PidRegion", SqlDbType.VarChar, 20, theRegionDTO.IdRegion);

            try
            {
                
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Region", "YouCom"))
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
        public static bool UpdateRegion(RegionDTO theRegionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();



            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theRegionDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@Descripcion", SqlDbType.VarChar, 20, theRegionDTO.Descripcion);
            wobjSQLHelper.SetParametro("@IdRegion", SqlDbType.VarChar, 20, theRegionDTO.IdRegion);
            wobjSQLHelper.SetParametro("@idPais", SqlDbType.VarChar, 20, theRegionDTO.IdPais);


            try
            {
                
                  //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UDP_Region", "YouCom"))
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
        public static bool DeleteRegion(RegionDTO theRegionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();



            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theRegionDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@IdRegion", SqlDbType.VarChar, 20, theRegionDTO.IdRegion);

            try
            {
                

                   //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Delete_Region", "YouCom"))
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
        public static bool ValidaEliminacionRegion(RegionDTO theRegionDTO, ref DataTable pobjDatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();



            wobjSQLHelper.SetParametro("@IdRegion", SqlDbType.VarChar, 20, theRegionDTO.IdRegion);

            try
            {
                   //====================================================================================
                 if(wobjSQLHelper.Ejecutar("validaEliminacionRegion", "YouCom", pobjDatable)<=0)
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
        #endregion Region

        #region CRUD Funcion
        public static bool InsertFuncion(FuncionDTO theFuncionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@NombreFuncion", SqlDbType.VarChar, 20, theFuncionDTO.FuncionNombre);
            wobjSQLHelper.SetParametro("@Tipo", SqlDbType.Int, 20, theFuncionDTO.FuncionTipoCod);
            wobjSQLHelper.SetParametro("@Grupo", SqlDbType.Int, 20, theFuncionDTO.FuncionGrupoCod);
            wobjSQLHelper.SetParametro("@Url", SqlDbType.VarChar, 20, theFuncionDTO.Url);
            wobjSQLHelper.SetParametro("@FuncionalidadNegocio", SqlDbType.VarChar, 20, theFuncionDTO.EnviaCorreo);
            wobjSQLHelper.SetParametro("@enviaCorreo", SqlDbType.VarChar, 20, theFuncionDTO.EnviaCorreo);



            try
            {
                
                
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_Funcion", "YouCom"))
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
        public static bool ActivaFuncion(FuncionDTO theFuncionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@PusuarioIngreso", SqlDbType.VarChar, 20, theFuncionDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionCod", SqlDbType.VarChar, 20, theFuncionDTO.FuncionCod);
        

            try
            {
                
                  
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_Funcion", "YouCom"))
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
        public static bool UpdateFuncion(FuncionDTO theFuncionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionNombre", SqlDbType.VarChar, 20, theFuncionDTO.FuncionNombre);
            wobjSQLHelper.SetParametro("@FuncionCod", SqlDbType.VarChar, 20, theFuncionDTO.FuncionCod);
            wobjSQLHelper.SetParametro("@funcionTipoCod", SqlDbType.VarChar, 20, theFuncionDTO.FuncionTipoCod);
            wobjSQLHelper.SetParametro("@funcionGrpCod", SqlDbType.VarChar, 20, theFuncionDTO.FuncionGrupoCod);
            wobjSQLHelper.SetParametro("@url", SqlDbType.VarChar, 20, theFuncionDTO.Url);
            wobjSQLHelper.SetParametro("@funcionalidadNegocio", SqlDbType.VarChar, 20, theFuncionDTO.FuncionalidadNegocio);
            wobjSQLHelper.SetParametro("@envioCorreo", SqlDbType.VarChar, 20, theFuncionDTO.EnviaCorreo);

            try
            {
                
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UDP_Funcion", "YouCom"))
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
        public static bool DeleteFuncion(FuncionDTO theFuncionDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionCod", SqlDbType.VarChar, 20, theFuncionDTO.FuncionCod);

            try
            {
            
                //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Delete_Funcion", "YouCom"))
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
        public static bool ValidaEliminacionFuncion(FuncionDTO theFuncionDTO, ref DataTable pobjDatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@idTipoTarea", SqlDbType.VarChar, 20, theFuncionDTO.FuncionCod);

            try
            {
                  //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionTipoTarea", "YouCom", pobjDatable) <= 0)
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
        #endregion Funcion

        #region CRUD FuncionTipo
        public static bool InsertFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionTipoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@NombreTipoFuncion", SqlDbType.VarChar, 20, theFuncionTipoDTO.FuncionTipoNombre);


            try
            {
                
                  //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_TipoFuncion", "YouCom"))
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
        public static bool ActivaFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@PusuarioIngreso", SqlDbType.VarChar, 20, theFuncionTipoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionTipoCod", SqlDbType.VarChar, 20, theFuncionTipoDTO.FuncionTipoCod);
            try
            {
                
                   //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Activa_FuncionTipo", "YouCom"))
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
        public static bool UpdateFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionTipoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionNombre", SqlDbType.VarChar, 20, theFuncionTipoDTO.FuncionTipoNombre);
            wobjSQLHelper.SetParametro("@FuncionTipoCod", SqlDbType.VarChar, 20, theFuncionTipoDTO.FuncionTipoCod);



            try
            {
                
                  //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UDP_TipoFuncion", "YouCom"))
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
        public static bool DeleteFuncionTipo(FuncionTipoDTO theFuncionTipoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionTipoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionTipoCod", SqlDbType.VarChar, 20, theFuncionTipoDTO.FuncionTipoCod);


            try
            {
                
                     //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Delete_TipoFuncion", "YouCom"))
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
        public static bool ValidaEliminacionFuncionTipo(FuncionTipoDTO theFuncionTipoDTO,ref DataTable pobjDatable)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@FuncionTipoCod", SqlDbType.VarChar, 20, theFuncionTipoDTO.FuncionTipoCod);

            try
            {
                
                      //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionFuncionTipo", "YouCom", pobjDatable) <= 0)
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
        #endregion FuncionTipo

        #region CRUD FuncionGrupo
        public static bool InsertFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionGrupoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionGrupo", SqlDbType.VarChar, 20, theFuncionGrupoDTO.FuncionGrupoNombre);

            try
            {
                      //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("INS_FuncionGrupo", "YouCom"))
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
        public static bool ActivaFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@PusuarioIngreso", SqlDbType.VarChar, 20, theFuncionGrupoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionGrpCod", SqlDbType.VarChar, 20, theFuncionGrupoDTO.FuncionGrupoCod);

            try
            {
                       //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("ActivaFuncionGrupo", "YouCom"))
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
        public static bool UpdateFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionGrupoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionNombre", SqlDbType.VarChar, 20, theFuncionGrupoDTO.FuncionGrupoNombre);
            wobjSQLHelper.SetParametro("@FuncionGrpCod", SqlDbType.VarChar, 20, theFuncionGrupoDTO.FuncionGrupoCod);


            try
            {
                
                        //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("UDP_FuncionGrupo", "YouCom"))
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
        public static bool DeleteFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO)
        {
            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@usuarioIngreso", SqlDbType.VarChar, 20, theFuncionGrupoDTO.UsuarioIngreso);
            wobjSQLHelper.SetParametro("@FuncionGrpCod", SqlDbType.VarChar, 20, theFuncionGrupoDTO.FuncionGrupoCod);

            try
            {
                
                         //====================================================================================
                switch (wobjSQLHelper.EjecutarNQ("Delete_FuncionGrupo", "YouCom"))
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
        public static bool ValidaEliminacionFuncionGrupo(FuncionGrupoDTO theFuncionGrupoDTO,ref DataTable pobjDatable)
        {

            bool retorno = false;
            YouCom.Service.BD.SQLHelper wobjSQLHelper = new YouCom.Service.BD.SQLHelper();

            wobjSQLHelper.SetParametro("@FuncionGrpCod", SqlDbType.VarChar, 20, theFuncionGrupoDTO.FuncionGrupoCod);

            try
            {
                
                         //====================================================================================
                if (wobjSQLHelper.Ejecutar("validaEliminacionFuncionGrupo", "YouCom",pobjDatable)<=0)
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
        #endregion FuncionGrupo
        
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
