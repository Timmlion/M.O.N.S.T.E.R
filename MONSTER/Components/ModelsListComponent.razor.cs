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
        public ILocalStorageService _localStorage { get; set; }

        private List<AssistantModelButton> _assistantModelsButtons = new List<AssistantModelButton>();
        protected override async Task OnParametersSetAsync()
        {
            _assistantModelsButtons = TransformAssistants(await _localStorage.GetItemAsync<List<AssistantModel>>("Models"));
        }

        private List<AssistantModelButton> TransformAssistants(List<AssistantModel> assistantModels)
        {
            List<AssistantModelButton> result = new List<AssistantModelButton>();
            foreach(AssistantModel assistantModel in assistantModels)
            {
                result.Add(new AssistantModelButton
                {
                    Name = assistantModel.Name,
                    SystemPrompt = assistantModel.SystemPrompt,
                    Icon = assistantModel.Icon,
                    Variant = Variant.Outlined
                });
            }
            return result;
        }

        private void SetPrompt(AssistantModelButton am)
        {
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
