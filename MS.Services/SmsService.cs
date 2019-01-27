using MS.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace MS.Services
{
    public class SmsService : ISmsSenderService
    {
        public Task SendSms(string to, string text)
        {
            const string accountSid = "AC5fef99927dec88b25982625f233afecf";
            const string authToken = "token";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: text,
                from: new Twilio.Types.PhoneNumber("+17028307350"),
                to: new Twilio.Types.PhoneNumber(to)
            );

            return null;
        }
    }
}
