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
                    YouCom.DTO.ContactoFamiliaDTO contacto_familia = new YouCom.DTO.ContactoFamiliaDTO();

                    contacto_familia.IdContactoFamilia = decimal.Parse(wobjDataRow["IdContactoFamilia"].ToString());

                    YouCom.DTO.Propietario.CasaDTO myCasaDTO = new YouCom.DTO.Propietario.CasaDTO();
                    myCasaDTO.IdCasa = decimal.Parse(wobjDataRow["idCasa"].ToString());
                    contacto_familia.TheCasaDTO = myCasaDTO;

                    YouCom.DTO.Propietario.ParentescoDTO myParentescoDTO = new YouCom.DTO.Propietario.ParentescoDTO();
                    myParentescoDTO.IdParentesco = decimal.Parse(wobjDataRow["idParentesco"].ToString());
                    contacto_familia.TheParentescoDTO = myParentescoDTO;

                    YouCom.DTO.Seguridad.CondominioDTO myCondominio = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominio.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    contacto_familia.TheCondominioDTO = myCondominio;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    contacto_familia.TheComunidadDTO = myComunidadDTO;

                    contacto_familia.NombreContacto = wobjDataRow["nombreContactoFamilia"].ToString();
                    contacto_familia.TelefonoContacto = wobjDataRow["telefonoContactoFamilia"].ToString();
                    contacto_familia.EmailContacto = wobjDataRow["emailContactoFamilia"].ToString();

                    contacto_familia.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    contacto_familia.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    contacto_familia.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    contacto_familia.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    contacto_familia.Estado = wobjDataRow["estado"].ToString();

                    IContactoFamilia.Add(contacto_familia);
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
