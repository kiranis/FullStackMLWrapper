using Microsoft.AspNetCore.Mvc;
using MLWrapper.API.Models;

namespace MLWrapper.API.Controllers{
    
    [ApiController]
    [Route("[controller]")]
    public class PredictionController : ControllerBase
    {
        private readonly PythonInvoker _pythonInvoker;

        public PredictionController(PythonInvoker pythonInvoker)
        {
            _pythonInvoker = pythonInvoker;
        }

        [HttpPost]
        public async Task<IActionResult> Predict([FromBody] InputModel input)
        {
            var result = await _pythonInvoker.InvokePredictionAsync(input);
            return Ok(result);
        }
    }
}