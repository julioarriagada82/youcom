using System;
using System.Collections.Generic;
using YouCom.DTO.Seguridad;
using System.Data;

namespace YouCom.facade.Seguridad
{
    public class Usuario
    {
        public static IList<OperadorDTO> getListadoUsuario()
        {
            IList<OperadorDTO> IUsuario = new List<OperadorDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.Seguridad.DAL.UsuarioDAL.getListadoUsuario(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    OperadorDTO usuario = new OperadorDTO();

                    usuario.Rut = wobjDataRow["USU_RUT"].ToString();

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    usuario.TheCondominioDTO = myCondominio;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidad = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidad.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    usuario.TheCondominioDTO = myCondominio;

                    usuario.Nombres = wobjDataRow["nombre_usuario"].ToString();
                    usuario.Paterno = wobjDataRow["paterno_usuario"].ToString();
                    usuario.Materno = wobjDataRow["materno_usuario"].ToString();

                    usuario.Password = wobjDataRow["password"].ToString();
                    usuario.Mail = wobjDataRow["mail_usuario"].ToString();
                    usuario.FechaNacimiento = Convert.ToDateTime(wobjDataRow["fecha_nac_usuario"].ToString());
                    usuario.FechaPassword = !string.IsNullOrEmpty(wobjDataRow["fecha_password"].ToString()) ? Convert.ToDateTime(wobjDataRow["fecha_password"].ToString()) : DateTime.MinValue;
                    usuario.IntentoFallidoFecha = !string.IsNullOrEmpty(wobjDataRow["intento_fallido_fecha"].ToString()) ? Convert.ToDateTime(wobjDataRow["intento_fallido_fecha"].ToString()) : DateTime.MinValue;
                    usuario.IntentoFallidoCant = !string.IsNullOrEmpty(wobjDataRow["intento_fallido_cant"].ToString()) ? int.Parse(wobjDataRow["intento_fallido_cant"].ToString()): 0;

                    usuario.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    usuario.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    usuario.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    usuario.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    usuario.Estado = wobjDataRow["estado"].ToString();

                    IUsuario.Add(usuario);
                }
            }

            return IUsuario;

        }

        public static bool ValidaEliminacionUsuario(YouCom.DTO.Seguridad.OperadorDTO theUsuarioDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.Seguridad.DAL.UsuarioDAL.ValidaEliminacionUsuario(theUsuarioDTO, ref pobjDataTable))
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
