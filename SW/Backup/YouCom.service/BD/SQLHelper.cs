using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using YouCom.Service.Configuracion;

namespace YouCom.Service.BD
{
    /// <summary>
	/// Clase para el acceso a SQL Server.
	/// </summary>
    public sealed class SQLHelper
    {

        SqlCommand mobjSqlCommand = new SqlCommand();
        SqlCommand mobjSqlCommandAnt;


        public SQLHelper()
        {
        }


        /// <summary>
        /// Setea un parámetro de Input.
        /// </summary>
        public void SetParametro(string pvarNombre,
                                 SqlDbType pvarSqlDbType,
                                 int pvarSize,
                                 object pvarValor)
        {
            //Para el manejo de los errores.
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            SqlParameter wobjSqlParameter = null;

            try
            {
                wvarPaso = 10;
                wobjSqlParameter = new SqlParameter(pvarNombre,
                                                    pvarSqlDbType,
                                                    pvarSize);
                wvarPaso = 20;
                wobjSqlParameter.Value = pvarValor;

                wvarPaso = 30;
                mobjSqlCommand.Parameters.Add(wobjSqlParameter);
            }

            catch (Exception eobjException)
            {
                if (mobjSqlCommand != null)
                {
                    mobjSqlCommand.Dispose();
                }
                throw eobjException;
            }
        }


        /// <summary>
        /// Setea un parámetro de Output.
        /// </summary>
        public void SetParametroOut(string pvarNombre,
                                    SqlDbType pvarSqlDbType,
                                    int pvarSize)
        {
            //Para el manejo de los errores.
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            SqlParameter wobjSqlParameter = null;

            try
            {
                wvarPaso = 10;
                wobjSqlParameter = new SqlParameter(pvarNombre,
                                                    pvarSqlDbType,
                                                    pvarSize);

                wvarPaso = 20;
                wobjSqlParameter.Direction = ParameterDirection.InputOutput;

                wvarPaso = 30;
                wobjSqlParameter.Value = DBNull.Value;


                wvarPaso = 40;
                mobjSqlCommand.Parameters.Add(wobjSqlParameter);
            }

            catch (Exception eobjException)
            {
                if (mobjSqlCommand != null)
                {
                    mobjSqlCommand.Dispose();
                }

                throw eobjException;
            }
        }


        /// <summary>
        /// Obtiene valor de un parámetro.
        /// </summary>
        public object GetParametro(string pvarNombre)
        {
            //Para el manejo de los errores.
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            try
            {
                wvarPaso = 10;
                return mobjSqlCommandAnt.Parameters[pvarNombre].Value;
            }

            catch (Exception eobjException)
            {
                if (mobjSqlCommandAnt != null)
                {
                    mobjSqlCommandAnt.Dispose();
                }

                return null;
                throw eobjException;
            }
        }


        /// <summary>
        /// Ejecuta Stored Procedures que NO devuelven results.
        /// </summary>
        public int EjecutarNQ(string pvarStoredProcedure,
                              string pvarBase)
        {
            //Para el manejo de los errores.
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================

            SqlConnection wobjSqlConnection = null;
            int wvarRowsAffected = 0;

            try
            {
                //Obtengo el string de conexión del App.Config
                //====================================================================================
                wvarPaso = 20;
                wobjSqlConnection = new SqlConnection();

                wvarPaso = 30;
                wobjSqlConnection.ConnectionString = YouCom.Service.Seguridad.Crypt.Desencriptar(Config.GetPropiedad(pvarBase), Config.GetPropiedad("TokenPwd"));
                //====================================================================================


                //Abro la conexión
                //====================================================================================
                wvarPaso = 100;
                wobjSqlConnection.Open();
                //====================================================================================


                //Asigno valores al Command
                //====================================================================================
                wvarPaso = 200;
                mobjSqlCommand.CommandText = pvarStoredProcedure;
                mobjSqlCommand.CommandType = CommandType.StoredProcedure;
                mobjSqlCommand.Connection = wobjSqlConnection;
                //====================================================================================


                //Ejecuto
                //====================================================================================
                wvarPaso = 300;
                wvarRowsAffected = mobjSqlCommand.ExecuteNonQuery();

                wvarPaso = 310;
                return wvarRowsAffected == -1 ? -100 : wvarRowsAffected;
                //====================================================================================

            }

            catch (SqlException eobjSQLException)
            {
                //Verifico si es por clave duplicada (2627), integridad referencial (547) u otro.
                //====================================================================================
                switch (eobjSQLException.Number)
                {
                    case (2627):
                        return -1;
                    case (547):
                        return -2;
                    default:
                        throw eobjSQLException;
                }
                //====================================================================================
            }

            catch (Exception eobjException)
            {
                return 0;
                throw eobjException;
            }

            finally
            {
                if (wobjSqlConnection != null)
                {
                    if (wobjSqlConnection.State == ConnectionState.Open)
                    {
                        wobjSqlConnection.Close();
                    }
                    wobjSqlConnection.Dispose();
                }

                if (mobjSqlCommand != null)
                {
                    mobjSqlCommand.Dispose();
                    mobjSqlCommandAnt = mobjSqlCommand.Clone();
                    mobjSqlCommand.Parameters.Clear();
                }
            }
        }



        /// <summary>
        /// Ejecuta Stored Procedures que devuelven 1 result.
        /// </summary>
        public int Ejecutar(string pvarStoredProcedure,
                            string pvarBase,
                            DataTable pobjDataTable)
        {
            //Para el manejo de los errores.
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================


            SqlConnection wobjSqlConnection = null;
            SqlDataAdapter wobjSqlDataAdapter = null;


            try
            {
                //Limpio filas del DataTable.
                //====================================================================================
                wvarPaso = 10;
                pobjDataTable.Rows.Clear();
                //====================================================================================


                //Obtengo el string de conexión del App.Config
                //====================================================================================
                wvarPaso = 20;
                wobjSqlConnection = new SqlConnection();

                wvarPaso = 30;
                wobjSqlConnection.ConnectionString = YouCom.Service.Seguridad.Crypt.Desencriptar(Config.GetPropiedad(pvarBase), Config.GetPropiedad("TokenPwd"));
                //====================================================================================


                //Asigno valores al Command
                //====================================================================================
                wvarPaso = 100;
                mobjSqlCommand.CommandText = pvarStoredProcedure;
                mobjSqlCommand.CommandType = CommandType.StoredProcedure;
                mobjSqlCommand.Connection = wobjSqlConnection;
                //====================================================================================


                //Asigno Command al Adapter.
                //====================================================================================
                wvarPaso = 200;
                wobjSqlDataAdapter = new SqlDataAdapter();

                wvarPaso = 210;
                wobjSqlDataAdapter.SelectCommand = mobjSqlCommand;
                //====================================================================================

                //Ejecuto
                //====================================================================================
                wvarPaso = 300;
                return wobjSqlDataAdapter.Fill(pobjDataTable);
                //====================================================================================
            }

            catch (SqlException eobjSQLException)
            {
                throw eobjSQLException;
            }

            catch (Exception eobjException)
            {
                return 0;
                throw eobjException;
            }

            finally
            {
                if (wobjSqlConnection != null)
                {
                    if (wobjSqlConnection.State == ConnectionState.Open)
                    {
                        wobjSqlConnection.Close();
                    }
                    wobjSqlConnection.Dispose();
                }

                if (mobjSqlCommand != null)
                {
                    mobjSqlCommand.Dispose();
                    mobjSqlCommandAnt = mobjSqlCommand.Clone();
                    mobjSqlCommand.Parameters.Clear();
                }

                if (wobjSqlDataAdapter != null)
                {
                    wobjSqlDataAdapter.Dispose();
                }
            }
        }


        /// <summary>
        /// Ejecuta Stored Procedures que devuelven N results.
        /// </summary>
        public int Ejecutar(string pvarStoredProcedure,
                            string pvarBase,
                            DataSet pobjDataSet)
        {
            //Para el manejo de los errores.
            //====================================================================================
            int wvarPaso = 0;
            //====================================================================================


            SqlConnection wobjSqlConnection = null;
            SqlDataAdapter wobjSqlDataAdapter = null;


            try
            {
                //Limpio DataSet.
                //====================================================================================
                wvarPaso = 10;
                pobjDataSet.Clear();
                //====================================================================================


                //Obtengo el string de conexión del App.Config
                //====================================================================================
                wvarPaso = 20;
                wobjSqlConnection = new SqlConnection();

                wvarPaso = 30;
                wobjSqlConnection.ConnectionString = YouCom.Service.Seguridad.Crypt.Desencriptar(Config.GetPropiedad(pvarBase), Config.GetPropiedad("TokenPwd"));
                //====================================================================================


                //Asigno valores al Command
                //====================================================================================
                wvarPaso = 100;
                mobjSqlCommand.CommandText = pvarStoredProcedure;
                mobjSqlCommand.CommandType = CommandType.StoredProcedure;
                mobjSqlCommand.Connection = wobjSqlConnection;
                //====================================================================================


                //Asigno Command al Adapter.
                //====================================================================================
                wvarPaso = 200;
                wobjSqlDataAdapter = new SqlDataAdapter();

                wvarPaso = 210;
                wobjSqlDataAdapter.SelectCommand = mobjSqlCommand;
                //====================================================================================

                //Ejecuto
                //====================================================================================
                wvarPaso = 300;
                return wobjSqlDataAdapter.Fill(pobjDataSet);
                //====================================================================================
            }

            catch (SqlException eobjSQLException)
            {
                throw eobjSQLException;
            }

            catch (Exception eobjException)
            {
                throw eobjException;
                return 0;
            }

            finally
            {
                if (wobjSqlConnection != null)
                {
                    if (wobjSqlConnection.State == ConnectionState.Open)
                    {
                        wobjSqlConnection.Close();
                    }
                    wobjSqlConnection.Dispose();
                }

                if (mobjSqlCommand != null)
                {
                    mobjSqlCommand.Dispose();
                    mobjSqlCommandAnt = mobjSqlCommand.Clone();
                    mobjSqlCommand.Parameters.Clear();
                }

                if (wobjSqlDataAdapter != null)
                {
                    wobjSqlDataAdapter.Dispose();
                }
            }
        }
    }
}
