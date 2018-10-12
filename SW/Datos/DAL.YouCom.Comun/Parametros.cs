/**
 * (c)1996-2006 Inter Media S.A. Todos los Derechos Reservados.
 *
 * El uso de este programa y/o la documentación asociada, ya sea en forma
 * de fuentes o archivos binarios, con o sin modificaciones,
 * esta sujeto a la licencia descrita en LICENCIA.TXT.
 **/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Intermedia.IMSystem.IMUtil;

namespace YouCom.Comun.DAL.Accesos
{
    public class Parametros : MappingClass
    {
        #region " Miembros Privados "
        // categoria_id
        protected decimal Id;
        // categoria_id
        protected string Concepto;
        // categoria_id
        protected string Codigo;
        // cate_nombre
        protected string Descripcion;
        #endregion // Miembros Privados

        #region " Propiedades de la Clase "
        // cate_descripcion
        public decimal myId
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }
        // cate_descripcion
        public string myConcepto
        {
            get
            {
                return Concepto;
            }
            set
            {
                Concepto = value;
            }
        }
        // cate_descripcion
        public string myCodigo
        {
            get
            {
                return Codigo;
            }
            set
            {
                Codigo = value;
            }
        }
        // cate_nombre
        public string myDescripcion
        {
            get
            {
                return Descripcion;
            }
            set
            {
                Descripcion = value;
            }
        }
        #endregion // Propiedades de la Clase

        #region " Constructor Vacio de la Clase "
        public Parametros()
        {
        }
        #endregion // Fin Constructor Vacio

        #region " Metodo LoadRow "
        public bool LoadRow(SqlDataReader myDataReader)
        {
            try
            {
                if (myDataReader != null)
                {
                    // categoria_id
                    try
                    {
                        this.Id = myDataReader.GetDecimal(0);
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    // categoria_id
                    try
                    {
                        this.Concepto = myDataReader.GetString(1);
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    // categoria_id
                    try
                    {
                        this.Codigo = myDataReader.GetString(2);
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                    // cate_descripcion
                    try
                    {
                        if (!myDataReader.IsDBNull(3))
                            this.Descripcion = myDataReader.GetString(3);
                    }
                    catch (Exception ex)
                    {
                       
                        throw new Exception(ex.Message);
                    }
                }
            }
            catch (SqlException ex)
            {
               
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
            finally
            {
            }
            return true;
        }
        #endregion // Constructor con Llave Primaria

        #region " Metodo ElementsPersistencePortal "
        public static IList getParametrosByConcepto(string pConcepto)
        {
            IList myList = new List<Parametros>();
            SqlDataReader myDataReader = null;
            SqlConnection myConnection = YouCom.Service.IMDB.IMDB.GetConnection();
            SqlCommand myCommand = new SqlCommand("QRY_ParametrosByConcepto", myConnection);
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.Parameters.Add("@Concepto", SqlDbType.VarChar, 50).Value = pConcepto;

            myConnection.Open();

            try
            {
                myDataReader = myCommand.ExecuteReader();
                while (myDataReader.Read())
                {
                    Parametros obj = new Parametros();
                    obj.LoadRow(myDataReader);
                    myList.Add(obj);
                }
            }
            catch (SqlException ex)
            {
               
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                
                throw new Exception(e.Message);
            }
            finally
            {
                if (myDataReader != null)
                {
                    myDataReader.Close();
                }
                myConnection.Close();
            }
            return myList;
        }
        #endregion // ElementsPersistencePortal
    }
}

