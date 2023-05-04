using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MONSTER.Models;
using OpenAI_API.Models;

namespace MONSTER.Components
{
    public partial class SettingsComponent : ComponentBase
    {
        [Inject]
        public ISyncLocalStorageService _localStorage { get; set; }
        [Inject]
        private NavigationManager UriHelper { get; set; }

        private ChatSettings _cs { get; set; } 

        private string _model;

        protected override void OnParametersSet()
        {
            _cs = _localStorage.GetItem<ChatSettings>("Settings");
            if (_cs == null) {
            _cs = new ChatSettings();
            }
        }

        private void SaveSettings()
        {
            if(_model == "GPT4")
            {
                _cs.Model = Model.GPT4;
            }
            else if(_model == "ChatGPTTurbo")
            {
                _cs.Model = Model.ChatGPTTurbo;
            }

            _localStorage.SetItem("Settings", _cs);
            UriHelper.NavigateTo($"/");
        }
    }
}
