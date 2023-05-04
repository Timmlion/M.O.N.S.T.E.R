﻿using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MONSTER.Services;
using MudBlazor;

namespace MONSTER.Components
{
    public partial class ChatComponent : ComponentBase
    {
        [Inject]
        public ChatService ChatService { get; set; }
        [Inject]
        public ILocalStorageService _localStorage { get; set; }
        [Inject]
        public IConfiguration configuration {get;set;}

        private List<ChatElement> _chatElements = new List<ChatElement>();

        private string _inputField;
        private bool _chatSetUp = false;

        private void Setup()
        {
            ChatService.Setup(configuration["OpenApi:ApiKey"]);  // Switch to local storage           
            _chatSetUp = true;
        }

        public async Task SendMsgAsync(KeyboardEventArgs e)
        {            
            if (e.Code == "Enter" || e.Code == "NumpadEnter")
            {
                string chatInput = _inputField;
                _inputField = "";

                if (!_chatSetUp) Setup();

                ChatElement userInput = new UserChatElement(chatInput);
                _chatElements.Add(userInput);

                var response = await ChatService.SendMsgAsync(chatInput);
                
                ChatElement chatElement = new ResponseChatElement(response);

                _chatElements.Add(chatElement);
            }
        }
    }

    public class ChatElement
    {
        public string Content { get; set; }
        public Variant Variant { get; set; }
        public HorizontalAlignment HorizontalAlignment{get;set;}
    }
    public class ResponseChatElement : ChatElement
    {
        public ResponseChatElement(string msg)
        {
            Content = msg;
            Variant = Variant.Outlined;
            HorizontalAlignment = HorizontalAlignment.Left;
        }       
    }
    public class UserChatElement : ChatElement
    {
        public UserChatElement(string msg)
        {
            Content = msg;
            Variant = Variant.Text;
            HorizontalAlignment = HorizontalAlignment.Right;
        }
    }
}
