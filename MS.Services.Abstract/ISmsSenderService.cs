using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MS.Services.Abstract
{
    public interface ISmsSenderService
    {
        Task SendSms(string to, string text);
    }
}
