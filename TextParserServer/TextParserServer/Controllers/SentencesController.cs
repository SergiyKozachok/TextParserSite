using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TextParserServer.Interfaces;
using TextParserServer.Models;

namespace TextParserServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentencesController : ControllerBase
    {
        private readonly ISentenceService _sentenceService;
        public SentencesController(ISentenceService sentenceService)
        {
            _sentenceService = sentenceService;
        }

        [HttpGet("allsentences")]
        public IActionResult GetAllAppointments([FromQuery] PageParameters parameters)
        {
            var result = _sentenceService.GetSentences(parameters);

            return Ok(
                new
                {
                    sentences = result.Entities,
                    quantity = result.EntityAmount
                }
            );
        }

        [HttpPost("addsentences")]
        public IActionResult AddSentences([FromBody] GetSentencesModel creationModel)
        {
            var status = _sentenceService.AddSentencesToDb(creationModel);

            return status ? (IActionResult)Ok() : BadRequest();
        }
		
    }
}