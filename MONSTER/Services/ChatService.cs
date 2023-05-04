using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MONSTER.Models;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;

namespace MONSTER.Services
{
    public class ChatService
    {        
        public ISyncLocalStorageService _localStorage { get; set; }

        //https://github.com/OkGoDoIt/OpenAI-API-dotnet
        private OpenAIAPI _api;
        private Conversation _chat;
        private ChatSettings _chatSettings;

        public ChatService(ISyncLocalStorageService localStorage)
        {
            _localStorage = localStorage;
            _chatSettings = _localStorage.GetItem<ChatSettings>("Settings");
            ResetChat();
        }


        public void ResetChat()
        {
            _api = new OpenAIAPI(_chatSettings.OpenAiApiKey);            
            _chat = _api.Chat.CreateConversation();
            _chat.Model = _chatSettings.Model;
        }

        public void SetSystemMsg(string msg)
        {
            _chat = _api.Chat.CreateConversation();
            _chat.Model = _chatSettings.Model;
            _chat.AppendSystemMessage(msg);
        }

        public async Task<string> SendMsgAsync(string msg)
        {
            _chat.AppendUserInput(msg);
            return await _chat.GetResponseFromChatbotAsync();
        }
    }
}
