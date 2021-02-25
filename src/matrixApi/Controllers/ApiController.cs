using System;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using matrixApi.Containers;
using matrixApi.Services;

namespace matrixApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly IArithmeticService _arithmeticService;

        public ApiController(ILogger<ApiController> logger, IArithmeticService arithmeticService)
        {
            _logger = logger;
            _arithmeticService = arithmeticService;
        }

        [HttpGet("multiply")]
        public IActionResult Get(MatrixMultiplicationRequest request)
        {
            var requestId = request.Id;

            try
            {
                _logger.LogInformation($"Validating request { requestId }");

                var validationResult = _arithmeticService.Validate(request);

                if (!validationResult.Successful)
                {
                    _logger.LogWarning($"Validation unsuccessful for request { requestId }");

                    return BadRequest(validationResult);
                }

                _logger.LogInformation($"Validation successful, handling request { requestId }");

                var response = _arithmeticService.Handle(request);

                return Ok(response);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error handling request { requestId }: { ex.Message }");

                return BadRequest(ex.Message);
            }
        }
    }
}