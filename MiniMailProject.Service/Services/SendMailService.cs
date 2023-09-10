using AutoMapper;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MiniMailProject.Core.Configuration;
using MiniMailProject.Core.DTOs;
using MiniMailProject.Core.Entities;
using MiniMailProject.Core.Repositories;
using MiniMailProject.Core.Services;
using MiniMailProject.Core.UnitOfWorks;
using MiniMailProject.Repository.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace MiniMailProject.Service.Services
{
    public class SendMailService : Service<SendMail>, ISendMailService
    {
        private readonly ISendMailRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly EmailSettings _emailSettings;

        public SendMailService(IGenericRepository<SendMail> repository, IUnitOfWork unitOfWork, ISendMailRepository sendMailrepository,IOptions<EmailSettings> emailOptions) : base(repository, unitOfWork)
        {            
            _repository = sendMailrepository;
            _unitOfWork = unitOfWork;
            _emailSettings = emailOptions.Value;
        }


        bool isCheckMail(string mail)
        {
            Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
            return validateEmailRegex.IsMatch(mail);
        }

        public async Task<List<ToMailDto>> ToMailList()
        {
            return await _repository.ToMailList();
        }

        public async Task<CustomResponseDto<NoContentDto>> isCheckSendMailAsync(SendMailDto sendMaildto)
        {
            if (sendMaildto == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(400, "Eksik Alanlar Mevcut");
            }

            bool isValidate = isCheckMail(sendMaildto.To);

            if (!isValidate)
            {
                return CustomResponseDto<NoContentDto>.Fail(400, "E-Posta Adresi Geçersiz");
            }

            var sendEmail = await _repository.isCheckSendMailAsync(sendMaildto);            
            bool isComplete = await ValidateAndSendMailAsync(isValidate, sendMaildto);

            if (isComplete)
            {
                await _unitOfWork.CommitAsync();
                return CustomResponseDto<NoContentDto>.Success(201);
            }

            return CustomResponseDto<NoContentDto>.Fail(400, "Geçersiz İşlem");
        }


        public async Task<bool> ValidateAndSendMailAsync(bool isValidate, SendMailDto sendMaildto)
        {
            try
            {
                MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("SSTEK Mail Project", _emailSettings.Email);
                MailboxAddress mailboxAdressTo = new MailboxAddress("SSTEK Employees", sendMaildto.To);

                mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAdressTo);                

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = sendMaildto.Body;
                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = sendMaildto.Subject;

                using (var smtpClient = new SmtpClient())
                {
                    await smtpClient.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, false);
                    await smtpClient.AuthenticateAsync(_emailSettings.Email, _emailSettings.Password);
                    await smtpClient.SendAsync(mimeMessage);
                    await smtpClient.DisconnectAsync(true);
                }
                // Email sending completed
                return true; 
            }
            catch (Exception ex)
            {
                // Email sending failed
                return false; 
            }
        }
    }
}
