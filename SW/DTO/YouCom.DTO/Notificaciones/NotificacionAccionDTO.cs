namespace YouCom.DTO.Notificaciones
{
    public class NotificacionAccionDTO : MantenedoresBase
    {
        private decimal _idNotificacionAccion;

        public decimal IdNotificacionAccion
        {
            get { return _idNotificacionAccion; }
            set { _idNotificacionAccion = value; }
        }
        private string _nombreNotificacionAccion;

        public string NombreNotificacionAccion
        {
            get { return _nombreNotificacionAccion; }
            set { _nombreNotificacionAccion = value; }
        }
    }
}
