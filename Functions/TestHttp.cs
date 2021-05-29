using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Functions
{
    public class TestHttp
    {
        private readonly SmtpSettings _settings;

        public TestHttp(SmtpSettings settings)
        {
            _settings = settings;
        }
        [FunctionName("TestHttp")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]
            HttpRequest req, ILogger log)
        {
             return new OkObjectResult(_settings.Email);
        }
    }
}