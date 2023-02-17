using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProgramAssignWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VAMHolidayController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetEndDate(DateTime startDate)
        {
            int workingDays = 0;
            var holidays = new List<DateTime>() { new DateTime(2023, 3, 22), new DateTime(2023, 7, 2) }; // list of holidays
            var endDate = startDate;
            while (workingDays < 3)
            {
                endDate = endDate.AddDays(1);
                if (endDate.DayOfWeek == DayOfWeek.Saturday || endDate.DayOfWeek == DayOfWeek.Sunday || holidays.Contains(endDate.Date))
                {
                    continue;
                }
                workingDays++;
            }
            return Ok(endDate);
        }

    }
}


