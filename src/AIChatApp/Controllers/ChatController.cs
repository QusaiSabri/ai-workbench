using AIChatApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.AI;

namespace AIChatApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;

        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChatRequest request)
        {
            var client = _chatService.GetClient(request.Model);
            var response = await client.GetResponseAsync(request.Messages, request.Options);
            return Ok(response);
        }
    }
}

public class ChatRequest
{
    public string Model { get; set; }
    public IEnumerable<ChatMessage> Messages { get; set; }
    public ChatOptions? Options { get; set; }
}
