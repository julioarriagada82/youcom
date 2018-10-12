using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace YouCom.Service
{
    public class Familia
    {
        public static IList<YouCom.DTO.Propietario.FamiliaDTO> getListadoFamilia()
        {
            IList<YouCom.DTO.Propietario.FamiliaDTO> IFamilia = new List<YouCom.DTO.Propietario.FamiliaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (getListadoFamilia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Propietario.FamiliaDTO familia = new YouCom.DTO.Propietario.FamiliaDTO();

                    familia.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    familia.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    familia.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Propietario.CasaDTO myCasaDTO = new YouCom.DTO.Propietario.CasaDTO();
                    myCasaDTO.IdCasa = decimal.Parse(wobjDataRow["idCasa"].ToString());
                    myCasaDTO.NombreCasa = wobjDataRow["nombreCasa"].ToString();
                    familia.TheCasaDTO = myCasaDTO;

                    YouCom.DTO.Propietario.OcupacionDTO myOcupacionDTO = new YouCom.DTO.Propietario.OcupacionDTO();
                    myOcupacionDTO.IdOcupacion = decimal.Parse(wobjDataRow["idOcupacion"].ToString());
                    myOcupacionDTO.NombreOcupacion = wobjDataRow["nombreOcupacion"].ToString();
                    familia.TheOcupacionDTO = myOcupacionDTO;

                    familia.RutFamilia = wobjDataRow["rutFamilia"].ToString();
                    familia.NombreFamilia = wobjDataRow["nombreFamilia"].ToString();
                    familia.ApellidoPaternoFamilia = wobjDataRow["apellidoPaternoFamilia"].ToString();
                    familia.ApellidoMaternoFamilia = wobjDataRow["apellidoMaternoFamilia"].ToString();

                    YouCom.DTO.Propietario.ParentescoDTO myParentescoDTO = new YouCom.DTO.Propietario.ParentescoDTO();
                    myParentescoDTO.IdParentesco = decimal.Parse(wobjDataRow["idParentesco"].ToString());
                    myParentescoDTO.NombreParentesco = wobjDataRow["nombreParentesco"].ToString();
                    familia.TheParentescoDTO = myParentescoDTO;

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

        public static bool getListadoFamilia(ref DataTable pobjDataTable)
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
                if (wobjSQLHelper.Ejecutar("QRY_ListadoFamilia",
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
    }
}
