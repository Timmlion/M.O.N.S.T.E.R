using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MONSTER.Components
{
    public partial class ChatComponent : ComponentBase
    {
        private List<ChatElement> _chatElements = new List<ChatElement> {
            new ChatElement {Content="What is lorem ipsum?",Variant = Variant.Text, HorizontalAlignment=HorizontalAlignment.Right },{
            new ChatElement {Content="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                                       Variant = Variant.Outlined, HorizontalAlignment=HorizontalAlignment.Left} } };

        private string _chatInput;
        
    }

    public class ChatElement
    {
        public string Content { get; set; }
        public Variant Variant { get; set; }
        public HorizontalAlignment HorizontalAlignment{get;set;}
    }
}
