using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace YouCom.facade
{
    public class Archivo
    {
        public static IList<YouCom.DTO.ArchivoDTO> getListadoArchivo()
        {
            IList<YouCom.DTO.ArchivoDTO> IArchivo = new List<YouCom.DTO.ArchivoDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ArchivoDAL.getListadoArchivo(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.ArchivoDTO archivo = new YouCom.DTO.ArchivoDTO();

                    archivo.ArchivoId = decimal.Parse(wobjDataRow["IdArchivo"].ToString());
                    archivo.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    archivo.IdCategoria = decimal.Parse(wobjDataRow["idCategoria"].ToString());
                    archivo.ArchivoTitulo = wobjDataRow["tituloArchivo"].ToString();
                    archivo.ArchivoDescripcion = wobjDataRow["descripcionArchivo"].ToString();
                    archivo.ArchivoNombre = wobjDataRow["nombreArchivo"].ToString();

                    archivo.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    archivo.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    archivo.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    archivo.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    archivo.Estado = wobjDataRow["estado"].ToString();

                    IArchivo.Add(archivo);
                }
            }

            return IArchivo;

        }

        public static bool ValidaEliminacionArchivo(YouCom.DTO.ArchivoDTO theArchivoDTO)
        {
            DataTable pobjDataTable = new DataTable();
            List<YouCom.DTO.ArchivoDTO> collArchivo = new List<YouCom.DTO.ArchivoDTO>();
            bool retorno = false;
            if (YouCom.DAL.ArchivoDAL.ValidaEliminacionArchivo(theArchivoDTO, ref pobjDataTable))
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
