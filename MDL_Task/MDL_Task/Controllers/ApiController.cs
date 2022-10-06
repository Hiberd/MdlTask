using MDLTask.Api.Contracts;
using MDLTask.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MDLTask.Api.Controllers
{

    [ApiController]
    [Route("[controller]/mails")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly IMessageService _messageService;

        public ApiController(ILogger<ApiController> logger, IMessageService messageService)
        {
            _logger = logger;
            _messageService = messageService;
        }


        /// <summary>
        /// Send message and add to the database.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] CreateMailRequest request)
        {
            var message = Message.Create(request.Subject, request.Body, request.Recipients);

            if (message.IsFailure)
            {
                _logger.LogError(message.Error);
                return BadRequest(message.Error);
            }

            var result = await _messageService.SendAndAddtoDatabase(message.Value);

            if (result.IsFailure)
            {
                _logger.LogError(result.Error);
                return BadRequest(result.Error);
            }

            return Ok(result.Value);
        }

        /// <summary>
        /// Get all messages.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var messages = await _messageService.Get();

            return Ok(messages);
        }
    }
}
