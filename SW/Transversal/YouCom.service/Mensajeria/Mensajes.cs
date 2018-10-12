using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Xml;

namespace YouCom.Service.Mensajeria
{
    public class Mensajes
    {
        public static bool SendEmail(string pSubject, string pBody, MailAddress to, MailAddress from, string cc, string bcc)
        {
            try
            {
                string[] _server = YouCom.Service.Configuracion.Config.GetPropiedad("SMTP").Split(new Char[] { ';' });

                System.Net.Mail.MailMessage _mail = new System.Net.Mail.MailMessage();

                _mail.From = new MailAddress(from.Address, from.DisplayName, System.Text.Encoding.UTF8);
                _mail.To.Add(new MailAddress(to.Address, to.DisplayName, System.Text.Encoding.UTF8));

                if (!string.IsNullOrEmpty(cc))
                {
                    foreach (string _cc in cc.Split(new Char[] { ';' }))
                        _mail.CC.Add(new System.Net.Mail.MailAddress(_cc));
                }

                if (!string.IsNullOrEmpty(bcc))
                {
                    foreach (string _bcc in bcc.Split(new Char[] { ';' }))
                        _mail.Bcc.Add(new System.Net.Mail.MailAddress(_bcc));
                }

                _mail.Subject = pSubject;
                _mail.SubjectEncoding = System.Text.Encoding.UTF8;
                
                _mail.Body = pBody;
                _mail.BodyEncoding = System.Text.Encoding.UTF8;
                _mail.IsBodyHtml = true;

                SmtpClient _smtp = new SmtpClient();
                _smtp.Credentials = new System.Net.NetworkCredential(_server[2], _server[3]);
                _smtp.Host = _server[0];
                _smtp.Port = Convert.ToInt32(_server[1]);

                _smtp.Send(_mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
