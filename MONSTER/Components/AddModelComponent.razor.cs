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
        public ISyncLocalStorageService _localStorage { get; set; }
        [Inject]
        private NavigationManager UriHelper { get; set; }

        private AssistantModel _am = new AssistantModel();

        private void SaveModel()
        {
            List<AssistantModel> ModelList = _localStorage.GetItem<List<AssistantModel>>("Models");
            ModelList.Add(_am);
            _localStorage.SetItem<List<AssistantModel>>("Models", ModelList);
            UriHelper.NavigateTo($"/");
        }
    }
}
