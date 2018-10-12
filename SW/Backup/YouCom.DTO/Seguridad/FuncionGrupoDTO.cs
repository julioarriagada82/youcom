using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO.Seguridad
{
    public class FuncionGrupoDTO : MantenedoresBase
    {
        private string _funcionGrupoCod;
        public string FuncionGrupoCod
        {
            get { return _funcionGrupoCod; }
            set { _funcionGrupoCod = value; }
        }
        private string _funcionGrupoNombre;
        public string FuncionGrupoNombre
        {
            get { return _funcionGrupoNombre; }
            set { _funcionGrupoNombre = value; }
        }

        private string _funcionGrupoTipo;
        public string FuncionGrupoTipo
        {
            get { return _funcionGrupoTipo; }
            set { _funcionGrupoTipo = value; }
        }

        List<FuncionDTO> funciones;

        public List<FuncionDTO> Funciones
        {
            get { return funciones; }
            set { funciones = value; }
        }
    }
}
