using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MS.Services.Abstract
{
    public interface IEmailSenderService
    {
        Task SendEmail(string to, string title, string text);
    }
}
