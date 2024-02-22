using Desafio.KeyWorks.Models.DTOs;
using Desafio.KeyWorks.Services;
using Microsoft.AspNetCore.Mvc;


namespace Desafio.KeyWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamingController : ControllerBase
    {
        public StreamingService _streamingService;
        public StreamingController(StreamingService streamingService)
        {
            _streamingService = streamingService;
        }

        /// <summary>
        /// Obtem todos os Streamings
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_streamingService.Get());
        }

        /// <summary>
        ///  Adiciona um novo Streaming
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] CreateStreamingDTO dto)
        {
            var streaming = _streamingService.Create(dto);
            return Ok(streaming);    
        }

    }
}
