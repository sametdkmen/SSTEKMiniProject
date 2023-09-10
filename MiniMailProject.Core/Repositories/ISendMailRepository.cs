using MiniMailProject.Core.DTOs;
using MiniMailProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMailProject.Core.Repositories
{
    public interface ISendMailRepository : IGenericRepository<SendMail>
    {
        Task<SendMailDto> isCheckSendMailAsync(SendMailDto sendMail);

        Task<List<ToMailDto>> ToMailList();
    }
}
