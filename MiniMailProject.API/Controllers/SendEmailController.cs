using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniMailProject.Core.DTOs;
using MiniMailProject.Core.Entities;
using MiniMailProject.Core.Services;

namespace MiniMailProject.API.Controllers
{
    
    [Route("api/sendmail")]
    [ApiController]
    public class SendEmailController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<SendMail> _service;
        private readonly ISendMailService _sendMailService;

        public SendEmailController(IMapper mapper, IService<SendMail> service,ISendMailService service2)
        {
            _mapper = mapper;
            _service = service;
            _sendMailService = service2;
        }

        // GET api/sendmails
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emails = await _service.TGetAllAsync();
            var emailDtos = _mapper.Map<List<SendMailDto>>(emails.ToList());

            return CreateActionResult(CustomResponseDto<List<SendMailDto>>.Success(200, emailDtos));
        }

        // Get api/sendmails/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var email = await _service.TGetByIdAsync(id);
            var emailDto = _mapper.Map<SendMailDto>(email);

            return CreateActionResult(CustomResponseDto<SendMailDto>.Success(200, emailDto));
        }

        [HttpGet]
        [Route("tomail-list")]
        public async Task<IActionResult> GetToMailList()
        {
            var toMailList = await _sendMailService.ToMailList();
            return Ok(toMailList);
        }


        [HttpPost]
        public async Task<IActionResult> Save(SendMailDto sendMailDto)
        {
            // 201 dönüyorum Oluşturuldu anlamına geliyor

            var sendEmail = await _service.TAddAsync(_mapper.Map<SendMail>(sendMailDto));
            var sendEmailDto = _mapper.Map<SendMailDto>(sendEmail);
            return CreateActionResult(CustomResponseDto<SendMailDto>.Success(201, sendEmailDto));
        }

        [HttpPost]
        [Route("ischeck-sendmail")]
        public async Task<IActionResult> isCheckMailSave(SendMailDto sendMailDto)
        {
            var data = await _sendMailService.isCheckSendMailAsync(sendMailDto);
            return CreateActionResult(data);
        }

        // Delete api/sendmails/3

        [HttpDelete("id")]
        public async Task<IActionResult> Delete (int id)
        {
            var deletedMail = await _service.TGetByIdAsync(id);

            if(deletedMail == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404,"Bu İd'ye Sahip Mail Bulunamadı"));
            }            
            await _service.TDeleteAsync(deletedMail);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        } 
    }
}
