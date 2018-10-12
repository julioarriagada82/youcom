using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouCom.DTO;
using YouCom.Mensajeria.DAL;

namespace YouCom.bll.Mensajeria
{
    public class SalasChatBLL
    {
        public static IQueryable<Room> getListadoSalas(decimal idCondominio)
        {
            LinqChatDataContext db = new LinqChatDataContext();

            var room = (from r in db.Rooms
                        where r.idCondominio == idCondominio
                        select r);


            return room;
        }
    }
}
