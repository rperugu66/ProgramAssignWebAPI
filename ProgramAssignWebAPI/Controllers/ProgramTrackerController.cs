using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Mvc;
using ProgramAssignWebAPI.Models.DTO;
using ProgramAssignWebAPI.Repositories;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProgramAssignWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramTrackerController : ControllerBase
    {
        private readonly IResourceManagerAssignmentRepo _resourceManagerAssignmentRepo;
        private readonly IProgramTrackerRepo _programTrackerRepo;
        private readonly IMapper _mapper;
        private readonly ITechTracks _techTracksRepo;

        public ProgramTrackerController(IResourceManagerAssignmentRepo resourceManagerAssignmentRepo, 
            IProgramTrackerRepo programTrackerRepo,IMapper mapper
            , ITechTracks techTracksRepo)
        {
            _resourceManagerAssignmentRepo = resourceManagerAssignmentRepo;
            _programTrackerRepo = programTrackerRepo;
            _mapper = mapper;
            _techTracksRepo = techTracksRepo;
        }

        // GET: api/<ProgramTrackerController>
        [HttpGet]
        public async Task <IActionResult> GetProgramTackers()
        {
            // get data from db in domain model

            var responsedomain =await _programTrackerRepo.GetAllProgramTrackersAsync();
            // convert domain model to dto model
            var responsedto = _mapper.Map<IEnumerable<ProgramTrackerDto>>(responsedomain);
            return Ok(responsedto);

        }

        // GET api/<ProgramTrackerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramTackerById(int id)
        {
            var response = await _programTrackerRepo.GetProgramsTracker(id);
            // convert domain to dto
            var responsedto = _mapper.Map<ProgramTrackerDto>(response);
            return Ok(responsedto);
        }

        // POST api/<ProgramTrackerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProgramTrackerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProgramTrackerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        [Route("GetTechTracks")]
        [HttpGet]
        public async Task<IActionResult> GetTechTracks()
        {
            var tracks = await _techTracksRepo.GetAllTracks();
            var tracksdto = _mapper.Map<List<TechTracksDto>>(tracks);
            return Ok(tracksdto); ;
        }
       
        [Route("GetCategoriesByTechTrack/{TechTrack}")]
        [HttpGet]
        public async Task<IActionResult> GetCategoriesByTechTrack(string TechTrack)
        {
          var categories = await _programTrackerRepo.GetCategoriesByTechTrack(TechTrack);
          return Ok(categories);
        }

        [Route("GetProgramsByCategory/{TechTrack}/{Category}")]
        [HttpGet]
        public async Task<IActionResult> GetProgramsByCategory(string TechTrack, string Category)
        {
          var programs = await _programTrackerRepo.GetProgramsByCategory(TechTrack, Category);
          return Ok(programs);
        }
  }
}
