using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniMailProject.Core.DTOs;

namespace MiniMailProject.API.Controllers
{
    
    public class CustomBaseController : ControllerBase
    {
        [NonAction] // Bunun EndPoint Olmadığını Belirttik
        public IActionResult CreateActionResult<T> (CustomResponseDto<T> response)
        {
            // 204 geriye birşey dönmeyen durum kodu
            if(response.StatusCode == 204)            
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };

            // 204 değilse buradan devam edecek
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
