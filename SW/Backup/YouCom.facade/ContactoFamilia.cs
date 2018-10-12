using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class ContactoFamilia
    {
        public static IList<YouCom.DTO.ContactoFamiliaDTO> getListadoContactoFamilia()
        {
            IList<YouCom.DTO.ContactoFamiliaDTO> IContactoFamilia = new List<YouCom.DTO.ContactoFamiliaDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.ContactoFamiliaDAL.getListadoContactoFamilia(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.ContactoFamiliaDTO tipo_aviso = new YouCom.DTO.ContactoFamiliaDTO();

                    tipo_aviso.IdContactoFamilia = decimal.Parse(wobjDataRow["IdContactoFamilia"].ToString());
                    tipo_aviso.IdCasa = decimal.Parse(wobjDataRow["IdCasa"].ToString());
                    tipo_aviso.IdParentesco = decimal.Parse(wobjDataRow["IdParentesco"].ToString());
                    tipo_aviso.NombreContacto = wobjDataRow["nombreContactoFamilia"].ToString();
                    tipo_aviso.TelefonoContacto = wobjDataRow["telefonoContactoFamilia"].ToString();
                    tipo_aviso.EmailContacto = wobjDataRow["emailContactoFamilia"].ToString();

                    tipo_aviso.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    tipo_aviso.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    tipo_aviso.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    tipo_aviso.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    tipo_aviso.Estado = wobjDataRow["estado"].ToString();

                    IContactoFamilia.Add(tipo_aviso);
                }
            }

            return IContactoFamilia;

        }

        public static bool ValidaEliminacionContactoFamilia(YouCom.DTO.ContactoFamiliaDTO theContactoFamiliaDTO)
        {
            DataTable pobjDataTable = new DataTable();
            bool retorno = false;
            if (YouCom.DAL.ContactoFamiliaDAL.ValidaEliminacionContactoFamilia(theContactoFamiliaDTO, ref pobjDataTable))
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
