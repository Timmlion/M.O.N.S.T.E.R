using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MONSTER.Models;
using MONSTER.Services;
using MudBlazor;
using System.Net;

namespace MONSTER.Components
{
    public partial class ModelsListComponent : ComponentBase
    {
        [Inject]
        public ISyncLocalStorageService _localStorage { get; set; }
        [Inject]
        public ChatService ChatService { get; set; }

        private List<AssistantModelButton>? _assistantModelsButtons;
        protected override void OnParametersSet()
        {
            _assistantModelsButtons = TransformAssistants(_localStorage.GetItem<List<AssistantModel>>("Models"));
            if (_assistantModelsButtons == null )
            {
                _assistantModelsButtons = new List<AssistantModelButton>();
            }
        }

        private List<AssistantModelButton> TransformAssistants(List<AssistantModel> assistantModels)
        {            
            List<AssistantModelButton> result = new List<AssistantModelButton>();
            if (assistantModels != null)
            {
                foreach (AssistantModel assistantModel in assistantModels)
                {
                    result.Add(new AssistantModelButton
                    {
                        Name = assistantModel.Name,
                        SystemPrompt = assistantModel.SystemPrompt,
                        Icon = assistantModel.Icon,
                        Variant = Variant.Outlined
                    });
                }
            }
            return result;
        }

        private void SetPrompt(AssistantModelButton am)
        {
            ChatService.SetSystemMsg(am.SystemPrompt);
            ResetVariant();
            am.Variant = Variant.Filled;
            StateHasChanged();
        }

        private void ResetVariant()
        {
            foreach(var assistant in _assistantModelsButtons)
            {
                assistant.Variant = Variant.Outlined;
            }
        }
    }

    public class AssistantModelButton : AssistantModel
    {        
        public Variant Variant { get; set; }
    }
}
