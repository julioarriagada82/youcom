using System;

namespace YouCom.Service.Mensajeria
{
    public class PlantillaCorreo
    {
        public static string CuerpoCorreoAgregaGrupoTrabajo(string nombre_personal, string cod_propuesta, string nombre_propuesta, string nombre_responsable)
        {
            String result = string.Empty;
            try
            {
                string path = System.AppDomain.CurrentDomain.BaseDirectory;
                result = System.IO.File.ReadAllText(path + "/Plantillas/propuesta_agrega_grupo_trabajo.html");

                result = YouCom.Service.Generales.General.replace("[nombre_personal]", nombre_personal, result);
                result = YouCom.Service.Generales.General.replace("[cod_propuesta]", cod_propuesta, result);
                result = YouCom.Service.Generales.General.replace("[nombre_propuesta]", nombre_propuesta, result);
                result = YouCom.Service.Generales.General.replace("[nombre_responsable]", nombre_responsable, result);
            }
            #region Catch
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion

            return result;
        }

        public static string CuerpoCorreoEliminaGrupoTrabajo(string nombre_personal, string cod_propuesta, string nombre_propuesta, string nombre_responsable)
        {
            String result = string.Empty;
            try
            {
                string path = System.AppDomain.CurrentDomain.BaseDirectory;
                result = System.IO.File.ReadAllText(path + "/Plantillas/propuesta_elimina_grupo_trabajo.html");

                result = YouCom.Service.Generales.General.replace("[Personal_nombre]", nombre_personal, result);
                result = YouCom.Service.Generales.General.replace("[cod_propuesta]", cod_propuesta, result);
                result = YouCom.Service.Generales.General.replace("[nombre_propuesta]", nombre_propuesta, result);
                result = YouCom.Service.Generales.General.replace("[Gestor_nombre]", nombre_responsable, result);
            }
            #region Catch
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion

            return result;
        }
    }
}
