using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouCom.DTO
{
    [Serializable()]
    public class TrxHorasFechasDTO
    {
        public TrxHorasFechasDTO()
        {
        }
        public DateTime FechaHora { get; set; }
    }
}
