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
        private readonly IResourceManagerAssignmentRepo _ResourceManagerAssignmentsHistory;
        private readonly IMapper _mapper;

        public AssignController(IResourceManagerAssignmentRepo resourceManagerAssignmentRepo, IMapper mapper)
        {
            _ResourceManagerAssignmentsHistory = resourceManagerAssignmentRepo;
            _mapper = mapper;
        }
        // GET: api/<AssignController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Get Data From Repos == Domain Object
            var AllResources = await _ResourceManagerAssignmentsHistory.GetAllResourceAsync();

            // COnvert Domain Classs Object to DTO Class Object 
            var AllResourcesdto = _mapper.Map<List<ResourceManagerAssignmentDto>>(AllResources);
            return Ok(AllResourcesdto);
        }

        // GET api/<AssignController>/5
        [HttpGet("{id}")]
        [ActionName("GetResourceById")]
        public async Task< IActionResult> GetResourceById(int id)
        {
            var resourcedomain = await _ResourceManagerAssignmentsHistory.GetResourceById(id);
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
            addResourceDto.ProgramCode = ".";
            addResourceDto.SMEComments = ".";
            // Convert DTo to Domain 
            var addResourceDomain = _mapper.Map<ResourceMangerAssignments>(addResourceDto);

            // Call service 
            var response = await _ResourceManagerAssignmentsHistory.AddResource(addResourceDomain,addResourceDto.Category.ToString());
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
           var returnObj = await _ResourceManagerAssignmentsHistory.UpdateResource(id,resourcedomain);

            if (returnObj == null)
                return NotFound();

            // convert domain to dto and call action createdat
            var responsedto = _mapper.Map<ResourceManagerAssignmentDto>(returnObj);
            return CreatedAtAction(nameof(GetResourceById), new { id = responsedto.Id }, responsedto);



        }

        // DELETE api/<AssignController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(int id)
        {
            // pass the id to service and delete the record
            var response = await _ResourceManagerAssignmentsHistory.DeletResource(id);
            if (response == null)
                return NotFound();
            // convert domain model to dto 
            var responsedto = _mapper.Map<ResourceManagerAssignmentDto>(response);
            return Ok(responsedto);

        }
        [Route("GetResourceHistoryById/{id}")]
        [HttpGet]

        public async Task<IActionResult> GetResourceHistoryById(int id)
        {
            // call repo method
            var resp = await _ResourceManagerAssignmentsHistory.GetResourceHistoryById(id);
            //convert domain to dto 
            var respdto = _mapper.Map<List<ResourceManagerHistoryDto>>(resp);
            return Ok(respdto);
        }
        [Route("GetResourceByEmail/{email}")]
        [HttpGet]

        public async Task<IActionResult> GetResourceByEmail(string email)
        {
            var resourcedomain = await _ResourceManagerAssignmentsHistory.GetResourceByEmailId(email);
            //Check Null
            if (resourcedomain == null)
                return NotFound();
            //Convert Domain to Dto
            var resourcedto = _mapper.Map<ResourceManagerAssignmentDto>(resourcedomain);
            return Ok(resourcedto);
        }

        // PUT api/<AssignController>/5
        [Route("UpdateResourceHistory/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateResourceHistory(int id, [FromBody] UpdateResourceHistoryDto editResourceDto)
        {
            // Convert dto to domain 
            var resourcedomain = _mapper.Map<ResourceManagerAssignmentsHistory>(editResourceDto);
            // service method
            var returnObj = await _ResourceManagerAssignmentsHistory.UpdateResourceHistory(id, resourcedomain, editResourceDto.category);

            if (returnObj == null)
                return NotFound();

            // convert domain to dto and call action createdat
            var responsedto = _mapper.Map<ResourceManagerHistoryDto>(returnObj);
            return CreatedAtAction(nameof(GetResourceHistoryById), new { id = responsedto.Id }, responsedto);
        }

        [Route("UpdateResourceHistoryCode/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateResourceHistoryCode(int id, [FromBody] UpdateResourceHistoryCodeDto editResourceDto)
        {
            // Convert dto to domain 
            var resourcedomain = _mapper.Map<ResourceManagerAssignmentsHistory>(editResourceDto);
            // service method
            var returnObj = await _ResourceManagerAssignmentsHistory.UpdateResourceHistoryCode(id, resourcedomain);

            if (returnObj == null)
                return NotFound();

            // convert domain to dto and call action createdat
            var responsedto = _mapper.Map<ResourceManagerHistoryDto>(returnObj);
            return CreatedAtAction(nameof(GetResourceHistoryById), new { id = responsedto.Id }, responsedto);
        }

        [Route("GetResourceHistorySingleById/{id}")]
        [HttpGet]

        public async Task<IActionResult> GetResourceHistorySingleById(int id)
        {
            // call repo method
            var resp = await _ResourceManagerAssignmentsHistory.GetResourceHistorySingleById(id);
            //convert domain to dto 
            var respdto = _mapper.Map<ResourceManagerHistoryDto>(resp);
            return Ok(respdto);
        }

        //[Route("GetSmeByName/{SME}")]
        //[HttpGet]

        //public async Task<IActionResult> GetSmeByName(string SME)
        //{
        //    var resourcedomain = await _ResourceManagerAssignmentsHistory.GetSmeByName(SME);
        //    //Check Null
        //    if (resourcedomain == null)
        //        return NotFound();
        //    //Convert Domain to Dto
        //    var resourcedto = _mapper.Map<ResourceManagerAssignmentDto>(resourcedomain);
        //    return Ok(resourcedto);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetHistory()
        //{
        //    // Get Data From Repos == Domain Object
        //    var AllResources = await _ResourceManagerAssignmentsHistory.GetAllHistoryResourceAsync();

        //    // COnvert Domain Classs Object to DTO Class Object 
        //    var AllResourcesdto = _mapper.Map<List<ResourceManagerAssignmentsHistory>>(AllResources);
        //    return Ok(AllResourcesdto);
        //}

    }
}
