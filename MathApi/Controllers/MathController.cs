using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MathApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MathApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : Controller
    {
        private readonly ILogger<MathController> _logger;

        public MathController(ILogger<MathController> logger)
        {
            _logger = logger;
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddAsync(
       [FromQuery] long a,
       [FromQuery] long b,
       [FromServices] IMathService mathService)
        {
            var result = await mathService.AddAsync(a, b);
            return Ok(new { result = result });
        }
    }
}