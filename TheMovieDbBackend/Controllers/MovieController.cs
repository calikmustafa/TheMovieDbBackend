using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheMovieDbBackend.API.Helpers;
using TheMovieDbBackend.Core.Entity;
using TheMovieDbBackend.Service;
using System.Text.Json;
using TheMovieDbBackend.Core.Pagination;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using TheMovieDbBackend.API.FluentValidation;
using TheMovieDbBackend.Library.ValidationTool;

namespace TheMovieDbBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<MovieController> _logger;


        public MovieController(IUnitOfWork unitOfWork, ILogger<MovieController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        
        
        [HttpGet("{movieId}/{pageSize}")]
        
        public   async Task<ActionResult<Movie>> GetMovieListWithPageSize( int movieId,int pageSize)
        {

            
            try
            {
                var client = new HttpClient();
                var url = _unitOfWork.MovieRepository.GetAllMovieByPageSizeAndMovieId(movieId,pageSize);
                var response = await client.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<Movie>(response);
                return Ok(data);
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError,ex.InnerException.ToString());
            }
;        }

        [HttpGet("{movieId}")]

        public async Task<ActionResult<Movie>> GetMovieDetailWithMovieId(int movieId)
        {


            try
            {
                var client = new HttpClient();
                var url = _unitOfWork.MovieRepository.GetAllMovieDetailByMovieId(movieId);
                var response = await client.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<MovieDetail>(response);
                return Ok(data);
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.InnerException.ToString());
            }
;
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] MovieDb movieDb)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                ValidationTool.Validate(new MovieDbValidation(), movieDb);
                await _unitOfWork.MovieDbRepository.AddAsync(movieDb);
                await _unitOfWork.SaveAll();
                return Ok("Model is valid,Customer is Added");
                _logger.LogInformation("Log Success");
            }
            catch (Exception error)
            {
                
                throw;
            }
        }

        
    }
}
