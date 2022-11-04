using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Score.Models;
using Scoreee.Services;
using static ScoreServices.ScoreServices;

namespace Scoreee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreecsController : ControllerBase
    {
        IScoreecs _Scoreecs;
        public ScoreecsController(IScoreecs scoreecs)
        {
            _Scoreecs = scoreecs;
        }
        [HttpGet]
        public IActionResult GetScore()
        {
            try
            {
                var GetSecote = _Scoreecs.Getscores();
                if (GetSecote == null) return NotFound();
                return Ok(GetSecote);              
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpGet("byid")]
        public IActionResult GetByid(int ScoreId)
        {
            try
            {
                var id = _Scoreecs.getScorByid(ScoreId);
                return Ok(id);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpPost]
        public IActionResult Post(ScoreList _scoree)
        {
            try
            {
                var post = _Scoreecs.PostScoree(_scoree);
                if (post == null) return NotFound();
                return Ok(post);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpDelete]
        public IActionResult DeleteScroe(int ScoreId)
        {
            try
            {
                var Delete = _Scoreecs.DeleteScore(ScoreId);
                return Ok(Delete);

            }
            catch (Exception)
            {

                return BadRequest() ;
            }
            
        }
    }
}
