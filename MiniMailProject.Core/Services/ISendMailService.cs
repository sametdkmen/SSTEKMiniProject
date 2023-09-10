using MiniMailProject.Core.DTOs;
using MiniMailProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMailProject.Core.Services
{
    public interface ISendMailService : IService<SendMail>
    {
        Task<CustomResponseDto<NoContentDto>> isCheckSendMailAsync(SendMailDto sendMaildto);

        Task<List<ToMailDto>> ToMailList();
    }
}
