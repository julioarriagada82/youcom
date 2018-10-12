using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace YouCom.facade
{
    public class RankingServicio
    {
        public static IList<YouCom.DTO.Servicio.RankingServicioDTO> getListadoRankingServicio()
        {
            IList<YouCom.DTO.Servicio.RankingServicioDTO> IRankingServicio = new List<YouCom.DTO.Servicio.RankingServicioDTO>();

            DataTable pobjDataTable = new DataTable();

            if (YouCom.DAL.RankingServicioDAL.getListadoRankingServicio(ref pobjDataTable))
            {
                foreach (DataRow wobjDataRow in pobjDataTable.Rows)
                {
                    YouCom.DTO.Servicio.RankingServicioDTO ranking = new YouCom.DTO.Servicio.RankingServicioDTO();

                    ranking.IdRanking = decimal.Parse(wobjDataRow["IdRanking"].ToString());

                    YouCom.DTO.Seguridad.CondominioDTO myCondominioDTO = new YouCom.DTO.Seguridad.CondominioDTO();
                    myCondominioDTO.IdCondominio = decimal.Parse(wobjDataRow["idCondominio"].ToString());
                    ranking.TheCondominioDTO = myCondominioDTO;

                    YouCom.DTO.Seguridad.ComunidadDTO myComunidadDTO = new YouCom.DTO.Seguridad.ComunidadDTO();
                    myComunidadDTO.IdComunidad = decimal.Parse(wobjDataRow["idComunidad"].ToString());
                    ranking.TheComunidadDTO = myComunidadDTO;

                    YouCom.DTO.Servicio.EmpresaServicioDTO myEmpresaServicioDTO = new YouCom.DTO.Servicio.EmpresaServicioDTO();
                    myEmpresaServicioDTO.IdEmpresaServicio = decimal.Parse(wobjDataRow["idEmpresaServicio"].ToString());
                    ranking.TheEmpresaServicioDTO = myEmpresaServicioDTO;

                    YouCom.DTO.Propietario.FamiliaDTO myFamiliaDTO = new YouCom.DTO.Propietario.FamiliaDTO();
                    myFamiliaDTO.IdFamilia = decimal.Parse(wobjDataRow["idFamilia"].ToString());
                    ranking.TheFamiliaDTO = myFamiliaDTO;

                    ranking.Comentario = wobjDataRow["comentario"].ToString();
                    ranking.Nota = int.Parse(wobjDataRow["nota"].ToString());
                    ranking.FechaRanking = Convert.ToDateTime(wobjDataRow["fechaRanking"].ToString());

                    ranking.UsuarioIngreso = wobjDataRow["usuario_ingreso"].ToString();
                    ranking.FechaIngreso = wobjDataRow["fecha_ingreso"].ToString();
                    ranking.UsuarioModificacion = wobjDataRow["usuario_modificacion"].ToString();
                    ranking.FechaModificacion = wobjDataRow["fecha_modificacion"].ToString();

                    ranking.Estado = wobjDataRow["estado"].ToString();

                    IRankingServicio.Add(ranking);
                }
            }

            return IRankingServicio;

        }
    }
}

