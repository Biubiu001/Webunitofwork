﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Smaple.Application.ISevice;

namespace Webunitofwork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IStudentSevice studentService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,IStudentSevice StudentSevice)
        {
            _logger = logger;
            studentService = StudentSevice;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            var result =  studentService.Add();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("AddResult")]
        public async Task<IActionResult> AddResult() {

            var result = await studentService.Add();
            return Ok(result);
        }
    }
}
