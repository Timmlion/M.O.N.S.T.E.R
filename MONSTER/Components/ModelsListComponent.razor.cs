using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MONSTER.Components
{
    public partial class ModelsListComponent : ComponentBase
    {
        private List<AssistantModel> _assistantModels = new List<AssistantModel> { new AssistantModel { Name="Tłumacz", SystemPrompt="Trolo", Icon = Icons.Material.Filled.LibraryBooks, Variant = Variant.Outlined },
                                                                                                             new AssistantModel { Name="CoPilot", SystemPrompt="Trolo2", Icon = Icons.Material.Filled.Computer, Variant = Variant.Outlined}};
        private void SetPrompt(AssistantModel am)
        {
            ResetVariant();
            am.Variant = Variant.Filled;
            StateHasChanged();
        }

        private void ResetVariant()
        {
            foreach(var assistant in _assistantModels)
            {
                assistant.Variant = Variant.Outlined;
            }
        }
    }

    public class AssistantModel
    {
        public string Name { get; set; }
        public string SystemPrompt { get; set; }
        public string Icon { get; set; }
        public Variant Variant { get; set; }
    }
}
