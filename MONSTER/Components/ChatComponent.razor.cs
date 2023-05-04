using Blazored.LocalStorage;
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
        public ISyncLocalStorageService _localStorage { get; set; }

        private List<ChatElement> _chatElements = new List<ChatElement>();

        private string _inputField;

        public async Task SendMsgAsync(KeyboardEventArgs e)
        {            
            if (e.Code == "Enter" || e.Code == "NumpadEnter")
            {
                string chatInput = _inputField;
                _inputField = "";

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
