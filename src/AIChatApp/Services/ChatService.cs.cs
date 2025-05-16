using Microsoft.Extensions.AI;
using OllamaSharp;

namespace AIChatApp.Services
{
    public class ChatService
    {
        private readonly Uri _ollamaUri = new("http://localhost:11434");
        private readonly Dictionary<string, IChatClient> _clients = new();

        public IChatClient GetClient(string model)
        {
            if (!_clients.TryGetValue(model, out var client))
            {
                client = new OllamaApiClient(_ollamaUri, model);
                _clients[model] = client;
            }
            return client;
        }
    }
}
