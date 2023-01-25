using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgramAssignWebAPI.Models.Domain;
using ProgramAssignWebAPI.Models.DTO;
using ProgramAssignWebAPI.Repositories;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProgramAssignWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignController : ControllerBase
    {
        private readonly IResourceManagerAssignmentRepo _resourceManagerAssignmentRepo;
        private readonly IMapper _mapper;

        public AssignController(IResourceManagerAssignmentRepo resourceManagerAssignmentRepo, IMapper mapper)
        {
            _resourceManagerAssignmentRepo = resourceManagerAssignmentRepo;
            _mapper = mapper;
        }
        // GET: api/<AssignController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Get Data From Repos == Domain Object
            var AllResources = await _resourceManagerAssignmentRepo.GetAllResourceAsync();

            // COnvert Domain Classs Object to DTO Class Object 
            var AllResourcesdto = _mapper.Map<List<ResourceManagerAssignmentDto>>(AllResources);
            return Ok(AllResourcesdto);
        }

        // GET api/<AssignController>/5
        [HttpGet("{id}")]
        [ActionName("GetResourceById")]
        public async Task< IActionResult> GetResourceById(int id)
        {
            var resourcedomain = await _resourceManagerAssignmentRepo.GetResourceById(id);
            //Check Null
            if (resourcedomain == null)
                return NotFound();
            //Convert Domain to Dto
            var resourcedto = _mapper.Map<ResourceManagerAssignmentDto>(resourcedomain);
            return Ok(resourcedto);
        }


        // POST api/<AssignController>
        [HttpPost]
        public async Task<IActionResult> AddResource([FromBody]AddResourceDto addResourceDto)
        {
            addResourceDto.ProgramStatus = "Open";
            addResourceDto.SMEStatus = "Open";
            // Convert DTo to Domain 
            var addResourceDomain = _mapper.Map<ResourceMangerAssignments>(addResourceDto);

            // Call service 
            var response = await _resourceManagerAssignmentRepo.AddResource(addResourceDomain);
            var responsedto = _mapper.Map<ResourceManagerAssignmentDto>(response);


            // Return Create Item 
            return CreatedAtAction(nameof(GetResourceById), new { id = responsedto.Id } , responsedto);

        }

        // PUT api/<AssignController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EditResourceDto editResourceDto)
        {
            // Convert dto to domain 
           var  resourcedomain = _mapper.Map<ResourceMangerAssignments>(editResourceDto);
           // service method
           var returnObj = await _resourceManagerAssignmentRepo.UpdateResource(id,resourcedomain);

            if (returnObj == null)
                return NotFound();

            // convert domain to dto and call action createdat
            var responsedto = _mapper.Map<ResourceManagerAssignmentDto>(returnObj);
            return CreatedAtAction(nameof(GetResourceById), new { id = responsedto.Id }, responsedto);



        }

        // DELETE api/<AssignController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
