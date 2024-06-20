using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouponsV2.Application.Interfaces
{
    public interface IEmailRepository
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
    }
}