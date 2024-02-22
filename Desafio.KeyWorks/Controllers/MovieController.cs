using Desafio.KeyWorks.Models.DTOs;
using Desafio.KeyWorks.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;



namespace Desafio.KeyWorks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private MovieService _movieService;
        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Obtem todos os filmes
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_movieService.Get());
        }

        /// <summary>
        /// Obtem os filmes agrupado pela categoria
        /// </summary>
        [HttpGet("group")]
        public IActionResult GetMoviesGrouped()
        {
            return Ok(_movieService.GetByGroup());
        }

        /// <summary>
        /// Obtem os filmes pelo ano de lançamento
        /// </summary>
        [HttpGet("release/{year}")]
        public IActionResult GetMoviesByYear(int year)
        {
            return Ok(_movieService.GetByYear(year));
        }

        /// <summary>
        /// Obtem os filmes de acordo com a avaliação
        /// </summary>
        [HttpGet("rate/{rate}")]
        public IActionResult GetMoviesByRate(int rate)
        {
            return Ok(_movieService.GetByRate(rate));
        }

        /// <summary>
        /// Obtem a média da categoria pelo ano de lançamento dos filmes 
        /// </summary>
        [HttpGet("group/{category}/{release}/average")]
        public IActionResult GetMoviesAverageByCategory(string category, int release)
        {
            return Ok(_movieService.GetAverageByCategory(category, release));
        }

        /// <summary>
        /// Adiciona uma avaliação ao filme 
        /// </summary>
        [HttpPost("rate")]
        public IActionResult AddRate([FromBody] AddMovieRateDto dto)
        {
            return Ok(_movieService.AddRate(dto));
        }

        /// <summary>
        /// Adiciona um filme
        /// </summary>
        [HttpPost]
        public IActionResult Post([FromBody] CreateMovieDto dto)
        {
            return Ok(_movieService.Create(dto));
        }

        /// <summary>
        /// Atualiza um filme
        /// </summary>
        [HttpPatch]
        public IActionResult Patch([FromBody] UpdateMovieDto dto)
        {
            return Ok(_movieService.Update(dto));
        }

        /// <summary>
        /// Exclui um filme
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return Ok();
        }
    }
}
