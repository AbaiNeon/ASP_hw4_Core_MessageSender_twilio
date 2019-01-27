using MS.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MS.Services
{
    public class EmailService : IEmailSenderService
    {
        public Task SendEmail(string to, string title, string text)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            string mailFrom = "abai20100@gmail.com";
            MailAddress _from = new MailAddress(mailFrom, "Abai");
            // кому отправляем
            MailAddress _to = new MailAddress(to);
            // создаем объект сообщения
            MailMessage m = new MailMessage(_from, _to);
            // тема письма
            m.Subject = title;
            // текст письма
            m.Body = text;
            // письмо представляет код html
            m.IsBodyHtml = false;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

            // логин и пароль
            string password = "pass";
            smtp.Credentials = new NetworkCredential(mailFrom, password);
            smtp.EnableSsl = true;
            smtp.Send(m);

            return null;
        }
    }
}
