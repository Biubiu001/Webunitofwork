using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smaple.Application.ISevice;

namespace Webunitofwork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        private readonly ILogger<SchoolController> _logger;
        private readonly IStudentSevice studentService ;
        public SchoolController(IStudentSevice StudentSevice, ILogger<SchoolController> logger)
        {
            _logger = logger;
            studentService = StudentSevice;
        }

     //   [Action("GetResult")]
        [HttpPost]
        public async Task<IActionResult> GetResult() {
           var result= await studentService.Add();
            return Ok(result);
        
        }
    }
}