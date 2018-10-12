using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.DAL;

namespace YouCom.bll
{
    public class CargoBLL
    {
        public static IList<CargoDTO> getListadoCargo()
        {
            YouCom.facade.Cargo CargoFA = new YouCom.facade.Cargo();
            var Cargo = YouCom.facade.Cargo.getListadoCargo();
            return Cargo;
        }

        public static CargoDTO detalleCargo(decimal idCargo)
        {
            CargoDTO Cargos;
            Cargos = facade.Cargo.getListadoCargo().Where(x => x.IdCargo == idCargo).First();
            return Cargos;
        }

        public static IList<CargoDTO> listaCargoActivo()
        {
            IList<CargoDTO> Cargos;
            Cargos = facade.Cargo.getListadoCargo().Where(x => x.Estado == "1").ToList();
            return Cargos;
        }

        public static IList<CargoDTO> listaCargoInactivo()
        {
            IList<CargoDTO> Cargos;
            Cargos = facade.Cargo.getListadoCargo().Where(x => x.Estado == "2").ToList();
            return Cargos;
        }

        public static bool Delete(DTO.CargoDTO myCargoDTO)
        {
            bool resultado = CargoDAL.Delete(myCargoDTO);
            return resultado;
        }

        public static bool Insert(DTO.CargoDTO myCargoDTO)
        {
            bool resultado = CargoDAL.Insert(myCargoDTO);
            return resultado;
        }

        public static bool Update(DTO.CargoDTO myCargoDTO)
        {
            bool resultado = CargoDAL.Update(myCargoDTO);
            return resultado;
        }

        public static bool ActivaCargo(CargoDTO theCargoDTO)
        {
            bool respuesta = YouCom.DAL.CargoDAL.ActivaCargo(theCargoDTO);
            return respuesta;
        }

        public static bool ValidaEliminacionCargo(CargoDTO theCargoDTO)
        {
            bool respuesta = facade.Cargo.ValidaEliminacionCargo(theCargoDTO);
            return respuesta;
        }
    }
}
