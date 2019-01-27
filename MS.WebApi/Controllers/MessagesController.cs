using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MS.Models;
using MS.Services.Abstract;

namespace MS.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly Context _db;
        private readonly ISmsSenderService _smsSenderService;
        private readonly IEmailSenderService _emailSenderService;

        public MessagesController(Context context, IEmailSenderService emailService, ISmsSenderService smsService)
        {
            _db = context;
            _smsSenderService = smsService;
            _emailSenderService = emailService;
        }

        // GET: api/Messages/GetMessages
        [HttpGet]
        public IEnumerable<Message> GetMessages()
        {
            return _db.Messages;
        }

        // POST: api/Messages/SendMessage
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] Message message)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Messages.Add(message);
            await _db.SaveChangesAsync();

            string result = Send(message);
            return Ok(result);
            //return RedirectToAction("Send", "Messages", new { message = message });
        }

        private string Send(Message message)
        {
            if (message.Type.ToLower() == "sms")
            {
                _smsSenderService.SendSms(message.To, message.MessageText);
                return "Sended sms";
            }
            else if (message.Type.ToLower() == "email")
            {
                _emailSenderService.SendEmail(message.To, "title", message.MessageText);
                return "Sended email";
            }
            else
            {
                return "Invalid message sending type";
            }
            
        }

       
    }
}