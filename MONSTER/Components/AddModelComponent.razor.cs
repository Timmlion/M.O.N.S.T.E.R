using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MONSTER.Models;
using MONSTER.Services;
using MudBlazor;
using System.Text.Json;

namespace MONSTER.Components
{
    public partial class AddModelComponent : ComponentBase
    {
        [Inject]
        public ILocalStorageService _localStorage { get; set; }

        private AssistantModel _am = new AssistantModel();

        private async void SaveModel()
        {
            List<AssistantModel> ModelList = await _localStorage.GetItemAsync<List<AssistantModel>>("Models");

            ModelList.Add(_am);
        }
    }
}
