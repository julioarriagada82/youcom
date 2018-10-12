using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class ContactoFamiliaBLL
    {
        public static IList<ContactoFamiliaDTO> getListadoContactoFamilia()
        {
            YouCom.facade.ContactoFamilia ContactoFamiliaFA = new YouCom.facade.ContactoFamilia();
            var ContactoFamilia = YouCom.facade.ContactoFamilia.getListadoContactoFamilia();
            return ContactoFamilia;
        }

        public static ContactoFamiliaDTO detalleContactoFamilia(decimal idContactoFamilia)
        {
            ContactoFamiliaDTO ContactoFamilias;
            ContactoFamilias = facade.ContactoFamilia.getListadoContactoFamilia().Where(x => x.IdContactoFamilia == idContactoFamilia).First();
            return ContactoFamilias;
        }

        public static IList<ContactoFamiliaDTO> listaContactoFamiliaActivo()
        {
            IList<ContactoFamiliaDTO> ContactoFamilias;
            ContactoFamilias = facade.ContactoFamilia.getListadoContactoFamilia().Where(x => x.Estado == "1").ToList();
            return ContactoFamilias;
        }

        public static IList<ContactoFamiliaDTO> listaContactoFamiliaInactivo()
        {
            IList<ContactoFamiliaDTO> ContactoFamilias;
            ContactoFamilias = facade.ContactoFamilia.getListadoContactoFamilia().Where(x => x.Estado == "2").ToList();
            return ContactoFamilias;
        }

        public static bool Delete(DTO.ContactoFamiliaDTO myContactoFamiliaDTO)
        {
            bool resultado = ContactoFamiliaDAL.Delete(myContactoFamiliaDTO);
            return resultado;
        }

        public static bool Insert(DTO.ContactoFamiliaDTO myContactoFamiliaDTO)
        {
            bool resultado = ContactoFamiliaDAL.Insert(myContactoFamiliaDTO);
            return resultado;
        }

        public static bool Update(DTO.ContactoFamiliaDTO myContactoFamiliaDTO)
        {
            bool resultado = ContactoFamiliaDAL.Update(myContactoFamiliaDTO);
            return resultado;
        }

        public static bool ActivaContactoFamilia(ContactoFamiliaDTO theContactoFamiliaDTO)
        {
            bool respuesta = YouCom.DAL.ContactoFamiliaDAL.ActivaContactoFamilia(theContactoFamiliaDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionContactoFamilia(ContactoFamiliaDTO theContactoFamiliaDTO)
        {
            bool respuesta = facade.ContactoFamilia.ValidaEliminacionContactoFamilia(theContactoFamiliaDTO);
            return respuesta;
        }
    }
}
