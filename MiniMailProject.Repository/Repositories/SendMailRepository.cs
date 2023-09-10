using Microsoft.EntityFrameworkCore;
using MiniMailProject.Core.DTOs;
using MiniMailProject.Core.Entities;
using MiniMailProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniMailProject.Repository.Repositories
{
    public class SendMailRepository : GenericRepository<SendMail>, ISendMailRepository
    {
        public SendMailRepository(MailDbContext context) : base(context)
        {
        }

        public async Task<SendMailDto> isCheckSendMailAsync(SendMailDto sendMaildto)
        {            
            await _context.SendMail.AddAsync(new SendMail { To = sendMaildto.To,Body = sendMaildto.Body, Subject = sendMaildto.Subject, CreatedDate = DateTime.Now});
            return sendMaildto;
        }

        public async Task<List<ToMailDto>> ToMailList()
        {
            // SendMail Tablomuzun İçindeki To Sütununu Dto İçinde ki To Propertysine Aktardık.
            // Distinct İle Aynı Mail Adreslerinin Tekrar Tekrar Gönderilmemesini Sağlamış Olduk.
            return await _context.SendMail
                .Select(x => new ToMailDto { To = x.To }).Distinct()
                .ToListAsync();
        }        

    }
}
