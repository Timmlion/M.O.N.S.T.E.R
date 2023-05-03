using Microsoft.AspNetCore.Components;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

namespace MONSTER.Services
{
    public class ChatService
    {
        //https://github.com/OkGoDoIt/OpenAI-API-dotnet
        private OpenAIAPI _api;
        private Conversation _chat;
        private Model _model;

        public void Setup(string apiKey)
        {
            _api = new OpenAIAPI(apiKey);
            _chat = _api.Chat.CreateConversation();
        }
        public void SetSystemMsg(string msg)
        {            
            _chat.AppendSystemMessage(msg);
        }

        public async Task<string> SendMsgAsync(string msg)
        {
            _chat.AppendUserInput(msg);
            return await _chat.GetResponseFromChatbotAsync();
        }
    }
}
