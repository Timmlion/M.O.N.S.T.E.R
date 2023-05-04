using OpenAI_API.Models;

namespace MONSTER.Models
{
    internal class ChatSettings
    {
        public string OpenAiApiKey { get; set; }
        public Model Model { get; set; }
    }
}